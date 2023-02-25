using Microsoft.EntityFrameworkCore;

namespace OsDbWebApi.Models.Entity
{
    [PrimaryKey(nameof(VersionID))]
    public class OsVersions
    {
        public int VersionID { get; set; }
        public string? VersionName { get; set; }
        public string? Futures { get; set; }
        public string? ReleaseDate { get; set; }
    }

}
