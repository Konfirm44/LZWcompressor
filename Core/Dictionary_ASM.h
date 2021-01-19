#pragma once
#include "Dictionary.h"

class Dictionary_ASM : public Dictionary
{
private:
    std::vector<char*> words;
    unsigned indexOfLastCheckedWord = 0;

public:
    Dictionary_ASM();

    unsigned short flush();

    bool add(std::string s);

    bool contains(std::string s);

    unsigned short code(std::string s);

    std::string operator[](int i);

    size_t size() const;

    ~Dictionary_ASM();
};

