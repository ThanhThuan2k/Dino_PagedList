using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dino_PagedList
{
    /// <summary>
    ///  Chứa các hàm mở rộng cần thiết để sử dụng phân trang
    /// </summary>
    public static class PagedListExtension 
    {
        /// <summary>
        /// Phương thức mở rộng ToPagedList thường dùng để phân trang các danh sách trước khi đem nó ra Model
        /// </summary>
        /// <typeparam name="T">Loại dữ liệu cần phân trang</typeparam>
        /// <param name="list">Danh sách cần phân trang</param>
        /// <param name="pageNumber">Số trang hiện tại</param>
        /// <param name="pageSize">Số lượng record trên một trang</param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> list, int pageNumber, int pageSize)
        {
            return new PagedList<T>(list, pageNumber, pageSize);
        }

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> queriedList, int pageNumber, int pageSize)
        {
            return new PagedList<T>(queriedList, pageNumber, pageSize);
        }

        /// <summary>
        /// Chia danh sách dữ liệu lớn ra thành n trang cho trước
        /// </summary>
        /// <typeparam name="T">Loại dữ liệu cần xử lý</typeparam>
        /// <param name="list">Danh sách cần phân trang</param>
        /// <param name="numberOfPages">Số trang cần thiết để chia danh sách</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int numberOfPages)
        {
            return list.Select((item, index) => new { index, item })
                .GroupBy(item => item.index % numberOfPages)
                .Select(x => x.Select(y => y.item));
        }

        /// <summary>
        /// Chia danh sách lớn ra thành n trang với mỗi trang có pageSize record
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu cần xử lý</typeparam>
        /// <param name="list">Danh sách cần phân trang</param>
        /// <param name="pageSize">Số lượng record tối đa trên 1 trang</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> list, int pageSize)
        {
            if(list.Count() < pageSize)
            {
                // Nếu danh sách có số lượng record nhỏ hơn số lượng record trên 1 trang yêu cầu thì
                // return về chính danh sách đó, đương nhiên là trên 1 trang
                yield return list;
                // yield ngay đây đánh dấu là return 1 IEnumerable
            }
            else
            {
                // tính toán số lượng trang tối đa mà danh sách này có thể chứa
                var numberOfPages = Math.Ceiling(list.Count() / (double)pageSize);

                // sử dụng vòng lặp kết hợp với yield nhằm mục đích không return ra khỏi hàm mà để trả về 
                // giá trị cho lần lặp tiếp theo
                // thật sự thì ngay đây là một nùi tư duy mà mình cũng chưa hiểu hết ^-^
                for(var i = 0; i < numberOfPages; i++)
                {
                    yield return list.Skip(pageSize * i).Take(pageSize);
                }
            }
        }
    }
}
