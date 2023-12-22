using Core.Records.Bases;

namespace DataAccess.Entities
{
    public class Game : RecordBase
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? PublishDate { get; set; }

        public decimal Price { get; set; }

        public long? DownloadCount { get; set; }

        public int PlayerCountType { get; set; }

        public bool IsDeleted { get; set; }

        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; }

        public ICollection<UserGame>? UserGames { get; set; } = new List<UserGame>();
    }
}
