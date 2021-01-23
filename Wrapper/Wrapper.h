#pragma once
#include "ManagedObject.h"
#include "../Core/Controller.h"

using namespace System;

namespace Wrapper {

	// C++/CLI wrapper for the C++ "Controller" class.
	public ref class WrappedController : public ManagedObject<Controller>
	{
	public:
		WrappedController(String^ fileName, bool shouldCompress, bool useASM, bool useCstrings, int threads);
		// Constructs the "Controller" object.

		void processFile();
		// Calls Controller::processFile().

		int getProgress();
		// Calls Controller::progress().
	};
}
