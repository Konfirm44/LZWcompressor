#include "Dictionary_ASM.h"


extern "C" 
{

}

Dictionary_ASM::Dictionary_ASM()
{
    words = (char**) malloc(wordsSize * sizeof(char*));
    for (unsigned short i = 0; i < 256; ++i)
    {
        char* str = (char*) malloc(2);
        str[0] = i;
        str[1] = 0;
        words[i] = str;
    }
}

unsigned short Dictionary_ASM::flush()
{
    return 0;
}

bool Dictionary_ASM::add(std::string s)
{
    return false;
}

bool Dictionary_ASM::contains(std::string s)
{
    return false;
}

unsigned short Dictionary_ASM::code(std::string s)
{
    return 0;
}

std::string Dictionary_ASM::operator[](int i)
{
    return std::string();
}

size_t Dictionary_ASM::size() const
{
    return size_t();
}

Dictionary_ASM::~Dictionary_ASM()
{
    for (auto i = 0; i < wordsSize; ++i)
        free(words[i]);
    free(words);
}
