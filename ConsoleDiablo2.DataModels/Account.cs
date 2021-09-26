using ConsoleDiablo2.Common;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleDiablo2.DataModels
{
    public class Account
    {
        public Account(): this("", "")
        {
            this.Characters = new HashSet<Character>();
        }

        public Account(string accountName, string password)
        {
            this.AccountName = accountName;
            this.Password = password;
            this.IsLoggedIn = false;
            this.Characters = new HashSet<Character>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
