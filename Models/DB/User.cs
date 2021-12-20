using System;
using System.Collections.Generic;

namespace MVC.Models.DB
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public string? Date { get; set; }
        public string? Location { get; set; }
        public int IdState { get; set; }

        public virtual State IdStateNavigation { get; set; } = null!;
    }
}
