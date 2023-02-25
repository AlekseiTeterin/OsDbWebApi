using Microsoft.EntityFrameworkCore;
using System;

namespace OsDbWebApi.Models.Entity
{
    [PrimaryKey(nameof(PhoneOsID))]
    public class PhoneOperationSystems
    {
        public PhoneOperationSystems()
        {
            this.Versions = new HashSet<OsVersions>();
        }
        public int PhoneOsID { get; set; }
        public string? SystemName { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }


        public virtual ICollection<OsVersions> Versions { get; set; }
    }
}
