using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.Models
{
    public class Reader
    {
        public int Id { get; set; }

        public string ReaderName { get; set; }


        public Reader()
        {
        }

        public Reader(string readerName)
        {
            ReaderName = readerName;
        }
    }
}
