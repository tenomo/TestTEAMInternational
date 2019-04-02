using System;

namespace Interview
{
    public sealed class Book : IStoreable
    {
        public IComparable Id { get; set; }
        public string Title { get; set; }
        public IComparable CategoryId { get; set; }
        public IComparable AuthorId { get; set; }
    }
}
