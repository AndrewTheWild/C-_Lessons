using System;
using System.Collections.Generic;
using System.Text;

namespace Laba1.Model
{
    public class Edition
    {
        protected string titleEdition;
        protected DateTime releaseDate;
        protected int edition;

        public string TitleEdition { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int EditionCount 
        { 
            get => edition;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value less than 0");
                }
                edition = value;
            }
        }
        public Edition() : this("Default", DateTime.Now, 1) { }

        public Edition(string title, DateTime release, int edition)
        {
            TitleEdition = title;
            ReleaseDate = release;
            EditionCount = edition;
        }

        public virtual object DeepCopy
            => new Edition(TitleEdition, ReleaseDate, EditionCount);

        public override bool Equals(object obj)
        {
            return obj is Edition edition && 
                   TitleEdition == edition.TitleEdition &&
                   ReleaseDate == edition.ReleaseDate &&
                   EditionCount == edition.EditionCount;
        }

        public static bool operator ==(Edition ed1, Edition ed2)
            => ed1.Equals(ed2);
        public static bool operator !=(Edition ed1, Edition ed2)
            => !(ed1 == ed2);

        public override int GetHashCode()
        {
            return HashCode.Combine(TitleEdition, ReleaseDate, EditionCount);
        }
        public override string ToString()
            => $"{TitleEdition}:{ReleaseDate} Count={EditionCount}";
    }
}
