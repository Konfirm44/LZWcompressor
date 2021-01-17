#pragma once
#include "LZW.h"
class Decompressor : public LZW
{
public:
	std::vector<char> processChunk(std::vector<char> iChunk, std::uintmax_t& processedBytes);
};

