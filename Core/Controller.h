#pragma once
#include "LZW.h"
#include <filesystem>
namespace fs = std::filesystem;

class Controller {
private:
	const char* filePath_;
	bool shouldCompress_;
	bool useASM_;
	int threads_;

	std::uintmax_t processedBytes_ = 0;
	std::uintmax_t fileSize_ = 0;

public:
	Controller(const char* fileName, bool shouldCompress, bool useASM, int threads) 
		: filePath_(fileName)
		, shouldCompress_(shouldCompress)
		, useASM_(useASM) 
		, threads_(threads)
	{
		fs::path path = filePath_;
		fileSize_ = fs::file_size(path);
	}

	void processFile();

	int progress() 
	{ 
		int progress = floor(float(processedBytes_) / float(fileSize_) * 100.f);
		return progress > 100 ? 100 : progress; 
	}
};