using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab_2_1.Task;

namespace lab_2_1
{
    internal class TestCollections
    {
        private List<Team> teams;
        private List<string> teamName;
        private Dictionary<Team, DevTeam> teamDictionary;
        private Dictionary<string, DevTeam> nameDictionary;


        /*
        статичний метод з одним цілочисельним параметром типу int, який 
        повертає посилання на об'єкт типу DevTeam і використовується для 
        автоматичної генерації елементів колекцій;
        */
        public static DevTeam GenerateDevTeam(int count)
        {
            DevTeam devTeam = new DevTeam("Project" + count,"Compani"+count, count+1,new DateTime(2000,10,01));
            devTeam.AddTasks(new Task("Task " + (count + 1),new Person(),Priority.High));
            
            return devTeam;
        }


        /*
        конструктор c параметром типу int (число елементів в колекціях) для 
ав      томатичного створення колекцій із заданим числом елементів;
        */
        public TestCollections(int count)
        {
            teams = new List<Team>(count);
            teamName = new List<string>(count);
            teamDictionary = new Dictionary<Team, DevTeam>(count);
            nameDictionary = new Dictionary<string, DevTeam>(count);

            for(int i = 0;i < count; i++)
            {
               
                DevTeam devTeam = GenerateDevTeam(i);
                string nameP = devTeam.BaseTeam.ToString();
                teams.Add(devTeam.BaseTeam);
                teamName.Add(nameP);
                teamDictionary.Add(devTeam.BaseTeam, devTeam);
                nameDictionary.Add(nameP, devTeam);
            }

        }
        /*
        private List<Team> teams;
        private List<string> teamName;
        private Dictionary<Team, DevTeam> teamDictionary;
        private Dictionary<string, DevTeam> nameDictionary;
         * */
        public void TestSearch(int i)
        {
            Stopwatch stopwatch = new Stopwatch();
            bool result = false;

            DevTeam devTeamrandom = GenerateDevTeam(i);
            Team searchTeam = devTeamrandom.BaseTeam;
            string searchString = devTeamrandom.BaseTeam.ToString();

            stopwatch.Start();
            result = teams.Contains(searchTeam);
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks}, Found: {result}, List<Team>");

            stopwatch.Restart();
            result = teamName.Contains(searchString);
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks}, Found: {result}, List<string>");
            stopwatch.Restart();
            result = teamDictionary.ContainsKey(searchTeam);
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks}, Found: {result}, List<Team,DevTeam>(by key)");

            stopwatch.Restart();
            result = nameDictionary.ContainsKey(searchString);
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks}, Found: {result}, List<string,DevTeam>(by key)");
            stopwatch.Restart();
            result = nameDictionary.ContainsValue(devTeamrandom);
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks}, Found: {result}, List<string,DevTeam>(by value)");

        }
    }
}
