
using System;
using System.ComponentModel.DataAnnotations;

namespace Nsted.Models
{
    public class Service
    {
        
        public int ID { get; set; }
        public string Produkttype { get; set; }

        public string ServiceRep { get; set; }

        public int Årsmodell { get; set; }

        public string Serienummer { get; set; }

        public string Notat { get; set; }

        public string Status { get; set; }

        public string? KundeID { get; set; }

    }
}

