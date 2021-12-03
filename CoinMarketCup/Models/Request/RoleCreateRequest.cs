using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCup.Models.Request
{
    public class RoleCreateRequest
    {
        [Required]
        [Display(Name = "Наименование роли")]
        public string RoleName { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
