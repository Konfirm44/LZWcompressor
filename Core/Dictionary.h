#pragma once
#include<string>
#include<vector>

class Dictionary
{
private:
	std::vector<std::string> words;
    unsigned short indexOfLastCheckedWord_ = 0;
    
    //inline static bool _useASM = false;

public:
    Dictionary();

    unsigned short flush();

    bool add(std::string s);

    bool contains(std::string s);

    unsigned short code(std::string s);

    std::string operator[](int i);

    //static void setASM(bool useASM);

    size_t size() const {
        return words.size();
    }

    const unsigned short flushCode = 65535;
};

