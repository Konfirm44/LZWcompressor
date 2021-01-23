/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * Jêzyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

#include "Controller.h"

#include <chrono>
#include <fstream>
#include <iostream>
#include <memory>
#include <string>
#include <thread>
#include <vector>

struct ThreadArg
{
	char* chunk;
	size_t chunkSize;
	std::vector<char>* outputChunk;
	std::atomic<std::uintmax_t>* processedBytes;
	bool useASM;
	bool useCstrings;
};

void threadJob(int thread_n, ThreadArg arg)
{
	std::string msg = "\tThread #" + std::to_string(thread_n) + " started.\n";
	std::cout << msg;

	std::vector<char> inputChunk(arg.chunk, arg.chunk + arg.chunkSize);
	std::vector<char>& outputChunk = *arg.outputChunk;
	

	outputChunk = LZW::compress(inputChunk, arg.processedBytes, arg.useASM, arg.useCstrings);

	msg = "\tThread #" + std::to_string(thread_n) + " stopped.\n";
	std::cout << msg;
}

std::vector<char> Controller::compressWithThreads(char* buffer, size_t bufferCount)
{
	auto chunkSize = fileSize_ / threadCount_ + (fileSize_ % threadCount_ != 0);	// divide and round up

	std::vector<std::thread> threads;
	std::vector<std::unique_ptr<std::vector<char>>> outputChunks;


	ThreadArg templateArg{};
	templateArg.useASM = useASM_;
	templateArg.useCstrings = useCstrings_;
	templateArg.processedBytes = &processedBytes_;

	for (auto i = 0; i < threadCount_; ++i)
	{
		outputChunks.emplace_back(std::make_unique<std::vector<char>>());

		templateArg.chunk = buffer + i * templateArg.chunkSize;
		
		if (chunkSize < bufferCount)
			templateArg.chunkSize = chunkSize;
		else
			templateArg.chunkSize = bufferCount;
		bufferCount -= templateArg.chunkSize;

		templateArg.outputChunk = outputChunks[i].get();

		threads.push_back(std::thread(threadJob, i, templateArg));
	}

	for (auto& t : threads)
	{
		if (t.joinable())
			t.join();
	}

	std::vector<char> output;
	for (auto& uptr : outputChunks)
	{
		std::vector<char>& v = *uptr.get();
		output.insert(output.end(), v.begin(), v.end());
		output.push_back(0xFF);
		output.push_back(0xFF);
	}
	output.pop_back();
	output.pop_back();
	
	return output;
}

void Controller::processFile()
{
	std::ifstream iFile(filePath_, std::ios::binary);
	if (!iFile)
	{
		std::cerr << "Could not open input file." << std::endl;
		return;
	}

	const size_t bufferSize = fileSize_ + 1;
	char* buffer = new char[bufferSize];

	std::string suffix = shouldCompress_ ? "_cmp" : "_decmp";
	std::ofstream oFile(filePath_ + suffix, std::ios::binary);
	if (!oFile)
	{
		std::cerr << "Could not open output file." << std::endl;
		return;
	}

	iFile.read(buffer, bufferSize);
	bool b = (bool)iFile;
	size_t bufferCount = iFile.gcount();
	std::cout << "Read " << bufferCount << " bytes." << std::endl;

	if (!bufferCount || iFile)	// is this even possible? do not think so
		return;
	
	std::vector<char> output;
	if (shouldCompress_)
		output = this->compressWithThreads(buffer, bufferCount);
	else
	{
		std::vector<char> input(buffer, buffer + bufferCount);
		output = LZW::decompress(input, &processedBytes_, useASM_, useCstrings_);
	}

	oFile.write(output.data(), output.size());
	delete[] buffer;

	std::cout << "File processed." << std::endl;
}