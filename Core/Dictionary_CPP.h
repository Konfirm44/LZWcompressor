#pragma once
#include "Dictionary.h"

class Dictionary_CPP : public Dictionary
{
private:
	std::vector<std::string> words;
    unsigned short indexOfLastCheckedWord_ = 0;

public:
    Dictionary_CPP();

    unsigned short flush();

    bool add(std::string s);

    bool contains(std::string s);

    unsigned short code(std::string s);

    std::string operator[](int i);

    size_t size() const;
};

