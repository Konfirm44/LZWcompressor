#pragma once
/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * J�zyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

#include "Dictionary.h"

class Dictionary_CPP : public Dictionary
{
private:
	std::vector<std::string> words;
    unsigned short indexOfLastCheckedWord_ = 0;
    bool useASM_ = false;   // not implemented

public:
    Dictionary_CPP(bool useASM);

    unsigned short flush();

    bool add(std::string s);

    bool contains(std::string s);

    unsigned short code(std::string s);

    std::string operator[](int i);

    size_t size() const;
};

