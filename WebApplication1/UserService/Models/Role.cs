using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Enums.Enum;

namespace UserService.Models
{
    public class Role
    {
        public int Id { get; set; }
        public RoleTypes RoleType { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
