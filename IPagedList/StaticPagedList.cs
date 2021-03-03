using System;
using System.Collections.Generic;
using System.Text;

namespace Dino_PagedList
{
    public class StaticPagedList<T> : BasePagedList<T>
    {
        public StaticPagedList(IEnumerable<T> list, IPagedList metadata)
            : this(list, metadata.PageNumber, metadata.PageSize, metadata.TotalItemCount) { }

        public StaticPagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalItemCount)
            : base(pageNumber, pageSize, totalItemCount)
        {
            Subset.AddRange(subset);
        }
    }
}
