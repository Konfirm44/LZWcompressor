#include "Dictionary_ASM.h"
#include <cstring>

constexpr auto sizeLimit = Dictionary_ASM::flushCode - 1;

// Assembly language implementation of the Dictionary_ASM::contains() method. Implementation in the CoreASM project.
// @param char** words - array of C-strings to search in
// @param const char* str - C-string to search for
// @param unsigned words_size - size of the array
// @param unsigned* index - variable where the index of the found element will be placed
// @return true if the array contains the string.
extern "C" bool contains_ASM(char** words, const char* str, unsigned words_size, unsigned* index);

// Assembly language implementation of a section of the Dictionary_ASM constructor. Implementation in the CoreASM project.
// Fills the "words" array of allocated C-strings with the initial 256 words of an LZW dictionary.
// @param char** words - array of C-strings with 256 allocated elements, each 2 characters long
extern "C" void dictionaryInit_ASM(char** words);

Dictionary_ASM::Dictionary_ASM(bool useASM) : useASM_(useASM)
{
    if (useASM)
    {
        for (auto i = 0; i < 256; ++i)
        {
            words_.emplace_back(new char[2]);
        }
        dictionaryInit_ASM(words_.data());
    }
    else
    {
        for (auto i = 0; i < 256; ++i)
        {
            char* str = new char[2];
            str[0] = i;
            str[1] = 0;
            words_.push_back(str);
        }
    }
}

unsigned short Dictionary_ASM::flush()
{
    for (auto i = words_.size() - 1; i > 255; --i)
    {
        delete[] words_[i];
    }
    words_.resize(256);
    indexOfLastCheckedWord_ = 0;
    return flushCode;
}

bool Dictionary_ASM::add(std::string s)
{
    if (words_.size() == sizeLimit)
    {
        return false;
    }

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
    {
        return indexOfLastCheckedWord_;
    }

    if (useASM_)
    {
        if (contains_ASM(words_.data(), s.c_str(), words_.size(), &indexOfLastCheckedWord_))
            return indexOfLastCheckedWord_;
    }
    else
    {
        for (auto i = 0; i < words_.size(); ++i)
            if (!strcmp(words_[i], s.c_str()))
                return i;
    }

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
