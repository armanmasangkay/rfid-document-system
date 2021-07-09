using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Services;

namespace RFID_Based_Document_Management.Library.Models
{
    class Folder
    {
        public string Id { get; }
        public string Name { get; }
        public Folder(string Id, string name)
        {
            StringHelper.throwIfEmpty(Id,"Folder ID is required");
            StringHelper.throwIfEmpty(name,"Folder name is required");
            this.Id = Id;
            this.Name = name;
        }
    }
}
