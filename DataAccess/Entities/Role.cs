using Core.Records.Bases;

namespace DataAccess.Entities
{
    public class Role : RecordBase
    {
        public string Name { get; set; } = null!;

        public ICollection<User>? Users { get; set; } = new List<User>();
    }
}
