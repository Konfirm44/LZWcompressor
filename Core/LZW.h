#pragma once
#include <vector>
#include "Dictionary.h"

class LZW
{
protected:
	Dictionary dictionary_;

public:
	virtual std::vector<char> processChunk(std::vector<char>, std::uintmax_t& processedBytes) = 0;
};