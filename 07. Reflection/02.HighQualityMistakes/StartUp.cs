﻿using System;

class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);
    }
}