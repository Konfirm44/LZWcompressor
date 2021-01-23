#pragma once
/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * Jêzyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

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