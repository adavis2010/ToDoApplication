using System;
using System.Threading.Tasks;

namespace ToDoApplication {
    class Program {

        TodosController todoCtrl = null;
        CCategoriesController catCtrl = null;

        //Get All
        async Task ListAllToDos() {
            Cli.DisplayLine("Called ListAllTodos()'");
            var todos = await todoCtrl.GetAll();
            Console.WriteLine($"{ToDo.Header()}");
            foreach (var todo in todos) {
                Console.WriteLine($"{todo}");
            }
            Cli.DisplayLine();
            Cli.DisplayLine("Finished");
            Cli.DisplayLine();
        }

        //Create
        async Task CreateToDo() {
            Cli.DisplayLine("Called CreateTodo");
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
