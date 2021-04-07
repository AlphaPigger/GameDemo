using DemoStartUp.Domain;
using System;

namespace DemoStartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var startupInstance = new StartUp();
            startupInstance.Start();
        }
    }
}
