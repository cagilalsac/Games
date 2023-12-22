using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities
{
    [PrimaryKey(nameof(UserId), nameof(GameId))]
    public class UserGame
    {
        public int UserId { get; set; }

        public User? User { get; set; }

        public int GameId { get; set; }

        public Game? Game { get; set; }
    }
}
