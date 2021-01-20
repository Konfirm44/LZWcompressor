#include "Dictionary_ASM.h"
#include <cstring>

extern "C"
{
    bool contains_ASM(char** words, const char* s, unsigned size, unsigned* index);
}

Dictionary_ASM::Dictionary_ASM()
{
    for (auto i = 0; i < 256; ++i)
    {
        char* str = new char[2];
        str[0] = i;
        str[1] = 0;
        words.push_back(str);
    }
}

unsigned short Dictionary_ASM::flush()
{
    for (auto i = words.size(); i > 255; --i)
    {
        delete[] words[i];
    }
    return flushCode;
}

bool Dictionary_ASM::add(std::string s)
{
    if (words.size() == flushCode - 1)
        return false;

    char* str = new char[s.size() + 1];
    strncpy_s(str, s.size() + 1, s.c_str(), s.size() + 1);
    words.push_back(str);
    return true;
}

//bool contains_TMP(char** words, unsigned size, const char* s, unsigned* index)
//{
//    for (auto i = 0; i < size; ++i)
//    {
//        if (!strcmp(words[i], s))
//        {
//            *index = i;
//            return true;
//        }
//    }
//    return false;
//}

bool Dictionary_ASM::contains(std::string s)
{
    return contains_ASM(words.data(),  s.c_str(), words.size(), &indexOfLastCheckedWord);
    /*for (auto i = 0; i < words.size(); ++i)
    {
        if (!strcmp(words[i], s.c_str()))
        {
            indexOfLastCheckedWord = i;
            return true;
        }
    }
    return false;*/
}

unsigned short Dictionary_ASM::code(std::string s)
{
    if (!strcmp(words[indexOfLastCheckedWord], s.c_str()))
        return indexOfLastCheckedWord;

    for (auto i = 0; i < words.size(); ++i)
        if (!strcmp(words[i], s.c_str()))
            return i;

    throw 0.f;
}

std::string Dictionary_ASM::operator[](int i)
{
    return std::string(words[i]);
}

size_t Dictionary_ASM::size() const
{
    return words.size();
}

Dictionary_ASM::~Dictionary_ASM()
{
    for (auto i = 0; i < words.size(); ++i)
        delete[] words[i];
}
