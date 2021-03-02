using System;

namespace ToDoApplication {
    class Program {
        static void Main(string[] args) {
            //calling our get string by using static method Cli.GetString
            var aStr = Cli.GetString("Enter a string");
            var anInt = Cli.GetInt("Enter an int");
            var aDate = Cli.GetDateTime("Enter a valid date");
            var aDate2 = Cli.GetDateTime("Just press enter");

            Console.WriteLine($"{aStr}");
            Console.WriteLine($"{anInt}");
            Console.WriteLine($"{aDate} [{aDate2}]");




        }
    }
}
