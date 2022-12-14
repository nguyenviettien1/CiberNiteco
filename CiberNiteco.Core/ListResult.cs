using System.Collections.Generic;

namespace CiberNiteco.Core
{
    public class ListResult<T>
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }
}