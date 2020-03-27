using System;

namespace AzureLab.Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            IProcessor processor = new Processor();

            processor.Test();
        }
    }
}
