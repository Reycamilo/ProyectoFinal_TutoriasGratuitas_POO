namespace TutoriasGratuitas.Entidades
{
    public class TutorEntity
    {
        public string Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public  DateTime FechaDeNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Genero { get; set; }
    }
}