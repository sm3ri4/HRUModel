using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel{
    
    public class Object{
        public string name;
        private string data;

        public Object(string name, string data = ""){
            this.name = name;
            this.data = data;
        }

        public void SetData(string data) {
            this.data = data;
        }

        public string GetData() {
            return this.data;
        }

        public Subject ExecuteData(){
            return new Subject(this);
        }

    }
}
