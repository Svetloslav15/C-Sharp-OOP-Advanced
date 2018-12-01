﻿using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    public string Name { get; private set; }
    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }
}