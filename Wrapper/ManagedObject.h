#pragma once
using namespace System;
using namespace System::Runtime::InteropServices;

namespace Wrapper {
	template<class T>
	public ref class ManagedObject
	{
	protected:
		T* unmanagedObject_;
	public:
		ManagedObject(T* instance) : unmanagedObject_(instance) 
		{
			if (unmanagedObject_ == nullptr)
				throw gcnew ArgumentNullException;
		}

		virtual ~ManagedObject()
		{
			delete unmanagedObject_;
		}

		!ManagedObject()
		{
			delete unmanagedObject_;
		}

		T* GetInstance()
		{
			return unmanagedObject_;
		}

		static const char* string_to_char_array(String^ string)
		{
			const char* str = (const char*)(Marshal::StringToHGlobalAnsi(string)).ToPointer();
			return str;
		}
	};
}