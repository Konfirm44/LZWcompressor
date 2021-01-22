#pragma once
#include <atomic>
#include <vector>

namespace LZW
{
	std::vector<char> compress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings);
	std::vector<char> decompress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings);
}