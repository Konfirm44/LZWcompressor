#pragma once
#include <atomic>
#include <vector>

namespace LZW
{
	std::vector<char> compress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings);
	// Returns compressed data.
	// iChunk - input (not compressed) data
	// processedBytes - the function will increment the variable according to its progress


	std::vector<char> decompress(std::vector<char> iChunk, std::atomic<std::uintmax_t>* processedBytes, bool useASM, bool useCstrings);
	// Returns decompressed data.
	// iChunk - input (compressed) data
	// processedBytes - the function will increment the variable according to its progress
}