using System.ComponentModel.DataAnnotations;

namespace Practico1LabFinal.Models
{
    public class PeliculaModel
    {
        public int Id { get; set; }
        public int GeneroId { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string Portada { get; set; }
        public string Trailer { get; set; }
        [MaxLength(100)]
        public string Resumen { get; set; }

        public GeneroModel Genero { get; set; }
        public ICollection<PeliculaActorModel> Actores { get; set; }
    }

}
