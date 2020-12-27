using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data.Entities
{
    public class CommunicationInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MobileNo { get; set; }

        public string EMail { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }

        public string Address { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
