using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VJAUDIO.Models
{
    public class HeadsetColor
    {
        public int? Id { get; set; }

        public string Color { get; set; }
        public int Count { get; set; }
    }
}
