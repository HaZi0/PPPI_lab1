using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class Team: INameAndCopy,IComparable
    {
        //захищене (protected) поле типу string з назвою організації
        protected string name;
        //захищене поле типу int – реєстраційний номер.
        protected int regNum;


        //властивість типу string для доступу до поля з назвою організації;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /*
        властивість типу int для доступу до поля з номером реєстрації; в контексті
        set кинути виключення, якщо значення, яке привласнюється менше або 
        дорівнює 0; при створенні об'єкта-виключення використовувати один із 
        визначених у бібліотеці CLR класів-виключень, ініціалізувати 
        виключення за допомогою конструктора з параметром типу string.
         */
        public int RegNum
        {
            get { return regNum; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("regNum", "Registration number must be greater than 0.");
                }
                regNum = value;
            }
        }

        //конструктор без параметрів для ініціалізації за замовчуванням;
        public Team()
        {
            Name = "Monia";
            RegNum = 1;
        }
        //конструктор з параметрами типу string і int для ініціалізації полів класу;
        public Team(string name, int regNum)
        {
            Name = name;
            RegNum = regNum;
        }

        //визначити віртуальний метод object DeepCopy();
        public object DeepCopy()
        {
            Team copy = (Team)this.MemberwiseClone();
            copy.name = String.Copy(name);
            copy.regNum = this.regNum;
            return copy;
        }
        //віртуальний метод string ToString() для формування рядка зі значеннями всіх полів класу.
        public override string ToString()
        {
            return $"Name: {name} Registration number: {regNum}";
        }

        //перевизначити віртуальний метод virtual bool Equals (object obj)
        public override bool Equals(object? obj) => obj?.ToString() == ToString();

        //визначити операції == і != так, щоб рівність об'єктів типу Team трактувалося як збіг всіх даних об'єктів, а не посилань на об'єкти Team
        public static bool operator ==(Team a, Team b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Team a, Team b)
        {
            return !a.Equals(b);
        }

        //перевизначити віртуальний метод int GetHashCode();
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /*
        У нову версію класу Team додати реалізацію інтерфейсa System.IComparable
        для порівняння об'єктів Team за номером реєстрації.
        */
        int IComparable.CompareTo(object obj)
        {
            Team temp = obj as Team;
            if(temp != null)
            {
                return this.RegNum.CompareTo(temp.RegNum);
            }
            else
            {
                throw new ArgumentException("Parameter is not a Team!");
            }
        }
    }
}
