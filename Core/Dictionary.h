#pragma once
#include <string>
#include <vector>

class Dictionary
{
public:
    virtual unsigned short flush() = 0;

    virtual bool add(std::string s) = 0;

    virtual bool contains(std::string s) = 0;

    virtual unsigned short code(std::string s) = 0;

    virtual std::string operator[](int i) = 0;

    virtual size_t size() const = 0;

    static const unsigned short flushCode = 65535;
};