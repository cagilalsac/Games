#nullable disable

using Core.Records.Bases;
using DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class GameModel : RecordBase
    {
        #region Entity'den kopyalanan veritabanı sütun karşılığı olan özellikler
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(75, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Publish Date")]
        public DateTime? PublishDate { get; set; }

        [Range(0, 1000, ErrorMessage = "{0} must be minimum {1} maximum {2}!")]
        public decimal Price { get; set; }

        [DisplayName("Download Count")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be 0 or positive!")]
        public long? DownloadCount { get; set; }

        [DisplayName("Player Count Type")]
        public int PlayerCountType { get; set; }

        public bool IsDeleted { get; set; }

        [DisplayName("Publisher")]
        public int? PublisherId { get; set; }
        #endregion

        #region View'ların ekstra ihtiyacı olan özellikler
        [DisplayName("Users")]
        public List<int> UserIdsInput { get; set; }

        [DisplayName("Users")]
        public List<UserModel> UsersOutput { get; set; }

        [DisplayName("Publish Date")]
        public string PublishDateOutput { get; set; }

        [DisplayName("Price")]
        public string PriceOutput { get; set; }

        [DisplayName("Player Count Type")]
        public string PlayerCountTypeOutput { get; set; }

        [DisplayName("Publisher")]
        public PublisherModel PublisherOutput { get; set; }
        #endregion
    }
}
