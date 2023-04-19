#pragma once
#include "LZW.h"
#include <atomic>
#include <filesystem>
namespace fs = std::filesystem;

// Controls the process of translating a file using the LZW algorithm.
class Controller {
private:

	// a valid path to an existing non-empty file
	const char* filePath_;

	// true - compression, false - decompression
	bool shouldCompress_;

	// true - compression uses ASM functions
	bool useASM_;

	// True - data from the file can be stored as C-strings (file contains no 0x00 bytes).
	// Enables the use of ASM functions during compression (Dictionary_ASM) - if false, data is stored in std::string objects (Dictionary_CPP).
	bool useCstrings_;

	// number of threads to use during compression
	int threadCount_;

	// to track progress
	std::atomic<std::uintmax_t> processedBytes_ = 0;	

	// input file size (bytes)
	std::uintmax_t fileSize_ = 0;						

	/**
	 @param buffer - pointer to input data
	 @param bufferCount - size of input data buffer
	 @return compressed data
	*/
	std::vector<char> compressWithThreads(char* buffer, size_t bufferCount);

public:

	Controller(const char* fileName, bool shouldCompress, bool useASM, bool useCstrings, int threads)
		: filePath_(fileName)
		, shouldCompress_(shouldCompress)
		, useASM_(useASM)
		, useCstrings_(useCstrings)
		, threadCount_(threads)
	{
		fs::path path = filePath_;
		fileSize_ = fs::file_size(path);
	}

	// Translates input file into output file.
	void processFile();	

	// Returns the progress as int 0-100.
	int progress()	
	{
		float bytes = float(processedBytes_.load());
		int progress = floor(bytes / fileSize_ * 100.f);
		return progress > 100 ? 100 : progress;
	}
};