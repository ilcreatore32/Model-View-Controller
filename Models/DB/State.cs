using System;
using System.Collections.Generic;

namespace MVC.Models.DB
{
    public partial class State
    {
        public State()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
