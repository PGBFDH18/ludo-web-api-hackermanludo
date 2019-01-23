using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class User
    {
        public User()
        {
            Player = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
