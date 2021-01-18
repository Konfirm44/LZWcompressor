//#include "Decompressor.h"
//
//// iChunk contains compressed data
//std::vector<char> Decompressor::processChunk(std::vector<char> iChunk, std::uintmax_t& processedBytes)
//{
//    unsigned short* shortPtr = reinterpret_cast<unsigned short*>(iChunk.data());
//    std::vector<unsigned short> compressed(shortPtr, shortPtr + iChunk.size() / 2);
//    std::string decompressed; //decompressed data
//
//    std::string currWord, prevWord; // current and previous processed word
//    unsigned short currCode;
//
//    unsigned offset = 0;
//
//    do
//    {
//        prevWord = dictionary_[compressed[0 + offset]];
//        ++processedBytes;
//        decompressed += prevWord;
//        for (unsigned i = 1 + offset; i < compressed.size(); ++i)
//        {
//            processedBytes += 2;
//            if (processedBytes % 1000 == 0)
//                printf("%u\n", processedBytes);
//
//            currCode = compressed[i];
//            if (currCode == dictionary_.flushCode)
//            {
//                dictionary_.flush();
//                offset = i + 1;
//                break;
//            }
//
//            if (currCode < dictionary_.size()) // a word with this code exists in the dictionary
//            {
//                currWord = dictionary_[currCode];
//                
//                if (!dictionary_.add(prevWord + currWord[0]) && compressed[i + 1] != dictionary_.flushCode)
//                    throw 'x';
//            }
//            else
//            {
//                currWord = prevWord + prevWord[0];
//                
//                if (!dictionary_.add(currWord) && compressed[i + 1] != dictionary_.flushCode)
//                    throw 1;
//            }
//
//            decompressed += currWord;
//            prevWord = currWord;
//
//            if (i == iChunk.size() - 1)
//                offset = 0;
//        }
//    } while (offset != 0);
//
//    std::vector<char> oChunk(decompressed.begin(), decompressed.end());
//    return oChunk;
//}
