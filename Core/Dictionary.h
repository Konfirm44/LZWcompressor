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

#include <string>
#include <vector>

// LZW-compatible dictionary abstract class
class Dictionary
{
public:
    virtual unsigned short flush() = 0;
    // Resets the dictionary to its initial state (size = 256).
    // Returns "flushCode" value.

    virtual bool add(std::string s) = 0;
    // Adds a word to the dictionary.
    // Returns false if the dictionary has reached its maximum size.

    virtual bool contains(std::string s) = 0;
    // Returns true if the dictionary contains the word.

    virtual unsigned short code(std::string s) = 0;
    // Returns the code of a dictionary-contained word.

    virtual std::string operator[](int i) = 0;
    // Returns the i-th word from the dictionary.

    virtual size_t size() const = 0;
    // Returns the number of words contained in the dictionary.

    static const unsigned short flushCode = 65535;
    // Code used to indicate that the translation process had reset/must reset the dictionary.
};