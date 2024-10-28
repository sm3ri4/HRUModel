using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel.Commands{
    public class BashCommand : ICommand{
        private readonly Monitor monitor = Monitor.CreateMonitor();
        public void Execute(string[] args){
            if (args.Length > 1 && args[1] != ""){
                string filename = args[1];
                monitor.ExecuteData(Program.currentUser, monitor.GetObject(filename));
                return;
            }

            Console.WriteLine($"User {Program.currentUser.name} hasnt rules or file doesnt exists");
        }
    }
}
