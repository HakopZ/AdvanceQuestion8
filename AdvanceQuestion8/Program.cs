using System;

namespace AdvanceQuestion8
{
    class Program
    {
        enum Test
        {
            One,
            Two,
            Three
        }
        static void Main(string[] args)
        {

            CircularEnum<Test> temp = Test.One;
            temp+= -2;
            Console.WriteLine("Hello World!");
        }
    }
}
