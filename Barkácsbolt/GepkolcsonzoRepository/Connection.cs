using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GepkolcsonzoRepository
{
    public static class Connection
    {
        public static string String { get; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=gepDB;Integrated Security=SSPI;";
    }
}
