#pragma once
/**
 * Algorytm kompresji LZW
 *
 * Tomasz Sitek, gr. 3
 * Jêzyki Asemblerowe, sekcja 2
 * informatyka SSI 2020/2021, semestr zimowy
 *
 * wersja 1.0
 */

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Wrapper {

	// Template class for wrapping unmanaged C++ objects for C++/CLI.
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

		static const char* string_to_char_array(String^ string)
		{
			const char* str = (const char*)(Marshal::StringToHGlobalAnsi(string)).ToPointer();
			return str;
		}
	};
}