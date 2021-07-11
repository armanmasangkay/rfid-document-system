using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Services;

namespace RFID_Based_Document_Management.Library.Models
{
    class Document
    {
        public string Tag { get; }
        public string Owner { get; }
        public string Date { get; }
        public Folder Folder { get; }

        public string CreatedAt { get; }
        public Document(string tag,string owner,string date,Folder folder, string createdAt="")
        {
            StringHelper.throwIfEmpty(tag,"Tag is required");
            StringHelper.throwIfEmpty(owner, "Owner is required");
            StringHelper.throwIfEmpty(date, "Date is required");

            if (folder == null)
            {
                throw new Exception("Folder is required!");
            }

            this.Tag = tag;
            this.Owner = owner;
            this.Date = date;
            this.Folder = folder;
            this.CreatedAt = createdAt;

        }
    }
}
