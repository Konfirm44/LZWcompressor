#pragma once
#include "LZW.h"
class Compressor : public LZW
{
public:
	std::vector<char> processChunk(std::vector<char> iChunk, std::uintmax_t& processedBytes);
};

