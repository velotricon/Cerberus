using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cerberus.Models
{
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
    }
}