using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TemplateBFF.DtiRoundAdapter
{
    public static class Extensions
    {

        public static async Task<Exception> ThrowHttpResponseException(this HttpResponseMessage response)
        {
            throw new AdapterExceptions($"Erro em chamada de serviço da plataforma Round. " +
                $"Uri :{response.RequestMessage.RequestUri} - " +
                $"Código Http:{response.StatusCode} - " +
                $"Conteúdo: {await response.Content?.ReadAsStringAsync()}");
        }
    }

    public static class Constants
    {
        public const string RoundHttpClientName = "Round";
    }
}
