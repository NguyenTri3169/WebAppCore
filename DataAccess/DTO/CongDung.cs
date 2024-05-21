using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    [Table("CongDung")]
    public class CongDung
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("CongDung")]
        public string? TenCd { get; set; }
        public string? MaCd { get; set; }
        public string?  GhiChu { get; set; }
        public string?  DoiTuong { get; set; }
        [Column("Version")]
        public double? Version { get; set; }

    }
}
