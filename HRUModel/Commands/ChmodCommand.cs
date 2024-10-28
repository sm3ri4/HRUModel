using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel.Commands{
    public class ChmodCommand:ICommand{

        private readonly Monitor monitor = Monitor.CreateMonitor();

        public void Execute(string[] args){

            if (args.Length > 3 && Program.currentUser == Monitor.GetRoot()){

                bool inRule = int.TryParse(args[2], out int result);
                Object? systemObject = monitor.GetObject(args[3]);
                Operation operation = new Operation().Parse(int.Parse(args[2]));
                Subject subject = monitor.GetSubject(args[1]);
                

                if (inRule && systemObject != null){
                    monitor.ChangeMode(subject, systemObject, operation);
                    return;
                }

                Console.WriteLine($"File doesnt exist");
                return;
            }

            Console.WriteLine($"User {Program.currentUser.name} hasnt rules or file doesnt exists");
        }

    }
}
