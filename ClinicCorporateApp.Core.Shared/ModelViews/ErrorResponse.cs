using System;

namespace ClinicCorporateApp.Core.Shared.ModelViews
{
    public class ErrorResponse
    {
        public ErrorResponse(string id, string requestId)
        {
            Id = id;
            RequestId = requestId;
            Data = DateTime.Now;
            Mensagem = "Erro inesperado.";
        }
        public string Id { get; set; }
        public string RequestId { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }
    }
}
