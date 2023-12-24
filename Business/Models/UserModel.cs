#nullable disable

using Core.Records.Bases;

namespace Business.Models
{
    public class UserModel : RecordBase
    {
        #region Entity'den kopyalanan veritabanı sütun karşılığı olan özellikler
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime BirthDate { get; set; }

        public int Sex { get; set; }

        public int RoleId { get; set; }
        #endregion
    }
}
