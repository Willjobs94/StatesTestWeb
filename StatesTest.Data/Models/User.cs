using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesTest.Data.Models
{
    public class User
    {
        /// <summary>
        /// Autonumber primary key field
        /// </summary>
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// Text field to hold the user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Text field to hold the user password
        /// </summary>
        public string Password { get; set; }
    }
}
