#include "Dictionary_ASM.h"
#include <cstring>

constexpr auto FLUSH_CODE = 65535;

Dictionary_ASM::Dictionary_ASM()
{
    for (auto i = 0; i < 256; ++i)
    {
        char* str = new char[2];
        str[0] = i;
        str[1] = 0;
        words.push_back()
    }
}

unsigned short Dictionary_ASM::flush()
{
    for (auto i = wordsSize; i > 255; --i)
    {
        free(words[i]);
        --wordsSize;
    }
    return FLUSH_CODE;
}

bool Dictionary_ASM::add(std::string s)
{
    if (wordsSize == FLUSH_CODE - 1)
        return false;

    if (wordsSize == wordsCapacity)
    {
        words =(char**) realloc(words, wordsCapacity + CAPACITY_STEP);
        if (!words)
            throw "Hmm";
        wordsCapacity += CAPACITY_STEP;
    }
    char* str = (char*)malloc(s.size() + 1);
    strcpy_s(str, s.size() + 1, s.c_str());
    words[wordsSize] = str;
    wordsSize += 1;
    return true;
}

bool containsTMP(char** words, const unsigned wordsSize, const char* s, unsigned* indexOfLastCheckedWord)
{
    for (unsigned i = 0; i < wordsSize; ++i)
    {
        if (!strcmp(words[i], s))
        {
            *indexOfLastCheckedWord = i;
            return true;
        }
    }
    return false;
}

bool Dictionary_ASM::contains(std::string s)
{
    //return containsTMP(words, wordsSize, s.c_str(), &indexOfLastCheckedWord);

    for (unsigned i = 0; i < wordsSize; ++i)
    {
        if (!strcmp(words[i], s.c_str()))
        {
            indexOfLastCheckedWord = i;
            return true;
        }
    }
    return false;
}

unsigned short Dictionary_ASM::code(std::string s)
{
    if (!strcmp(words[indexOfLastCheckedWord], s.c_str()))
        return indexOfLastCheckedWord;

    for (auto i = 0; i < wordsSize; ++i)
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
    return wordsSize;
}

Dictionary_ASM::~Dictionary_ASM()
{
    for (auto i = 0; i < wordsSize; ++i)
        free(words[i]);
    free(words);
}
