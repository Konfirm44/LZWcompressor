#pragma once
#include <string>
#include <vector>

// LZW-compatible dictionary abstract class
class Dictionary
{
public:

    // Resets the dictionary to its initial state (size = 256).
    // @return "flushCode" value
    virtual unsigned short flush() = 0;

    // Adds a word to the dictionary.
    // @return false if the dictionary has reached its maximum size
    virtual bool add(std::string s) = 0;

    // @return true if the dictionary contains the word
    virtual bool contains(std::string s) = 0;

    // @return the code of a dictionary-contained word
    virtual unsigned short code(std::string s) = 0;
    
    // @return the i-th word from the dictionary
    virtual std::string operator[](int i) = 0;
    
    // @return the number of words contained in the dictionary.
    virtual size_t size() const = 0;
    
    // Code used to indicate that the translation process had reset/must reset the dictionary.
    static const unsigned short flushCode = 65535;

};