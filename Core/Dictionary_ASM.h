#pragma once
#include "Dictionary.h"

class Dictionary_ASM : public Dictionary
{
private:
    std::vector<char*> words_;
    unsigned indexOfLastCheckedWord_ = 0;
    bool useASM_ = false;

public:
    Dictionary_ASM(bool useASM);

    unsigned short flush();

    bool add(std::string s);

    bool contains(std::string s);

    unsigned short code(std::string s);

    std::string operator[](int i);

    size_t size() const;

    ~Dictionary_ASM();
};

