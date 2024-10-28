using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRUModel{
    public class Monitor{

        private Dictionary<(Subject, Object), Operation> _matrix;
        private static Subject root = new Subject("root");
        private Object _rootObject = new Object("root");
        private static Monitor? Instance = new Monitor();
        
        private Monitor() {
            this._matrix = new Dictionary<(Subject, Object), Operation>() { 
                { (root, _rootObject), Operation.ReadWriteExecute } 
            };
        }

        public static Monitor CreateMonitor(){
            Instance ??= new Monitor();
            return Instance;
        }

        public static Subject GetRoot(){
            root ??= new Subject("root");
            return root;
        }

        public bool CheckRule(Subject subject, Object systemObject, Operation operation){
            Operation rule = GetRule(subject, systemObject);
            return (((int)rule & (int)operation) == (int)operation);
        }

        public void SetRule(Subject subject, Object systemObject, Operation rule){
            this._matrix.Add((subject, systemObject), rule);
        }

        public Operation GetRule(Subject subject, Object systemObject){
            bool keyExist = this._matrix.TryGetValue((subject, systemObject), out Operation value);

            if (keyExist)
                return value;
            else
                return Operation.NoRule;
        }

        public string ReadData(Subject subject, Object systemObject){
            if (CheckRule(subject, systemObject, Operation.Read))
                return systemObject.GetData();
            return $"Subject {subject.name} cant read this file";
        }

        public void WriteData(Subject subject, Object systemObject, string data){

            if (GetRule(subject, systemObject) == Operation.NoRule){
                Console.WriteLine("User hasnt rules");
                return;
            }

            if (CheckRule(subject, systemObject, Operation.Write))
                systemObject.SetData(data);

        }

        public void ExecuteData(Subject subject, Object systemObject){
            if (CheckRule(subject, systemObject, Operation.Execute)){
                systemObject.ExecuteData();
                return;
            }
            Console.WriteLine($"User {subject.name} cant execute this file or file doesnt exists");
        }

        public List<string> LsFiles(string? args = null){
            if (args != null && args == "-l")
                return this._matrix.Select(x => $"{x.Key.Item1.name}    {x.Key.Item2.name}  {x.Value}").ToList();

            return this._matrix.Select(x => x.Key.Item2.name).Distinct().ToList();
        }

        public void ChangeMode(Subject subject, Object systemObject, Operation rule){
            if (systemObject != null)
                this._matrix[(subject, systemObject)] = rule;
        }

        public Subject GetSubject(string name){
            return this._matrix.Keys.Select(x => x.Item1).Distinct().Where(x => x.name == name).First();
        }

        public bool AuthUser(string name){
            return User.CheckName(name);
        }

        public Object? GetObject(string name){
            return this._matrix.Keys.Select(x => x.Item2).Distinct().Where(x => x.name == name).FirstOrDefault();
        }

        public bool CheckFilenameExist(string name){
            return _matrix.Keys.Select(x => x.Item2).Distinct().Any(x => x.name == name);
        }
    }

}
