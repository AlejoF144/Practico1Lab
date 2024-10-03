using System.ComponentModel.DataAnnotations;

namespace Practico1LabFinal.Models
{
    public class GeneroModel
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public ICollection<PeliculaModel>? Peliculas { get; set; }
    }

}
