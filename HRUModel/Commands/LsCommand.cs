using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel.Commands{
    public class LsCommand: ICommand{
        private readonly Monitor monitor = Monitor.CreateMonitor();

        public void Execute(string[] args){
            int argsCount = args.Length;
            List<string> files = new List<string>();

            if (argsCount == 1)
                files = monitor.LsFiles();

            if (argsCount > 1 && args[1] == "-l")
                files = monitor.LsFiles("-l");

            Console.WriteLine(string.Join("\n", files));
        }
    }
}
