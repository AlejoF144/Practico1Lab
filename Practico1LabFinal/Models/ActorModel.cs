using System.ComponentModel.DataAnnotations;

namespace Practico1LabFinal.Models
{
    public class ActorModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Nombre { get; set; } 
        public DateTime FechaNacimiento { get; set; }
        public string? Foto { get; set; }

        public ICollection<PeliculaActorModel>? Peliculas { get; set; }
    }

}
