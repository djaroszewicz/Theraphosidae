using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.View.Role
{
    public class RoleView
    {
        [Required]
        public string RoleName { get; set; }
    }
}
