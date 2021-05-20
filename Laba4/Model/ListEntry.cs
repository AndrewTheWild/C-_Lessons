using System;
using System.Collections.Generic;
using System.Text;

namespace Laba1.Model
{
    public class ListEntry
    {
        public string NameCollectionWasEvent { get; set; }
        public string InformationAboutEvent { get; set; }
        public int NumberItem { get; set; }
        public ListEntry() { }
        public ListEntry(string nameCollectionWasEvent,
                                            string informationAboutEvent,
                                            int numberItem)
        {
            NameCollectionWasEvent = nameCollectionWasEvent;
            InformationAboutEvent = informationAboutEvent;
            NumberItem = numberItem;
        }

        public override string ToString()
            => $"{NameCollectionWasEvent}" +
            $"\n{InformationAboutEvent}" +
            $"\nChange element with index: {NumberItem}";
    }
}
