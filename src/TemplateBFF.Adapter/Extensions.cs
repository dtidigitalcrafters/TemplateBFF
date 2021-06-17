using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TemplateBFF.Adapter
{
    public static class Extensions
    {
        public static async Task<Exception> ThrowHttpResponseException(this HttpResponseMessage response)
        {
            throw new AdapterExceptions($"Erro em chamada de serviço. " +
                $"Uri :{response.RequestMessage.RequestUri} - " +
                $"Código Http:{response.StatusCode} - " +
                $"Conteúdo: {await response.Content?.ReadAsStringAsync()}");
        }
    }
}
