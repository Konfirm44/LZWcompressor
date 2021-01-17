#include "Dictionary.h"

Dictionary::Dictionary()
{
    for (int i = -128; i < 128; ++i)
    {
        std::string t(1, char(i));
        words.push_back(t);
    }
}

unsigned short Dictionary::flush()
{
    words.resize(256);
    return flushCode;
}

bool Dictionary::add(std::string s)
{
    if (words.size() == flushCode - 1)
        return false;
    words.push_back(s);
    return true;
}

bool Dictionary::contains(std::string s)
{
    for (unsigned i = 0; i < words.size(); ++i)
    {
        if (words[i] == s)
        {
            indexOfLastCheckedWord_ = i;
            return true;
        }
    }
    return false;
}

unsigned short Dictionary::code(std::string s)
{
    if (words[indexOfLastCheckedWord_] == s)
        return indexOfLastCheckedWord_;

    for (auto i = 0; i < words.size(); ++i)
        if (words[i] == s)
            return i;
}

std::string Dictionary::operator[](int i)
{
    return words[i];
}

//void Dictionary::setASM(bool useASM)
//{
//    Dictionary::_useASM = useASM;
//}
