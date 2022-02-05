using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly_.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte UnKnown = 0;
        public static readonly byte PayAsYouCan = 1;
    }
}