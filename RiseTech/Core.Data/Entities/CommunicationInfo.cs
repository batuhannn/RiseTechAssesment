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
        public int CommunicationInfoId { get; set; }
        public int TelephoneNumber { get; set; }

        public string Mail { get; set; }

        public string Location { get; set; }

        public string Adress { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
