using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookObject
{
    public class BookUtils
    {
        public static bool isNotEmpty(String chuoi)
        {
            return (chuoi != null && chuoi.Length > 0);
        }
    }
}
