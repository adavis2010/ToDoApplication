using System;
using System.Threading.Tasks;
using ToDoLibrary.CControllers;

namespace ToDoApplication {
    class Program {

        ToDosController todoCtrl = null;
        CategoriesController catCtrl = null;

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
            Cli.DisplayLine("Called CreateTodo()");
            Cli.DisplayLine();
            var categories = await catCtrl.GetAll();
            var todo = new ToDo();
            todo.Id = 0;
            todo.Description = Cli.GetString("Enter description");
            todo.Due = Cli.GetDateTime("Enter due date");
            todo.Note = Cli.GetString("Enter note");
            Cli.DisplayLine("Categories:");
            foreach (var c in categories) {
                Cli.DisplayLine("{c.Id} : {c.Name}");
            }
            todo.CategoryId = Cli.GetInt("Select category");
            var newTodo = await todoCtrl.Create(todo);
            Cli.DisplayLine();
            Cli.DisplayLine("Added...");
            Cli.DisplayLine();

        }
        //Update / Change
        async Task UpdateTodo() {
            Cli.DisplayLine();
            Cli.DisplayLine("List of todo items");
            Cli.DisplayLine();
            var todos = await todoCtrl.GetAll();
            Console.WriteLine($"{todo}");
            foreach (var todo in todos) {
                Console.WriteLine($"{todo}");
            }
            Cli.DisplayLine();
            var id = Cli.GetInt("Enter todo id");
            Cli.DisplayLine();
            var todo1 = await todoCtrl.GetByPk(id);
            var chgDescription = Cli.GetBoolean("todo1.Description?");
            if (chgDescription) {
                Cli.DisplayLine($"Description - old value: {todo1.Description}");
                todo1.Description = Cli.GetString($"Description - new value:");

            }

            var chgDue = Cli.GetBoolean("Change due date?");
            if (chgDue) {
                Cli.DisplayLine($"Due date - old value: {todo1.Due}");
                todo1.Description = Cli.GetString($"Description - new value:");
            }
            var chgNote = Cli.GetBoolean("Change Note?");
            if (chgNote) {
                Cli.DisplayLine($"Due date - old value: {todo1.Note}");
                todo1.Note = Cli.GetString($"Note - new value:");
            }
            await todoCtrl.Change(todo1);

            async Task Run() { }
            todoCtrl = new TodosController();
            catCtrl = new CategoriesController();
            Cli.DisplayLine("Todo Application");
            var option = DisplayMenu();
            while (option != 0) {
                switch (option) {
                    case 1:
                        await ListAllToDos();
                        break;
                    case 2:
                        await CreateToDo();
                        break;
                    case 3:
                        await UpdateTodo();
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
            Cli.DisplayLine("2 : Add todo");
            Cli.DisplayLine("3: Update todo");
            Cli.DisplayLine("0: Exit");
            var option = Cli.GetInt("Enter menu number");
            return option;
        }
        static async Task Main(string[] args) {
            var pgm = new Program();
            await pgm.Run();







        }
    }
}
