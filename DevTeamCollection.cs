using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class DevTeamCollection
    {
        
        //закрите поле типу System.Collections.Generic.List<DevTeam>;
        private List<DevTeam> devteam = new List<DevTeam>();



        //відкриту автоматичну властивість типу string що містить назву колекції;
        public string CollectionName { get; set; }

        public DevTeamCollection()
        {
            CollectionName = "Test1";
        }
        public DevTeamCollection(string collectionName)
        {
            CollectionName = collectionName;
        }

        //Для подій визначити делегат TeamListHandler із сигнатурою
        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        public event TeamListHandler DevTeamAdded;
        public event TeamListHandler DevTeamInserted;

        /*
         метод void InsertAt (int j, DevTeam dt), який вставляє елемент dt у список List<DevTeam> перед елементом із номером j; 
        якщо у списку немає елемента з номером j, метод додає елемент до кінця списку;
        */
        public void InsertAt(int j, DevTeam dt)
        {
            if (j >= 0 && j <= devteam.Count)
            {
                devteam.Insert(j, dt);
                DevTeamInserted?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "DevTeam Inserted", j));
            }
            else
            {
                AddDevTeams(dt);
                DevTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "DevTeam Added", devteam.Count));
            }
        }

        /*
        індексатор типу DevTeam (з методами get і set) з цілим індексом для 
        доступу до елемента списку List<DevTeam> із заданим номером.
        */
        public DevTeam this[int index]
        {
            get { return devteam[index]; }
            set { devteam[index] = value; }
        }



        /*
        метод void AddDefaults(), за допомогою якого в список List<DevTeam> 
        можна додати деяке число елементів типу DevTeam для ініціалізації
        колекції за замовчуванням; 
        */
        public void AddDefaults()
        {
            DevTeam devteam1 = new DevTeam();
            DevTeam devteam2 = new DevTeam("Pro", "Kopel", 5, new DateTime(2006, 6, 12));
            
            Task task1 = new Task();
            devteam1.AddTasks(task1, task1);
            devteam2.AddTasks(task1, task1, task1);

            devteam.Add(devteam1);
            devteam.Add(devteam2);
            DevTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "DevTeam Added", devteam.Count));
        }

        /*
        метод void AddDevTeams (params DevTeam []) для додавання елементів в
        список List<DevTeam>
        */
        public void AddDevTeams(params DevTeam[] devTeam)
        {
            devteam.AddRange(devTeam);
            DevTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "DevTeam Added", devteam.Count));
        }

        /*
        перевизначену версію віртуального методу string ToString() для
        формування рядка c інформацією про всі елементи списку
        List<DevTeam>, яка містить значення всіх полів, список учасників
        проекту і список завдань для кожного елемента DevTeam;
        */
        public override string ToString()
        {
            string result = "";
            foreach (DevTeam team in devteam)
            {
                result += team.ToString() + "\n";
            }
            return result;
        }

        /*
        віртуальний метод string ToShortString(), який формує рядок з
        інформацією про всі елементи списку List<DevTeam>, що включає
        значення всіх полів, число учасників проекту і число завдань для кожного
        елемента DevTeam, але без списка учасників і списка завдань.
        */
        public virtual string ToShortString()
        {
            string result = "";
            foreach (DevTeam team in devteam)
            {
                result += team.ToShortString() + "\n";
            }
            return result;
        }

        public void SortByRegistrationNumber()
        {
            devteam.Sort();
        }
        public void SortByProjectName()
        {
            devteam.Sort(new DevTeam());
        }
        public void SortByNumberOfTasks()
        {
            devteam.Sort(new DevTeamComparer());
        }
    }
}
