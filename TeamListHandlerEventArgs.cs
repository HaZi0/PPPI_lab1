using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    internal class TeamListHandlerEventArgs: System.EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeInfo { get; set; }
        public int NumElem { get; set; }

        public TeamListHandlerEventArgs(string collectionName, string changeInfo, int elementNumber)
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
