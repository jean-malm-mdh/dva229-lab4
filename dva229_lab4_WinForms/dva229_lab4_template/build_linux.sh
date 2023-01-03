#!/bin/bash

#This script invokes the fsharp compiler to build the lab skeleton, and move it and all .dll files to the bin folder
#You can uncomment the final line to run the program automatically as part of the script

#Set path variables to Async library used by lab skeleton
#Note: You will have to edit at least the first one if you are running this script from some other location
FSHARPX_DLL_PATH="../packages/FSharpx.Async.1.13.2/lib/net45"
FSHARPX_DLL_NAME="FSharpx.Async.dll"

#Make bin directory (silencing complaints if it already exists)
mkdir "./bin" > /dev/null 2>&1

#Compile the file. NOTE: if you add code files, they need to be added to list. 
#Due to the dependencies order, Main.fs needs to be at the end of the list!
fsharpc --lib:$FSHARPX_DLL_PATH --reference:$FSHARPX_DLL_NAME Gui.fs Main.fs

#Move the required files to bin directory
cp --no-clobber "./FSharp.Core.dll" "./bin/FSharp.Core.dll"
cp --no-clobber "$FSHARPX_DLL_PATH/$FSHARPX_DLL_NAME" "./bin/$FSHARPX_DLL_NAME"
mv "./Main.exe" "./bin/Lab4.exe"

echo "OK! You should be able to start the program by typing 'mono ./bin/Lab4.exe'"
#mono ./bin/Lab4.exe