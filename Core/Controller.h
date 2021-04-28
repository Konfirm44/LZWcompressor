#pragma once
#include "LZW.h"
#include <atomic>
#include <filesystem>
namespace fs = std::filesystem;

// Controls the process of translating a file using the LZW algorithm.
class Controller {
private:
	const char* filePath_;	
	// a valid path to an existing non-empty file

	bool shouldCompress_;	
	// true - compression, false - decompression

	bool useASM_;			
	// true - compression uses ASM functions

	bool useCstrings_;		
	// true - data from the file can be stored as C-strings (file contains no 0x00 bytes) 
	// enables the use of ASM functions during compression (Dictionary_ASM)
	// if false, data is stored in std::string objects (Dictionary_CPP)

	int threadCount_;		
	// number of threads to use during compression

	std::atomic<std::uintmax_t> processedBytes_ = 0;	// to track progress
	std::uintmax_t fileSize_ = 0;						// input file size (bytes)

	std::vector<char> compressWithThreads(char* buffer, size_t bufferCount);
	// Returns compressed data.
	// buffer - pointer to input data
	// bufferCount - size of input data buffer

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

	void processFile();	// Translates input file into output file.

	int progress()	// Returns the progress as int 0-100.
	{ 
		float bytes = float(processedBytes_.load());
		int progress = floor(bytes / fileSize_ * 100.f) ;
		return progress > 100 ? 100 : progress;
	}
};