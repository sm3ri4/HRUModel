using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel.Commands{
    public class CatCommand : ICommand{
        private readonly Monitor monitor = Monitor.CreateMonitor();

        public void Execute(string[] args){
            if(args.Length > 1){
                string data = monitor.ReadData(Program.currentUser, monitor.GetObject(args[1]));
                Console.WriteLine(data);
            }
        }
    }
}
