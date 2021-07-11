using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Based_Document_Management.Library.Services
{
    class StringHelper
    {
        public static void throwIfEmpty(string str,string exceptionMessage)
        {
            if (str.Trim() == "")
            {
                throw new Exception(exceptionMessage);
            }
        }

        public static string toMysqlDateString(string strDate)
        {


            return DateTime.Parse(strDate).ToString("yyyy-MM-dd");
        }

        public static string removeTimeFromDate(string strMysqlDateTime)
        {
           return strMysqlDateTime.Split(' ')[0];
        }
    }
}
