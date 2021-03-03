using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dino_PagedList
{
    public class PagedList<T> : BasePagedList<T>
    {
        /// <summary>
        /// Constructor 3 đối số để làm base cho phân trang đối với một danh sách queryable
        /// </summary>
        /// <param name="queriedList">Danh sách đã query</param>
        /// <param name="pageNumber">Số trang cần truy vấn</param>
        /// <param name="pageSize">Số record trên 1 trang</param>
        public PagedList(IQueryable<T> queriedList, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "Số trang hiện tại không được nhỏ hơn 1");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "Số record trên 1 trang không được nhỏ hơn 1");

            TotalItemCount = queriedList == null ? 0 : queriedList.Count();
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = TotalItemCount > 0 ?
                (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;
            HasPreviousPage = PageNumber < 1;
            HasNextPage = PageNumber < PageCount;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber >= PageCount;
            FirstItemOnPage = (PageNumber - 1) * PageSize + 1;
            var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
            LastItemOnPage = numberOfLastItemOnPage > TotalItemCount ?
                TotalItemCount : numberOfLastItemOnPage;

            // tiến hành lấy các record đang được truy vấn
            // Kiểm tra pageNumber có phải là trang đầu tiên hay không(vì mặc định hiển thị trang đầu tiên,
            // thì bỏ 0 lấy pageSize, ngược lại bỏ (pageNumber - 1) * pageSize record tính từ đầu sau đó take
            if(queriedList != null && TotalItemCount > 0)
            {
                Subset.AddRange(pageNumber == 1 ? queriedList.Skip(0).Take(pageSize).ToList()
                    : queriedList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
            }
        }

        /// <summary>
        /// Thực hiện truy vấn với danh sách chỉ đọc, tương tự như trên
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedList(IEnumerable<T> list, int pageNumber, int pageSize)
        : this(list.AsQueryable(), pageNumber, pageSize)
            {}
    }
}
