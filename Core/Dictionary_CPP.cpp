/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * Jêzyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

#include "Dictionary_CPP.h"

Dictionary_CPP::Dictionary_CPP(bool useASM) : useASM_(useASM)
{
    for (unsigned short i = 0; i < 256; ++i)
    {
        std::string t(1, char(i));
        words.push_back(t);
    }
}

unsigned short Dictionary_CPP::flush()
{
    words.resize(256);
    return flushCode;
}

bool Dictionary_CPP::add(std::string s)
{
    if (words.size() == flushCode - 1)
        return false;
    words.push_back(s);
    return true;
}

bool Dictionary_CPP::contains(std::string s)
{
    for (auto i = 0; i < words.size(); ++i)
    {
        if (words[i] == s)
        {
            indexOfLastCheckedWord_ = i;
            return true;
        }
    }
    return false;
}

unsigned short Dictionary_CPP::code(std::string s)
{
    if (words[indexOfLastCheckedWord_] == s)
        return indexOfLastCheckedWord_;

    for (auto i = 0; i < words.size(); ++i)
        if (words[i] == s)
            return i;

    throw 0.f;
}

std::string Dictionary_CPP::operator[](int i)
{
    return words[i];
}

size_t Dictionary_CPP::size() const
{
    return words.size();
}
