using HRUModel.Factory;
using HRUModel.Commands;

namespace HRUModel{
    public class Program{

        public static Subject currentUser = new("");
        private readonly static Monitor monitor = Monitor.CreateMonitor();
        private static readonly string _commandsPath = "C:\\Users\\Eugene\\source\\repos\\HRUModel\\HRUModel\\Home\\commands.cfg";


        static void Main(string[] args) {
            while (true) {
                Console.Write("Login: ");
                string? login = Console.ReadLine();

                if (!monitor.AuthUser(login)) {

                    Console.WriteLine($"Login Successed {login}\n");
                    currentUser = monitor.GetSubject(login);
                    bool exit = false;

                    while (!exit) {
                        Console.Write($"\n{login}@HRU:$ ");

                        string? fullCommand = Console.ReadLine();
                        string? command = fullCommand?.Split(' ')[0];

                        Console.WriteLine();

                        switch (command) {
                            case "chmod":
                            case "touch":
                            case "ls":
                            case "cat":
                            case "write":
                            case "bash": {
                                    CommandFactory factory = new CommandFactory();
                                    ICommand currentCommand = factory.GetCommand(command);
                                    currentCommand.Execute(fullCommand.Split(' '));
                                    break;
                                }

                            case "exit": {
                                    Console.Clear();
                                    exit = true;
                                    break;
                                }

                            case "clear": {
                                    Console.Clear();
                                    break;
                                }

                            case "man": {
                                    Console.Write(string.Join("\n", File.ReadAllLines(_commandsPath)));
                                    Console.WriteLine();
                                    break;
                                }

                            default: {
                                    Console.WriteLine($"Command '{fullCommand}' not found");
                                    break;
                                }
                        }
                    }
                }

                else {
                    Console.WriteLine($"User '{login}' not found\n");
                }
            }
        }
    }

    public class User{
        private static string _passwdPath = "C:\\Users\\Eugene\\source\\repos\\HRUModel\\HRUModel\\Home\\passwd.cfg";
        
        public static bool CheckName(string name){
            return GetUsers.Where(x => x == name).Count() == 0;
        }

        public static void AddUser(string name){
            File.AppendAllText(_passwdPath, "\n" + name);
        }

        public static string[] GetUsers{
            get{
                return File.ReadAllLines(_passwdPath);
            }
        }
    }

    public enum Operation{
        NoRule = 0,
        Execute = 1,
        Write = 2,
        WriteExecute = 3,
        Read = 4,
        ReadExecute = 5,
        ReadWrite = 6,
        ReadWriteExecute = 7
    }

    public static class OperationExtension{
        public static Operation Parse(this Operation operation, int rule) {
            if (rule > (int)Operation.ReadWriteExecute || rule < (int)Operation.NoRule)
                return operation;

            return (Operation)rule;
        }
    }
}

