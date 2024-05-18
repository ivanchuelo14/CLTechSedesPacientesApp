namespace CLTechSedesPacientesApp.Models
{
    public class SedeFilterViewModel
    {
        public SedeFilterViewModel()
        {
            SedesViewModel = new List<SedeFilterDetail>();
        }

        public List<SedeFilterDetail> SedesViewModel { get; set; }
    }

    public class SedeFilterDetail
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoCentral { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
