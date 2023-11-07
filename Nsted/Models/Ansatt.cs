using System.ComponentModel.DataAnnotations;

namespace Nsted.Models
{
    public class Ansatt
    {
        [Key]
        public int AnsattNr { get; set; }

        public string Fornavn { get; set; }

        public string Etternavn { get; set; }

        //Related property

    }
}
