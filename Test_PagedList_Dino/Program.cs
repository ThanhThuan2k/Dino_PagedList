using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dino_PagedList;

namespace Test_PagedList_Dino
{
    class Program
    {
        static void Main(string[] args)
        {
            PagedListDataContext db = new PagedListDataContext();
            Stopwatch stop = new Stopwatch();
            int pageNumber = 10000;
            int pageSize = 100;
            for (var i = 1; i <= 5; i++)
            {
                // Bắt đầu chạy đồng hồ tính giờ
                stop.Start();
                var list = db.TestTable
                    .ToPagedList(pageNumber, pageSize);
                stop.Stop();
                // Kết thúc bấm h

                Console.WriteLine(stop.Elapsed.TotalMilliseconds);
            }

            Console.ReadKey();
        }
    }
}
