using System;

namespace CmdLineParser
{
    class Program
    {
        static void Main()
        {
            string commandLine1 = "-b -i 42 -s Some_string";
            string[] commandLine2 = { "/i", "42", "/s", "Some string" };
            var parser = new Args("b,i#,s*", commandLine1.Split(' '));

            Console.WriteLine("Boolean (b) value: {0}", parser.GetBool('b'));
            Console.WriteLine("Integer (i) value: {0}", parser.GetInt('i'));
            Console.WriteLine("String (s) value:  {0}", parser.GetString('s'));

            Console.WriteLine("---------------------");
            parser = new Args("b,i#,s*", commandLine2);

            Console.WriteLine("Boolean (b) value: {0}", parser.Has('b') ? parser.GetBool('b').ToString() : "no value");
            Console.WriteLine("Integer (i) value: {0}", parser.GetInt('i'));
            Console.WriteLine("String (s) value:  {0}", parser.GetString('s'));
        }
    }
}
