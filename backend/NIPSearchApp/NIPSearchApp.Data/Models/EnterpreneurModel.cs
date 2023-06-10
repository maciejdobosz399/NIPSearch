using System.ComponentModel.DataAnnotations;

namespace NIPSearchWebApi.Models
{
    public class EnterpreneurModel
    {
        [Key]
        public Guid Guid { get; set; }

        public string? Name { get; set; }
        public string? Nip { get; set; }
        public string? Regon { get; set; }
        public string? Address { get; set; }
    }
}