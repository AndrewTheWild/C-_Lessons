using Laba1.Model;
using System;
using System.Collections;

namespace Laba1.Interfaces
{
    public class MagazineEnumerator : IEnumerator
    { 
        private ArrayList Articles=new ArrayList();
        private int position = -1;

        private void CheckArticleOnEditors(Magazine magazine)
        {
            foreach (var item in magazine.Articles)
            {
                if (item is Article article)
                {
                    if (!magazine.Editors.Contains(article.PersonData))
                    {
                        Articles.Add(item);
                    }
                }
            }
        }
        public MagazineEnumerator(Magazine magazine)
            => CheckArticleOnEditors(magazine);
        public object Current
        {
            get
            {
                if (position == -1 || position >= Articles.Count)
                    throw new InvalidOperationException();
                return Articles[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < Articles.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
