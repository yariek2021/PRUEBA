
using System.Collections.Generic;

namespace CommonLayer
{
    public class DataCollection<T> where T: class
    {
        public IEnumerable<T> Items { get; set; }
        //public int Total { get; set; }

        //public int Pages { get; set; }
    }
}
