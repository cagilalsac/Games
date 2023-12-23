#nullable disable

using Core.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class PublisherModel : RecordBase
    {
        #region Entity'den kopyalanan veritabanı sütun karşılığı olan özellikler
        [Required(ErrorMessage = "{0} is required!")]
        //[MinLength(2, ErrorMessage = "{0} must be minimum {1} characters!")]
        //[MaxLength(100, ErrorMessage = "{0} must be maximum {1} characters!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        [DisplayName("Publisher Name")]
        public string Name { get; set; }
        #endregion

        #region View'ların ekstra ihtiyacı olan özellikler
        [DisplayName("Game Count")]
        public int GameCountOutput { get; set; }

        [DisplayName("Games")]
        public string GamesOutput { get; set; }
        #endregion
    }
}
