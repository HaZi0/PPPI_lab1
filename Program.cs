using lab_2_1;
using Task = lab_2_1.Task;

DevTeamCollection collection = new DevTeamCollection("MyCollection");
DevTeamCollection collection2 = new DevTeamCollection("MyCollection2");

TeamsJournal journal = new TeamsJournal();
TeamsJournal journal2 = new TeamsJournal();

collection.DevTeamAdded += journal.HandleDevTeamAdded;
collection.DevTeamInserted += journal.HandleDevTeamInserted;

collection.DevTeamAdded += journal2.HandleDevTeamAdded;
collection2.DevTeamAdded += journal2.HandleDevTeamAdded;

collection.AddDefaults();
collection.AddDevTeams(new DevTeam(), new DevTeam());
collection.InsertAt(1, new DevTeam());

collection2.AddDevTeams(new DevTeam(), new DevTeam(), new DevTeam());
collection2.AddDevTeams(new DevTeam(), new DevTeam(), new DevTeam());
collection2.InsertAt(2, new DevTeam());

Console.WriteLine("Journal Entries:");
Console.WriteLine(journal);

Console.WriteLine("Journal Entries2:");
Console.WriteLine(journal2);