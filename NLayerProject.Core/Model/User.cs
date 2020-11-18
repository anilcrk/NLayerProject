using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Core.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserRoleId { get; set; }
        public string Password { get; set; }
        public virtual UserRole UserRole{ get; set; }
    }
}
