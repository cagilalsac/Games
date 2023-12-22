using Core.Records.Bases;

namespace DataAccess.Entities
{
    public class Publisher : RecordBase
    {
        public string Name { get; set; } = null!;

        public ICollection<Game>? Games { get; set; } = new List<Game>();
    }
}
