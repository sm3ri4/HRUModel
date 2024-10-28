using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel.Commands{
    public class TouchCommand : ICommand{

        private readonly Monitor monitor = Monitor.CreateMonitor();

        public void Execute(string[] args){
            if (args.Length > 1 && args[1] != "" && !monitor.CheckFilenameExist(args[1])){
                string filename = args[1];
                monitor.SetRule(Program.currentUser, new Object(filename), Operation.NoRule);
                return;
            }

            Console.WriteLine($"File already exist or name isnt in naming rules");
        }
    }
}
