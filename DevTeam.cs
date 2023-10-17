using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class DevTeam: Team,INameAndCopy,IComparer<DevTeam>
    {
        //закрите поле типу string з назвою проекту;
        private string nameProject;
        //закрите поле типу DateTime з інформацією про дедлайн проекту;
        private DateTime deadline;
        //закрите поле типу System.Collections.Generic.List<Person> зі списком учасників проекту(об'єктів типу Person)
        private List<Person> person;
        //закрите поле типу System.Collections.Generic.List<Task> для списку завдань(об'єктів типу Task).
        private List<Task> task;


        //властивість типу string для доступу до поля з назвою проекту
        public string NameProject
        {
            get { return nameProject; }
            set { nameProject = value; }
        }
        //властивість типу DateTime для доступу до поля з інформацією про дедлайн проекту
        public DateTime Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }
        /*
        властивість типу Team; контекст get властивості повертає об'єкт типу
        Team, дані якого збігаються з даними підоб’єкту базового класу, контекст
        set присвоює значення полів з підоб’єкту базового класу;
        */
        public Team BaseTeam
        {
            get{return new Team(Name,RegNum);}
            set
            {
                Name = value.Name;
                RegNum = value.RegNum;
            }
        }
        //властивість типу System.Collections.Generic.List<Person> для доступу до поля зі списком учасників проекту;
        public List<Person> Person
        {
            get { return person; }
            set { person = value; }
        }
        //властивість типу System.Collections.Generic.List<Task> для доступу до поля зі списком завдань;
        public List<Task> Task
        {
            get { return task; }
            set { task = value; }
        }
        

        //конструктор без параметрів для ініціалізації за замовчуванням;
        public DevTeam()
        {
            NameProject = "Water";
            DateTime now = DateTime.Now;
            DateTime Deadline = new DateTime(now.Year, now.Month, now.Day);
            person = new List<Person>();
            task = new List<Task>();
        }
        //конструктор з параметрами типу string, string, int, DateTime для ініціалізації відповідних полів класу;
        public DevTeam(string nameP, string nameC, int rnum, DateTime DeadLine): base(nameC, rnum)
        {
            NameProject = nameP;
            Deadline = DeadLine;
            person = new List<Person>();
            task = new List<Task>();
        }


        //властивість типу Task (тільки з контекстом get), яке повертає посилання на завдання з найвищим пріоритетом; якщо список завдань порожній, властивість повертає значення null;
        public Task HighestPriority
        {
            get
            {
                if (task == null || task.Count == 0)
                {
                    return null;
                }
                Task highestPriority = task[0];
                for (int i = 0; i < task.Count; i++)
                {
                    if (task[i].ValuePriority < highestPriority.ValuePriority)
                    {
                        highestPriority = task[i];
                    }
                }
                return highestPriority;
            }
        }
        
        
        //метод void AddTasks (params Task[] ) для додавання елементів в список завдань;
        public void AddTasks(params Task[] newListTask)
        {
            task.AddRange(newListTask);
            /*
            foreach (Task tasks in newListTask)
            {
                task.Add(tasks);
            }
            */
            
        }
        //метод void AddMembers (params Person[]) для додавання елементів в список учасників проекту;
        public void AddMembers(params Person[] newListPerson)
        {
            person.AddRange(newListPerson);
            /*
            foreach (Person persons in newListPerson)
            {
                person.Add(persons);
            }
            */
        }
        

        //визначити віртуальний метод object DeepCopy();
        public DevTeam DeepCopy()
        {
            DevTeam copy = (DevTeam)this.MemberwiseClone();
            copy.NameProject = String.Copy(NameProject);
            copy.Name = String.Copy(Name);
            copy.RegNum = this.RegNum;
            copy.Deadline = new DateTime(deadline.Ticks);
            copy.person = new List<Person>();
            foreach (Person persons in this.person)
            {
                Person personCopy = new Person();
                personCopy.Name = persons.Name;
                personCopy.Surname = persons.Surname;
                personCopy.DateOfBirth = persons.DateOfBirth;
                copy.person.Add(personCopy);
            }
            copy.task = new List<Task>();
            foreach (Task tasks in this.task)
            {
                copy.task.Add(new Task(tasks.Name, tasks.User, tasks.ValuePriority));
            }

            return copy;
        }



        /*
        перевизначена версія віртуального методу string ToString() для
        формування рядка зі значеннями всіх полів класу, разом зі списком
        завдань та списком учасників проекту
        */
        public override string ToString()
        {
            string tasks = "";
            string persons = "";
            foreach (var task2 in task)
            {
                tasks += task2.ToString() + "\n";
            }
            foreach (var person2 in person)
            {
                persons += person2.ToString() + "\n";
            }
            return $"Project Name: {NameProject}\nOrganization Name: {Name}\nRegistration Number: {RegNum}\nDeadline: {Deadline}\nTasks:\n{tasks}\nPersons:\n{persons}";
        }
        /*
        метод string ToShortString(), який формує рядок зі значеннями всіх полів 
        класу без списку завдань та списку учасників проекту.
        */
        public virtual string ToShortString()
        {
            return $"Project Name: {nameProject}\nOrganization Name: {Name}\nRegistration Number: {RegNum}\nDeadline: {Deadline}";
        }


        /*
        ітератор для послідовного перебору учасників проекту (об'єктів типу Person), що не мають завдань;
        */
        public IEnumerable<Person> GetPersonTask()
        {
            //return person.GetEnumerator();

            foreach (Person person2 in person)
            {
                int x = 0;
                foreach (Task task2 in task)
                {
                    if (person2.ToString() == task2.User.ToString())
                    {
                        x++;
                    }
                }
                if (x == 0)
                {
                    yield return person2;
                }
            }
        }
        //public IEnumerator<Person> GetEnumerator()
        //{
        //    //return person.GetEnumerator();

        //    foreach (Person person2 in person)
        //    {
        //        int x = 0;
        //        foreach (Task task2 in task)
        //        {
        //            if (person2.ToString() == task2.User.ToString())
        //            {
        //                x++;
        //            }
        //        }
        //        if (x == 0)
        //        {
        //            yield return person2;
        //        }
        //    }

        //}
        /*
         ітератор з параметром типу int для перебору учасників, що мають 
         завдання з пріоритетом p, в якому p передається через параметр ітератора.
        */
        public IEnumerable<Person> GetPersonPriority(int i)
        {
            foreach (Task task2 in task)
            {
                if((int)task2.ValuePriority == i)
                {
                    yield return task2.User;
                }
            }
        }

        /*
        У нову версію класу DevTeam додати реалізацію інтерфейсa
        System.Collections.Generic.IComparer<DevTeam> для порівняння об'єктів 
        DevTeam за назвою проекту.
        */
        int IComparer<DevTeam>.Compare(DevTeam x, DevTeam y)
        {
            return string.Compare(x.NameProject, y.NameProject);
        }
    }
}
