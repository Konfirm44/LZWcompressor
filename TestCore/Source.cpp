#include <chrono>
#include <fstream>
#include <iostream>
#include "../Core/Controller.h"
#include "../Core/Dictionary_ASM.h"

void process(bool shouldCompress, std::string file)
{
	std::string dir = "C:/ZZZ/";
	std::string ext = shouldCompress ? ".txt" : ".txt_cmp";
	std::string full = dir + file + ext;
	int threads = 2;
	bool useASM = true;
	bool useCstrings = true;

	Controller controller(full.c_str(), shouldCompress, useASM, useCstrings, threads);
	std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
	controller.processFile();
	std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

	auto time = std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count();
	std::cout << "Time difference = " << time << "[ms]" << std::endl;
	std::ofstream log("log.csv", std::ios::app);
	if (log)
		log << full << ";" << time << "[ms];asm: " << useASM << "\n";
	else
		std::cerr << "Could not open log file." << std::endl;
}

int main()
{
	std::string file = "shak";

	//process(1, file);
	process(0, file);
}