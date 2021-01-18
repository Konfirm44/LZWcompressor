#pragma once
#include <vector>

namespace LZW
{
	std::vector<char> compress(std::vector<char> iChunk, std::uintmax_t& processedBytes, bool useASM);
	std::vector<char> decompress(std::vector<char> iChunk, std::uintmax_t& processedBytes, bool useASM);
}