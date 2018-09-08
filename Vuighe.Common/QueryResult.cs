using System.Collections.Generic;

namespace Vuighe.Common
{
    public class QueryResult<T>
    {
        public IList<T> Items { get; set; }

        public long Count { get; set; }
    }
}