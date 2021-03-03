using System;
using System.Collections.Generic;
using System.Text;

namespace Dino_PagedList
{
    public interface IPagedList
    {
        /// <summary>
        /// Đếm có tất cả bao nhiêu trang trong danh sách
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// Có tất cả bao nhiêu phần tử trong danh sách lớn
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Số lượng record tối đa của 1 trang
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Trang hiện tại có trang trước nó hay không ?
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Trang hiện tại có trang sau hay không 
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// Trang hiện tại có phải là trang đầu tiên hay không
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Trang hiện tại có phải là trang cuối cùng hay không
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// Kiểm tra giá trị chỉ số của phần tử đầu tiên trong trang
        /// </summary>
        int FirstItemOnPage { get; }

        /// <summary>
        /// Kiểm tra giá trị chỉ số của phần tử cuối cùng trong danh sách
        /// </summary>
        int LastItemOnPage { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        /// <summary>
        /// Lấy ra phần tử ở vị trí chỉ định trong danh sách
        /// </summary>
        /// <param name="index">Chỉ số cần lấy</param>
        /// <returns></returns>
        T this[int index] { get; }

        /// <summary>
        /// Lấy ra số phần tử trên trang này
        /// </summary>
        int Count { get; }

        IPagedList GetMetaData();
    }
}
