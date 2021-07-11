using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Models;
namespace RFID_Based_Document_Management.Library.Services.Parsers
{
    class DocumentStatusParser
    {
        public DocumentStatus parseString(string roleString)
        {
            switch (roleString)
            {
                case "In":
                    return DocumentStatus.In;
                case "Out":
                    return DocumentStatus.Out;
                default:
                    throw new Exception("Status cannot be parsed!");
            }
        }
    }
}
