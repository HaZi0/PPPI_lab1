using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class TeamsJournal
    {
        private List<TeamsJournalEntry> changes = new List<TeamsJournalEntry>();

        public void HandleDevTeamAdded(object source, TeamListHandlerEventArgs args)
        {
            var entry = new TeamsJournalEntry(args.CollectionName, args.ChangeInfo, args.NumElem);
            changes.Add(entry);
        }

        public void HandleDevTeamInserted(object source, TeamListHandlerEventArgs args)
        {
            var entry = new TeamsJournalEntry(args.CollectionName, args.ChangeInfo, args.NumElem);
            changes.Add(entry);
        }

        public override string ToString()
        {
            var result = string.Join(Environment.NewLine, changes);
            return result;
        }
    }
}
