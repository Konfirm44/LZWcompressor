#include "Wrapper.h"
#include <fstream>

Wrapper::WrappedController::WrappedController(String^ fileName, bool shouldCompress, bool useASM, bool useCstrings, int threads)
    : ManagedObject(new Controller(string_to_char_array(fileName), shouldCompress, useASM, useCstrings, threads))
{  
}

void Wrapper::WrappedController::processFile()
{
    unmanagedObject_->processFile();
}

int Wrapper::WrappedController::getProgress()
{
    return unmanagedObject_->progress();
}
