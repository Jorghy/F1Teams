using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1TestApp.Models
{
    public class Team
    {
        //Properties: ID, Név, Alapítás éve, Megnyert világbajnokságok száma, Befizette-e a nevezési díjat.
        public int ID { get; set; }
        public string Name { get; set; }
        public string YearOfEstablishment { get; set; }
        public int NumberOfWon { get; set; }
        public bool IsPaidEntryFee { get; set; }
    }
}
