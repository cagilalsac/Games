using Core.Records.Bases;

namespace DataAccess.Entities
{
    public class User : RecordBase
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime BirthDate { get; set; }

        public int Sex { get; set; }

        public int RoleId { get; set; }

        public Role? Role { get; set; }

        public ICollection<UserGame>? UserGames { get; set; } = new List<UserGame>();
    }
}
