using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCalc.Classes
{
    public class Speler
    {
        public Speler(int id, int rugNummer, string naam, int teamKey)
        {
            Id = id;
            RugNummer = rugNummer;
            Naam = naam;
            TeamKey = teamKey;
        }

        [Key]
        public int Id { get; set; }
        public int RugNummer { get; set; }
        [Required]
        public string Naam { get; set; }
        public int TeamKey { get; set; }
        //public Season Season { get; set; }
        
    }
}
