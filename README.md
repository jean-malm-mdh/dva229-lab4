# DVA229 - Lab 4
In this lab, you will make a small calculator application with a GUI. We have provided you a start-off point in the form of a code skeleton.

There are two versions of the code skeleton, primarily to support setups that do not support WinForms anymore. 

At the moment, the WinForms one is still the primary choice w.r.t. support, and the programming model is what is covered in the lecture on reactive programming.

## Windows/Linux
Both lab skeletons should work. For Linux there is a shell script that can be used to build and run the application.

## MacOS
As WinForms is no longer supported on Mac, there is an alternative code skeleton provided based on the Avalonia UI framework. 
It uses a model-view-update pattern similar to the model-view-viewmodel design pattern. 

Note: Less support can be provided for this framework from our side, so keep that in mind when selecting the final target.

# Setup
Ideally, the projects should run by default. However, the .NET framework chosen for the WinForms version is not necessarily part of newer installations of .NET by default. 
Hence you may need to change the framework in the project settings. .NET framework `4.7.2` has been reported to work fine.

Alternatively, you may of course just remove and re-create the solution and project file using your existing templates. The instructions should be analogous to those for Lab 3.
