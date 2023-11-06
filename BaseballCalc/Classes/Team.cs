using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCalc.Classes
{
    public class Team
    {
        public Team(int id, string naam)
        {
            Naam = naam;
            Id = id;
        }

        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }
    }
}
