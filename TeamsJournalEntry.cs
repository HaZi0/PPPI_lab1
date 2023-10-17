using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class TeamsJournalEntry
    {
        string CollectionName { get; set; }
        string ChangeInfo { get; set; }
        int NumElem { get; set; }

        public TeamsJournalEntry(string collectionName, string changeInfo, int elementNumber)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            NumElem = elementNumber;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, ChangeInfo: {ChangeInfo}, ElementNumber: {NumElem}";
        }
    }
}
