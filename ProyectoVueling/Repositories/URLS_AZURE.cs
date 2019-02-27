namespace ProyectoVueling.Repositories
{
    public static class Urls_Azure
    {
        public const string BASE_URL = "https://wcfodatacursosvuelings.azurewebsites.net/AcademiaVueling.svc/";
        public const string MODULOS = "Modulo";
        public const string PROFESORES = "Profesor";
        public const string CURSOS = "Curso";
        public const string CURSOS_IMPARTIDOS = "CursoImpartido";
        
        private const string JSON = "?$format=json";

        public static string GetUriById(string entidad, int id)
        {
            return BASE_URL + entidad + "(" + id + ")" + JSON;
        }

        public static string GetUri(string entidad)
        {
            return BASE_URL + entidad + JSON;
        }

    }
}
