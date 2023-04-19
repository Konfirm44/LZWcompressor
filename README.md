# LZWcompressor

A simple file compression WinForms app that uses the LZW algorithm. 

The algorithm is implemented in C++, along with an optional secondary x64 Assembly implementation of """some""" of its parts. The GUI is written in C# and communication between these two components is achieved through the use of C++/CLI.

## Setup

Open the solution in Visual Studio: `LZWcompressor\LZWcompressor.sln`. Select the `x64` configuration, build the solution and run it.

For easier debugging of the **Core** library, set the **TestCore** project as Startup Project in Visual Studio.
