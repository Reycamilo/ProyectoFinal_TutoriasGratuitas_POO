namespace TutoriasGratuitas.Entidades
{
    public class MateriaEntity
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public int Creditos { get; set; }
        public virtual ICollection<TutorEntity> Tutores { get; set; }
        
    }
}