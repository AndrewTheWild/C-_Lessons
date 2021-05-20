using Laba1.Event;
using Laba1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba1.Service
{
    public class Listener
    {
        private List<ListEntry> listChanges { get; set; } = new List<ListEntry>();
        public void OnMagazineAdded(object sender, MagazineListHandlerEventArgs args)
            =>listChanges
            .Add(new ListEntry(args.NameCollection,
                               args.InformationAboutCollection, 
                               args.NumberChangeElement));
        public void OnMagazineReplaced(object sender, MagazineListHandlerEventArgs args)
            => listChanges
            .Add(new ListEntry(args.NameCollection,
                               args.InformationAboutCollection,
                               args.NumberChangeElement));
        public override string ToString()
        {
            var info ="\n";
            listChanges.ForEach(item => info += item.ToString() + "\n");
            return info;
        }
    }
}
