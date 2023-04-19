#pragma once
#include <atomic>
#include <vector>

namespace LZW
{
	// @param iChunk - input (not compressed) data
	// @param processedBytes - the function will increment the variable according to its progress
	// @return compressed data
	std::vector<char> compress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings);
	
	// @param iChunk - input (not compressed) data
	// @param processedBytes - the function will increment the variable according to its progress
	// @return decompressed data
	std::vector<char> decompress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings);
}