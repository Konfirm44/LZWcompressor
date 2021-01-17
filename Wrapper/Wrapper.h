#pragma once
#include "ManagedObject.h"
#include "../Core/Controller.h"

using namespace System;

namespace Wrapper {
	public ref class WrappedController : public ManagedObject<Controller>
	{
	public:
		WrappedController(String^ fileName, bool shouldCompress, bool useASM, int threads);
		void work();
		int getProgress();
	};
}
