using System.ComponentModel.DataAnnotations;

namespace RentiSI.Modelos
{
    public class OrganismosDeTransito
    {
        [Key]
        public int Id { get; set; }
        public string? Municipio { get; set; }
    }
}
