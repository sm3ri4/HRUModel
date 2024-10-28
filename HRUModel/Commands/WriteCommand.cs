using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel.Commands{
    public class WriteCommand:ICommand{
        private readonly Monitor monitor = Monitor.CreateMonitor();

        public void Execute(string[] args){

            if (args.Length > 1){

                Object? systemObject = monitor.GetObject(args[1]);

                if (systemObject != null){
                    Console.Write("Enter data: ");

                    string data = Console.ReadLine();

                    monitor.WriteData(Program.currentUser, systemObject, data);
                    return;
                }
            }

            Console.WriteLine("File doesnt exist");
        }
    }
}
