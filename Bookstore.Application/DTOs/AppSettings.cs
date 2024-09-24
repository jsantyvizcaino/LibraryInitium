namespace Bookstore.Application.DTOs
{
    public class AppSettings
    {
       
        public ServicioAutenticacion ServicioAutenticacion { get; set; }
     
        public JWT JWT { get; set; }
        public AppSettings()
        {
           
            ServicioAutenticacion = new ServicioAutenticacion();
            JWT = new JWT();
        }

        
    }

    public class ServicioAutenticacion
    {
        public string Nombre { get; set; } = null!;
        public string DireccionBase { get; set; } = null!;
        public string UrlToken { get; set; } = null!;

    }
    public class JWT
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public double DurationInMinutes { get; set; }
    }
}


