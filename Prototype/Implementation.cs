using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    /// <summary>
    /// Prototype
    /// </summary>

    [Serializable]
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract Person Clone(bool deepClone);
    }

    /// <summary>
    /// ConcretePrototype1
    /// </summary>
    [Serializable]
    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }
        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Manager>(objectAsJson);
            }
            return (Person)MemberwiseClone();
        }
    }

    /// <summary>
    /// ConcretePrototype2
    /// </summary>
    [Serializable]
    public class Employee : Person
    {
        public Manager Manager { get; set; }    
        public override string Name { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }
        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }
            return (Person)MemberwiseClone();
        }
    }
}
