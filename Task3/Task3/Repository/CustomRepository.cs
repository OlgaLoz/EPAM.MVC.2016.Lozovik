using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task3.Repository
{
    public class CustomRepository
    {
        public static User User { get; set; } = new User();
    }

    public enum Sides
    {
        White,
        Black
    }

    public class User
    {
        public Sides Side { get; set; }
    }
}