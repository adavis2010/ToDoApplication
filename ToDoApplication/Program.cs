using System;

namespace ToDoApplication {
    class Program {
        static void Main(string[] args) {
            //calling our get string by using static method Cli.GetString
            var answer = Cli.GetString("Enter a string");
            Console.WriteLine($"The answer is {answer}");


        }
    }
}
