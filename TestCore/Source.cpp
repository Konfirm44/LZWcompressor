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
	int threads = 1;
	bool useASM = true;

	Controller controller(full.c_str(), shouldCompress, useASM, threads);
	std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
	controller.processFile();
	std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

	auto time = std::chrono::duration_cast<std::chrono::seconds>(end - begin).count();
	std::cout << "Time difference = " << time << "[s]" << std::endl;
	std::ofstream log("log.csv", std::ios::app);
	if (log)
		log << full << ";" << time << "[s]" << "\n";
	else
		std::cerr << "Could not open log file." << std::endl;
}

extern "C" bool test_ASM(int* words, unsigned size, const int s, unsigned* index);

int main()
{
	int arr[5] = { 1,2,3,4,5 };
	unsigned ind = 0;
	bool b = test_ASM(arr, 5, 3, &ind);
	bool c = b;

	//Dictionary_ASM d;
	//d.contains("a");

	/*std::string file = "gh";

	process(1, file);
	process(0, file);*/
}