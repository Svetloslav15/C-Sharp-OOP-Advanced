namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Library : IEnumerable<Book>
    {
        public List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index;
            private List<Book> books;
            public Book Current => this.books[index];

            object IEnumerator.Current => this.Current;
            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }
            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++index < this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
