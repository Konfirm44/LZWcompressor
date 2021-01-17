#include "Controller.h"

#include <fstream>
#include <iostream>
#include <sstream>
#include <vector>

void Controller::processFile()
{
	std::ifstream iFile(filePath_, std::ios::binary);
	if (!iFile)
	{
		std::cerr << "Could not open input file." << std::endl;
		return;
	}

	const size_t bufferSize = 1 << 30;
	char* buffer = new char[bufferSize];

	LZW* translator;
	if (shouldCompress_)
		translator = new Compressor();
	else
		translator = new Decompressor();

	//std::stringstream outputStream;

	std::string suffix = shouldCompress_ ? "_cmp" : "_decmp";
	std::ofstream oFile(filePath_ + suffix, std::ios::binary);
	if (!oFile)
	{
		std::cerr << "Could not open output file." << std::endl;
		return;
	}

	while (iFile)
	{
		iFile.read(buffer, bufferSize);
		size_t bufferCount = iFile.gcount();
		std::cout << "Read " << bufferCount << " bytes." << std::endl;
		if (!bufferCount)	// is this even possible?
			break;

		std::vector<char> iChunk(buffer, buffer + bufferCount);

		std::vector<char> oChunk = translator->processChunk(iChunk, processedBytes_);

		//outputStream.write(oChunk.data(), oChunk.size());
		oFile.write(oChunk.data(), oChunk.size());
	}
	delete[] buffer;
	delete translator;

	//std::string suffix = shouldCompress_ ? "_cmp" : "_decmp";
	//std::ofstream oFile(filePath_ + suffix, std::ios::binary);
	//if (!oFile)
	//{
	//	std::cerr << "Could not open output file." << std::endl;
	//	return;
	//}

	//oFile << outputStream.rdbuf();
	std::cout << "File processed." << std::endl;
}

extern "C"
{
	int MyProc1(int, int);
	int MyProc2(int);
}

int Controller::test()
{
	int t = MyProc2(20);
	return t;
}
