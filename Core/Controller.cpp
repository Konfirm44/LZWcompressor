#include "Controller.h"

#include <fstream>
#include <iostream>
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

		std::vector<char> oChunk;
		if (shouldCompress_)
			oChunk = LZW::compress(iChunk, processedBytes_, useASM_);
		else
			oChunk = LZW::decompress(iChunk, processedBytes_, useASM_);

		oFile.write(oChunk.data(), oChunk.size());
	}
	delete[] buffer;

	std::cout << "File processed." << std::endl;
}