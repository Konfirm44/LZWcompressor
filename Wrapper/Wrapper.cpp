/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * Jêzyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

#include "Wrapper.h"

Wrapper::WrappedController::WrappedController(String^ fileName, bool shouldCompress, bool useASM, bool useCstrings, int threads)
    : ManagedObject(new Controller(string_to_char_array(fileName), shouldCompress, useASM, useCstrings, threads))
{}

void Wrapper::WrappedController::processFile()
{
    unmanagedObject_->processFile();
}

int Wrapper::WrappedController::getProgress()
{
    return unmanagedObject_->progress();
}
