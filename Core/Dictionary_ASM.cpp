#include "Dictionary_ASM.h"
#include <cstring>

extern "C" bool contains_ASM(char** words, const char* str, unsigned words_size, unsigned* index);

Dictionary_ASM::Dictionary_ASM(bool useASM) : useASM_(useASM)
{
    for (auto i = 0; i < 256; ++i)
    {
        char* str = new char[2];
        str[0] = i;
        str[1] = 0;
        words_.push_back(str);
    }
}

unsigned short Dictionary_ASM::flush()
{
    for (auto i = words_.size(); i > 255; --i)
    {
        delete[] words_[i];
    }
    return flushCode;
}

bool Dictionary_ASM::add(std::string s)
{
    if (words_.size() == flushCode - 1)
        return false;

    char* str = new char[s.size() + 1];
    strncpy_s(str, s.size() + 1, s.c_str(), s.size() + 1);
    words_.push_back(str);
    return true;
}

bool Dictionary_ASM::contains(std::string s)
{
    if (useASM_)
        return contains_ASM(words_.data(),  s.c_str(), words_.size(), &indexOfLastCheckedWord_);
    
    for (auto i = 0; i < words_.size(); ++i)
    {
        if (!strcmp(words_[i], s.c_str()))
        {
            indexOfLastCheckedWord_ = i;
            return true;
        }
    }
    return false;
}

unsigned short Dictionary_ASM::code(std::string s)
{
    if (!strcmp(words_[indexOfLastCheckedWord_], s.c_str()))
        return indexOfLastCheckedWord_;

    for (auto i = 0; i < words_.size(); ++i)
        if (!strcmp(words_[i], s.c_str()))
            return i;

    throw 0.f;
}

std::string Dictionary_ASM::operator[](int i)
{
    return std::string(words_[i]);
}

size_t Dictionary_ASM::size() const
{
    return words_.size();
}

Dictionary_ASM::~Dictionary_ASM()
{
    for (auto i = 0; i < words_.size(); ++i)
        delete[] words_[i];
}
