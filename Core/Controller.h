#pragma once
#include "LZW.h"
#include <atomic>
#include <filesystem>
namespace fs = std::filesystem;

class Controller {
private:
	const char* filePath_;
	bool shouldCompress_;
	bool useASM_;
	bool useCstrings_;
	int threadCount_;

	std::atomic<std::uintmax_t> processedBytes_ = 0;
	std::uintmax_t fileSize_ = 0;

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

	void processFile();

	int progress() 
	{ 
		float bytes = float(processedBytes_.load());
		int progress = floor(bytes / fileSize_ * 100.f) ;
		return progress > 100 ? 100 : progress;
	}
};