using System;
using System.Collections.Generic;
using System.Text;

namespace Dino_PagedList_Version2
{
    public class PagedList
    {
        /// <summary>
        /// Bộ đếm số lượng có tất cả bao nhiêu trang
        /// </summary>
        public int PageCount { get; protected set; }

        /// <summary>
        /// Đếm có tất cả bao nhiêu record trong danh sách
        /// </summary>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        /// Mã số trang hiện tại
        /// </summary>
        public int PageNumber { get; protected set; }

        /// <summary>
        /// Số lượng record lớn nhất trên 1 trang
        /// </summary>
        public int PageSize { get; protected set; }

        /// <summary>
        /// Trang hiện tại có trang trước hay không ?
        /// </summary>
        public bool HasPrevious { get; protected set; }

        /// <summary>
        /// Trang hiện tại có trang sau hay không ?
        /// </summary>
        public bool HasNextPage { get; protected set; }

        /// <summary>
        /// Trang hiện tại có phải là trang đầu tiên hay không ?
        /// </summary>
        public bool IsFirstPage { get; protected set; }

        /// <summary>
        /// Trang hiện tại có phải là trang cuối cùng hay không ?
        /// </summary>
        public bool IsLastPage { get; protected set; }

        /// <summary>
        /// Trả về giá trị của record đầu tiên trên page
        /// </summary>
        public int FirstItemOnPage { get; set; }

        /// <summary>
        /// Trả về giá trị của record cuối cùng trong page
        /// </summary>
        public int LastItemOnPage { get; set; }
    }
}
