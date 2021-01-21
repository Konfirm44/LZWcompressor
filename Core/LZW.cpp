#include "LZW.h"
#include "Dictionary_ASM.h"
#include <iostream>

std::vector<unsigned short> subcompress(std::vector<char>& iChunk, std::uintmax_t& processedBytes, bool useASM)
{
    Dictionary_ASM dictionary(useASM);
    std::vector<unsigned short> compressed;
    std::string s;

    s += iChunk[0];
    ++processedBytes;
    for (auto i = 1; i < iChunk.size(); ++i)
    {
        ++processedBytes;
        
#ifdef _DEBUG
        if (processedBytes % 1000 == 0)
            std::cout << processedBytes << "\t" << dictionary.size() << std::endl;
#endif // _DEBUG

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
                return compressed;
            }
            s = c;
        }
    }
    compressed.push_back(dictionary.code(s));

    iChunk.clear();
    return compressed;
}

std::vector<char> LZW::compress(std::vector<char> iChunk, std::uintmax_t& processedBytes, bool useASM)
{
    std::vector<unsigned short> compressed;
    do
    {
        auto t = subcompress(iChunk, processedBytes, useASM);
        compressed.insert(compressed.end(), t.begin(), t.end());
    } while (iChunk.size() > 0);

	char* charPtr = (char*)compressed.data();
	std::vector<char> oChunk(charPtr, charPtr + sizeof(short) * compressed.size());
	return oChunk;
}


std::string subdecompress(std::vector<unsigned short>& compressed, std::uintmax_t& processedBytes, bool useASM)
{
    Dictionary_ASM dictionary(useASM);
    std::string decompressed;
    std::string currWord, prevWord;
    unsigned short currCode;

    prevWord = dictionary[compressed[0]];
    ++processedBytes;
    decompressed += prevWord;
    for (auto i = 1; i < compressed.size(); ++i)
    {
        processedBytes += 2;

#ifdef _DEBUG
        if (processedBytes % 1000 == 0)
            std::cout << processedBytes << " \t" << dictionary.size() << std::endl;
#endif // _DEBUG

        currCode = compressed[i];
        if (currCode == dictionary.flushCode)
        {
            compressed.erase(compressed.begin(), compressed.begin() + i + 1);
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
    compressed.clear();
    return decompressed;
}

std::vector<char> LZW::decompress(std::vector<char> iChunk, std::uintmax_t& processedBytes, bool useASM)
{
    unsigned short* shortPtr = reinterpret_cast<unsigned short*>(iChunk.data());
    std::vector<unsigned short> compressed(shortPtr, shortPtr + iChunk.size() / 2);
    std::string decompressed;

    do
    {
        decompressed += subdecompress(compressed, processedBytes, useASM);
    } while (compressed.size() > 0);

    std::vector<char> oChunk(decompressed.begin(), decompressed.end());
    return oChunk;
}
