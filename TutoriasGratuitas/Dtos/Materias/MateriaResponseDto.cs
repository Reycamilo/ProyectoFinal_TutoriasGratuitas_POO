namespace TutoriasGratuitas.Dtos.Materias
{
    public class MateriaResponseDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public int Creditos { get; set; }
        public List<string> Tutores { get; set; }
    }
}
