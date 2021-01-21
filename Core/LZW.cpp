#include "LZW.h"
#include "Dictionary_ASM.h"
//#include "Dictionary_CPP.h"
#include <iostream>
//#include <memory>

std::vector<char> LZW::compress(std::vector<char> iChunk, std::uintmax_t& processedBytes, bool useASM)
{
    //std::unique_ptr<Dictionary> dictionaryPtr;
    //if (!useASM)
    //    dictionaryPtr = std::make_unique<Dictionary_CPP>();
    //else
    //    dictionaryPtr = std::make_unique<Dictionary_ASM>();
    //Dictionary& dictionary = *dictionaryPtr;
    Dictionary_ASM dictionary(useASM);

	std::vector<unsigned short> compressed;
    std::string s;
	unsigned offset = 0;

	do
	{
        s.clear();
		s += iChunk[0 + offset];
		++processedBytes;
		for (auto i = 1 + offset; i < iChunk.size(); ++i)
		{
			++processedBytes;
            if (processedBytes % 1000 == 0)
                std::cout << processedBytes << "\t" << dictionary.size() << std::endl;

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
                    offset = i + 1;
                    compressed.push_back(dictionary.flush());
					break;
				}
				s = c;
			}

			if (i == iChunk.size() - 1)
				offset = 0;
		}
	} while (offset != 0);

	compressed.push_back(dictionary.code(s));

	char* charPtr = (char*)compressed.data();
	std::vector<char> oChunk(charPtr, charPtr + sizeof(short) * compressed.size());
	return oChunk;
}



std::vector<char> LZW::decompress(std::vector<char> iChunk, std::uintmax_t& processedBytes, bool useASM)
{
    //std::unique_ptr<Dictionary> dictionaryPtr;
    //if (!useASM)
    //    dictionaryPtr = std::make_unique<Dictionary_CPP>();
    //else
    //    dictionaryPtr = std::make_unique<Dictionary_ASM>();
    //Dictionary& dictionary = *dictionaryPtr;
    Dictionary_ASM dictionary(useASM);

    unsigned short* shortPtr = reinterpret_cast<unsigned short*>(iChunk.data());
    std::vector<unsigned short> compressed(shortPtr, shortPtr + iChunk.size() / 2);
    std::string decompressed; //decompressed data

    std::string currWord, prevWord; // current and previous processed word
    unsigned short currCode;

    unsigned offset = 0;

    do
    {
        prevWord = dictionary[compressed[0 + offset]];
        ++processedBytes;
        decompressed += prevWord;
        for (auto i = 1 + offset; i < compressed.size(); ++i)
        {
            processedBytes += 2;
            if (processedBytes % 1000 == 0)
                std::cout << processedBytes << " \t" << dictionary.size() << std::endl;

            currCode = compressed[i];
            if (currCode == dictionary.flushCode)
            {
                offset = i + 1;
                dictionary.flush();
                break;
            }

            if (currCode < dictionary.size()) // a word with this code exists in the dictionary
            {
                currWord = dictionary[currCode];

                dictionary.add(prevWord + currWord[0]);    // dictionary is full
                //{                   
                //    //decompressed += currWord;
                //    //decompressed += dictionary[compressed[i+2]]; // is a single char-code, so it's ok to do it that way
                //    //dictionary.flush();
                //    //offset = i + 3;
                //    //break;
                //}
            }
            else
            {
                currWord = prevWord + prevWord[0];

                dictionary.add(currWord);
                //{
                //    printf("dupa");
                //    if (compressed[i + 1] != dictionary.flushCode)
                //        throw 1;
                //}
            }

            decompressed += currWord;
            prevWord = currWord;

            if (i == iChunk.size() - 1)
                offset = 0;
        }
    } while (offset != 0);

    std::vector<char> oChunk(decompressed.begin(), decompressed.end());
    return oChunk;
}
