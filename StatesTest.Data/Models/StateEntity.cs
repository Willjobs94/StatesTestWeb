using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesTest.Data.Models
{
    public class StateEntity
    {
        /// <summary>
        /// Autonumber primary key field
        /// </summary>
        [Key]
        public int StateId { get; set; }
        /// <summary>
        /// Name of the State
        /// </summary>
        [Column("State")]
        public string StateName { get; set; }
        /// <summary>
        /// Name of the State Capital
        /// </summary>
        public string Capital { get; set; }
    }
}
