using System;
using System.Collections.Generic;
using System.Text;

namespace Dino_PagedList
{
    public class PagedListMetaData : IPagedList
    {
        /// <summary>
        /// Constructor không đối số
        /// </summary>
        protected PagedListMetaData() { }

        /// <summary>
        /// Constructor có đối số
        /// </summary>
        /// <param name="pageList"></param>
        public PagedListMetaData(IPagedList pageList)
        {
            PageCount = pageList.PageCount;
            TotalItemCount = pageList.TotalItemCount;
            PageNumber = pageList.PageNumber;
            PageSize = pageList.PageSize;
            HasPreviousPage = pageList.HasPreviousPage;
            HasNextPage = pageList.HasNextPage;
            IsFirstPage = pageList.IsFirstPage;
            IsLastPage = pageList.IsLastPage;
            FirstItemOnPage = pageList.FirstItemOnPage;
            LastItemOnPage = pageList.LastItemOnPage;
        }

        #region thành viên IPagedList
        public int PageCount { get; protected set; }
        public int TotalItemCount { get; protected set; }
        public int PageNumber { get; protected set; }
        public int PageSize { get; protected set; }
        public bool HasPreviousPage { get; protected set; }
        public bool HasNextPage { get; protected set; }
        public bool IsFirstPage { get; protected set; }
        public bool IsLastPage { get; protected set; }
        public int FirstItemOnPage { get; protected set; }
        public int LastItemOnPage { get; protected set; }

        #endregion
    }
}
