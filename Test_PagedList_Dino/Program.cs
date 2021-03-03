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

            // Bắt đầu chạy đồng hồ tính giờ
            stop.Start();
            IPagedList<int> collection = db.Helper
                .Where(x => x.Id <= 100)
                .Select(x => x.Value)
                .ToPagedList(5, 20);
            stop.Stop();
            // Kết thúc bấm h

            var count = collection.Count();
            for(int i = 0; i < collection.Count(); i++)
            {
                Console.WriteLine(collection[i]);
            }
            Console.WriteLine(stop.Elapsed);
            Console.ReadKey();
        }
    }
}
