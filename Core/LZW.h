#pragma once
#include <vector>
#include "Dictionary.h"

namespace LZW
{
	std::vector<char> compress(std::vector<char> iChunk, std::uintmax_t& processedBytes);
	std::vector<char> decompress(std::vector<char> iChunk, std::uintmax_t& processedBytes);
}

//class LZW
//{
////protected:
////	Dictionary dictionary_;
//
//public:
//	static std::vector<char> compress(std::vector<char> iChunk, std::uintmax_t& processedBytes);
//	static std::vector<char> decompress(std::vector<char> iChunk, std::uintmax_t& processedBytes);
//};