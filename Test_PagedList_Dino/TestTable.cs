using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test_PagedList_Dino
{
    public class TestTable
    {
        [Key]
        public int Id { get; set; }
        public int YearOfBirth { get; set; }
        public string FullName { get; set; }
        public string  Address { get; set; }
        public string Description { get; set; }
    }
}
