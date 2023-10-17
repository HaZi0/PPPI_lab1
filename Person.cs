using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class Person: INameAndCopy
    {
        //закрите поле типу string, в якому зберігається ім'я
        private string name;
        //закрите поле типу string, в якому зберігається прізвище
        private string surname;
        //закрите поле типу System.DateTime для дати народження
        private DateTime dataOfBirth;


        //властивість типу string для доступу до поля з ім'ям
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //властивість типу string для доступу до поля з прізвищем
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        //властивість типу DateTime для доступу до поля з датою народження
        public DateTime DateOfBirth
        {
            get { return dataOfBirth; }
            set { dataOfBirth = value; }
        }
        //властивість типу int з контекстами get і set для отримання інформації(get) і зміни(set) року народження в закритому поле типу DateTime, в якому зберігається дата народження
        public int BirthYears
        {
            get { return dataOfBirth.Year; }
            set { dataOfBirth = new DateTime(value, dataOfBirth.Month, dataOfBirth.Day); }
        }


        //конструктор c трьома параметрами типу string, string, DateTime для ініціалізації полів класу
        public Person()
        {
            name = "Боб";
            surname = "Антоніо";
            DateOfBirth = new DateTime(2005, 10, 26);
        }
        //конструктор без параметрів, який ініціалізує всі поля класу деякими значеннями за замовчуванням
        public Person(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }


        //перевизначену (override) версію віртуального методу string ToString() для формування рядка зі значеннями всіх полів класу
        public override string ToString()
        {
            return $"Name: {Name} {Surname} Date of birth: {DateOfBirth}";
        }
        //віртуальний метод string ToShortString(), який повертає рядок, що містить тільки ім'я і прізвище
        public virtual string ToShortString()
        {
            return $"Name: {Name} {Surname}";
        }
        
        //перевизначити (override) віртуальний метод bool Equals (object obj);
        public override bool Equals(object? obj) => obj?.ToString() == ToString();
        
        //визначити операції == і != ; 
        public static bool operator == (Person a, Person b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Person a, Person b)
        {
            return !a.Equals(b);
        }

        //перевизначити (override) віртуальний метод int GetHashCode();
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // визначити віртуальний метод object DeepCopy().
        public object DeepCopy()
        {
            Person copy = (Person)this.MemberwiseClone();
            copy.name = String.Copy(name);
            copy.surname = String.Copy(surname);
            copy.DateOfBirth = new DateTime(this.DateOfBirth.Ticks);
            return copy;
        }
    }
}
