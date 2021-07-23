using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Task.Entities
{
    [Table("mac_base")]
    public class MacBase
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("terminal_mac", TypeName = "nvarchar(256)")]
        public string TerminalMAC { get; set; }

        [Column("vendor", TypeName = "nvarchar(256)")]
        public string Vendor { get; set; }

        [Column("model", TypeName = "nvarchar(256)")]
        public string Model { get; set; }

        [Column("hw", TypeName = "nvarchar(256)")]
        public string Hw { get; set; }
    }
}
