using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dino_PagedList
{
    /// <summary>
    /// Đại diện cho một danh sách mà các phần tử có thể được truy cập bằng các chỉ mục và có thể chứ siêu dữ liệu về tập hợp đối tượng
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>
    {
        /// <summary>
        /// Tập hợp tất cả các phần tử chứa trong một danh trang trong một danh sách lớn
        /// </summary>
        protected readonly List<T> Subset = new List<T>();

        /// <summary>
        /// Constructor không đối số
        /// </summary>
        protected internal BasePagedList() { }

        protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
        {
            // bắt ngoại lệ nếu pageNumber hoặc pageSize nhỏ hơn 1
            if (pageNumber < 1) throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "Số trang hiện tại không thể nhỏ hơn 1");
            if (pageSize < 1) throw new ArgumentOutOfRangeException("pageSize", pageSize, "Kích cỡ trang không thể nhỏ hơn 1");

            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            // tính tổng số số trang có thể được chia
            PageCount = TotalItemCount > 0 ?
                (int)Math.Ceiling(TotalItemCount / (double)(PageSize)) :
                0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < PageCount;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber >= PageCount;
            // Lấy phần tử đầu tiên của trang bằng cách lấy số trang trước nhân với số phần tử trên 1 trang
            // cộng thêm 1(1 là phần tử của trang đó)
            FirstItemOnPage = (PageNumber - 1) * PageSize + 1;

            // lấy ra chỉ số của phần tử cuối cùng bằng cách lấy phần tử đầu tiên cộng cho số phần tử trên 1 page
            // trừ 1 ra vì 1 là phần tử đầu tiên đã cộng
            var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
            // Kiểm tra xem chỉ số phần tử cuối cùng vừa tìm đc có vượt quá tổng số phần tử trong mảng hay không,
            // nếu có thì lấy tổng số phần tử trong mảng, ngược lại thì lấy chỉ số vừa tìm đc
            LastItemOnPage = numberOfLastItemOnPage > TotalItemCount ?
                TotalItemCount : numberOfLastItemOnPage;
        }

        #region implement cho thành viên IPagedList<T>

        /// <summary>
        /// Lấy ra một con iterator của phần tử trong danh sách
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                return Subset[index];
            }
        }

        /// <summary>
        /// Đếm số phần tử trong 1 trang
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get { return Subset.Count; }
        }

        public IPagedList GetMetaData()
        {
            return new PagedListMetaData(this);
        }

        #endregion
    }
}
