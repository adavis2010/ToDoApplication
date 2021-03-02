using System;

namespace ToDoApplication {
    class Program {

        void ListAllToDos() {
            Cli.DisplayLine("Called ListAllTodos()'");
        }
        //GetAll

        void Run() {
            Cli.DisplayLine("ToDo Application");
            var option = DisplayMenu();
            while (option != 0) {
                switch (option) {
                    case 1:
                        ListAllToDos();
                        break;
                    case 0:
                        return;
                    default:
                        Cli.DisplayLine("Invalid menu option");
                        break;
                }
                option = DisplayMenu();
            }
        }
        int DisplayMenu() {
            Cli.DisplayLine("Menu");
            Cli.DisplayLine("1 : List all todos");
            Cli.DisplayLine("0 : Exit");
            var option = Cli.GetInt("Enter menu number");
            return option;
        }
        static void Main(string[] args) {
            var pgm = new Program();
            pgm.Run();







        }
    }
}
