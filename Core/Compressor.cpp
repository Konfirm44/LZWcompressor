//#include "Compressor.h"
//#include <cstdio>
//
//// iChunk contains data that will be compressed
//std::vector<char> Compressor::processChunk(std::vector<char> iChunk, std::uintmax_t& processedBytes)
//{
//	std::vector<unsigned short> compressed;
//	std::string s;
//	unsigned offset = 0;
//
//	do
//	{
//		s += iChunk[0 + offset];
//		++processedBytes;
//		for (unsigned i = 1 + offset; i < iChunk.size(); ++i)
//		{
//			++processedBytes;
//			if (processedBytes % 1000 == 0)
//				printf("%u\n", processedBytes);
//
//			char c = iChunk[i];
//			if (dictionary_.contains(s + c))
//			{
//				s += c;
//			}
//			else
//			{
//				compressed.push_back(dictionary_.code(s));
//				if (!dictionary_.add(s + c))
//				{
//					compressed.push_back(dictionary_.flush());
//					offset = i + 1;
//					break;
//				}
//				s = c;
//			}
//
//			if (i == iChunk.size() - 1)
//				offset = 0;
//		}
//	} while (offset != 0);
//
//	compressed.push_back(dictionary_.code(s));
//
//	char* charPtr = (char*)compressed.data();
//	std::vector<char> oChunk(charPtr, charPtr + sizeof(short) * compressed.size());
//	return oChunk;
//}
