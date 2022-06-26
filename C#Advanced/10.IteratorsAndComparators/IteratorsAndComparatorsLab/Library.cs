using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;
        public Library(IEnumerable<Book> books)
        {
            var comparator = new BookComparator();
            this.books = new SortedSet<Book>(books,comparator);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            this.books = new List<Book>(books);
        }
        public Book Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext() => ++currentIndex < books.Count;

        public void Reset() => currentIndex = -1;

    }
}
