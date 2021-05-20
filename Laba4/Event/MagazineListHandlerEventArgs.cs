using System;
using System.Collections.Generic;
using System.Text;

namespace Laba1.Event
{
    public class MagazineListHandlerEventArgs:EventArgs
    {
        public string NameCollection { get; set; }
        public string InformationAboutCollection { get; set; }
        public int NumberChangeElement { get; set; }
        public MagazineListHandlerEventArgs(string nameCollection, 
                                            string informAboutCollection, 
                                            int numberChangeElement)
        {
            NameCollection = nameCollection;
            InformationAboutCollection = informAboutCollection;
            NumberChangeElement = numberChangeElement;
        }

        public override string ToString()
            => $"{NameCollection}" +
            $"\n{InformationAboutCollection}" +
            $"\nChange element with index: {NumberChangeElement}";
    }
}
