using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_2_1
{
    internal class Task: INameAndCopy
    {
        //Визначити перелічуваний тип (enum) Priority зі значеннями High, Medium, Low
        public enum Priority
        {
            High = 2,
            Medium = 1,
            Low = 0
        }


        //властивість типу string для назви завдання
        public string Name { get; set; }
        //властивість типу Person для інформації про виконавця
        public Person User { get; set; }
        //властивість типу Priority для пріоритету
        public Priority ValuePriority { get; set; }


        //конструктор без параметрів, який ініціалізує всі властивості класу деякими значеннями за замовчуванням
        public Task()
        {
            Name = "Potap";
            User = new Person();
            ValuePriority = Priority.Low;
        }
        //конструктор з параметрами типу string, Person, Priority для ініціалізації всіх властивостей класу
        public Task(string name, Person user, Priority valuePriority)
        {
            Name = name;
            User = user;
            ValuePriority = valuePriority;
        }
        //перевизначену(override) версію віртуального методу string ToString() для формування рядка зі значеннями всіх полів класу
        public override string ToString()
        {
            return $"Name of task: {Name} User: {User.ToString()} Priority: {ValuePriority}";
        }
        //У класі Task визначити віртуальний метод object DeepCopy().
        public object DeepCopy()
        {
            Task copy = (Task)this.MemberwiseClone();
            copy.Name = String.Copy(Name);
            copy.User = (Person)this.User.DeepCopy();
            copy.ValuePriority = this.ValuePriority;
            return copy;
        }
    }
}
