using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRUModel.Commands;

namespace HRUModel.Factory{
    public class CommandFactory{
        public ICommand GetCommand(string command){
            switch (command){
                case "chmod": return new ChmodCommand();
                case "touch": return new TouchCommand();
                case "ls": return new LsCommand();
                case "cat": return new CatCommand();
                case "write": return new WriteCommand();
                case "bash": return new BashCommand();
                default: return null;
            }
        }
    }
}
