namespace Practico1LabFinal.Models
{
    public class PeliculaActorModel
    {
        public int Id { get; set; }
        public int PeliculaId { get; set; }
        public int PersonaId { get; set; }

        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }

}
