#include "LZW.h"
#include "Dictionary_ASM.h"
#include "Dictionary_CPP.h"

#include <iostream>
#include <memory>

constexpr auto SUBPROGRESS_LIMIT = 100;

void addProgress(std::atomic<std::uintmax_t>* processedBytes, unsigned progress)
{
    auto t = processedBytes->load();
    t += progress;
    processedBytes->store(t);
}

std::vector<unsigned short> subcompress(std::vector<char>& iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings)
{
    std::unique_ptr<Dictionary> dictionaryPtr;
    if (useCstrings)
        dictionaryPtr = std::make_unique<Dictionary_ASM>(useASM);
    else
        dictionaryPtr = std::make_unique<Dictionary_CPP>(useASM);
    Dictionary& dictionary = *dictionaryPtr;

    std::vector<unsigned short> compressed;
    std::string s;

    unsigned subProgress = 1;

    s += iChunk[0];
    for (auto i = 1; i < iChunk.size(); ++i)
    {
        ++subProgress;
        if (subProgress % SUBPROGRESS_LIMIT == 0)
        {
            addProgress(processedBytes, subProgress);
            subProgress = 0;
        }

        char c = iChunk[i];
        if (dictionary.contains(s + c))
        {
            s += c;
        }
        else
        {
            compressed.push_back(dictionary.code(s));
            if (!dictionary.add(s + c))
            {
                s = c;
                compressed.push_back(dictionary.code(s));
                compressed.push_back(dictionary.flush());
                iChunk.erase(iChunk.begin(), iChunk.begin() + i + 1);
                addProgress(processedBytes, subProgress);
                return compressed;
            }
            s = c;
        }
    }
    compressed.push_back(dictionary.code(s));
    
    addProgress(processedBytes, subProgress);
    iChunk.clear();
    return compressed;
}

std::vector<char> LZW::compress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings)
{
    std::vector<unsigned short> compressed;
    do
    {
        auto t = subcompress(iChunk, processedBytes, useASM, useCstrings);
        compressed.insert(compressed.end(), t.begin(), t.end());
    } while (iChunk.size() > 0);

	char* charPtr = (char*)compressed.data();
	std::vector<char> oChunk(charPtr, charPtr + sizeof(short) * compressed.size());
	return oChunk;
}


std::string subdecompress(std::vector<unsigned short>& compressed, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings)
{
    std::unique_ptr<Dictionary> dictionaryPtr;
    if (useCstrings)
        dictionaryPtr = std::make_unique<Dictionary_ASM>(useASM);
    else
        dictionaryPtr = std::make_unique<Dictionary_CPP>(useASM);
    Dictionary& dictionary = *dictionaryPtr;

    std::string decompressed;
    std::string currWord, prevWord;
    unsigned short currCode;

    unsigned subProgress = 2;

    prevWord = dictionary[compressed[0]];
    decompressed += prevWord;
    for (auto i = 1; i < compressed.size(); ++i)
    {
        subProgress += 2;
        if (subProgress % SUBPROGRESS_LIMIT == 0)
        {
            addProgress(processedBytes, subProgress);
            subProgress = 0;
        }

        currCode = compressed[i];
        if (currCode == dictionary.flushCode)
        {
            compressed.erase(compressed.begin(), compressed.begin() + i + 1);
            addProgress(processedBytes, subProgress);
            return decompressed;
        }

        if (currCode < dictionary.size()) // a word with this code exists in the dictionary
        {
            currWord = dictionary[currCode];
            dictionary.add(prevWord + currWord[0]);
        }
        else
        {
            currWord = prevWord + prevWord[0];
            dictionary.add(currWord);
        }

        decompressed += currWord;
        prevWord = currWord;
    }

    addProgress(processedBytes, subProgress);
    compressed.clear();
    return decompressed;
}

std::vector<char> LZW::decompress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings)
{
    unsigned short* shortPtr = reinterpret_cast<unsigned short*>(iChunk.data());
    std::vector<unsigned short> compressed(shortPtr, shortPtr + iChunk.size() / 2);
    std::string decompressed;

    do
    {
        decompressed += subdecompress(compressed, processedBytes, useASM, useCstrings);
    } while (compressed.size() > 0);

    std::vector<char> oChunk(decompressed.begin(), decompressed.end());
    return oChunk;
}
