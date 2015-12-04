using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManager.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<CheckOut> CheckOuts { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        [Index(IsUnique = true)]
        public string ISBN { get; set; }
        public int Year { get; set; }

        public ICollection<CheckOut> CheckOuts { get; set; }

    }

    public class CheckOut
    {
        public int Id { get; set; }
        public Student CheckedOutTo { get; set; }
        public Book Book { get; set; }
        public DateTime DateCheckedOut { get; set; }
        public DateTime DateExpectedReturn { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}