#pragma once
#include "ManagedObject.h"
#include "../Core/Controller.h"

using namespace System;

namespace Wrapper {

	// C++/CLI wrapper for the C++ "Controller" class.
	public ref class WrappedController : public ManagedObject<Controller>
	{
	public:
		// Constructs the "Controller" object.
		WrappedController(String^ fileName, bool shouldCompress, bool useASM, bool useCstrings, int threads);
		
		// Calls Controller::processFile().
		void processFile();
		
		// Calls Controller::progress().
		int getProgress();
	};
}
