#pragma once
/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * Jêzyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

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

