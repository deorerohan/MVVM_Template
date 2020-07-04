# MVVM_Template

This is MVVM template written in .NET core for reference.
This code in mainly written in Linux machine and then will be validated on Windows.

Project MVVM_Template is View.
Project ViewModel and Model represent as they are.

Singleton design pattern is implemented for ModelData class.
It's very simple design pattern. We want only one instance of ModelData which is representing bank model data. So that there is no duplicate bank data even by accident.

UIService is created for providing functionalities required for ViewModel.
So later if we have changed view from Console application to WPF or WebApplication, if we implement UI service properly we will have almost all functionalities like those were implemented in Console application.

## Random useful tips

- For comments 'C# XML Documentation Comments' extension is very useful.
- C# extension from Microsoft is very important for development work.
- For spell checking 'Code Spell Checker' extension is useful.
- Write comments for functions and classes while creating, you will never get time later just to write comments.
