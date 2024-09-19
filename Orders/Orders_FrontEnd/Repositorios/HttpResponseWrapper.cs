using System.Net;

namespace Orders_FrontEnd.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpactionresponsemessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpactionresponsemessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }
            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado.";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que estar logeado para ejecutar la operación.";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permitido hacer esto.";
            }

            return "Ocurrió un error inesperado.";
        }
    }
}