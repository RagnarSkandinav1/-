﻿using System;

namespace SharedAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : Attribute
    {
        public string Name { get; set; }

        public PluginAttribute(string name)
        {
            Name = name;
        }
    }
}
