using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel{
    public class Subject{
        public string name = "";
        private readonly Monitor monitor = Monitor.CreateMonitor();

        public Subject(string name){
            this.name = name;
        }

        public Subject(Object systemObject){

            Console.Write("Enter new login: ");
            string? name = Console.ReadLine();

            this.name = name;

            if (User.CheckName(name)){
                Operation rule = monitor.GetRule(Program.currentUser, systemObject);
                monitor.SetRule(this, systemObject, rule);

                User.AddUser(name);
            }
            else{
                Console.WriteLine("User already exist");
            }
        }

        public void Read(Object systemObject){
            monitor.ReadData(this, systemObject);
        }

        public void Write(Object systemObject){
            string? data = Console.ReadLine();
            monitor.WriteData(this, systemObject, data);
        }

        public void Execute(Object systemObject){
            monitor.ExecuteData(this, systemObject);
        }

    }
}
