using System;

//Model som representerer informasjon assosiesert med en kunde, og blir brukt for jobbe med kunde data i applikasjonen

namespace Nsted.Models
{ 
    public class Kunde {
        

        public int ID { get; set; }
        public string? Fornavn { get; set; }

        public string? Etternavn { get; set; }

        public string? Adresse { get; set; }

        public string? Telefon { get; set; }

        public string? Epost { get; set; }



    }
}




