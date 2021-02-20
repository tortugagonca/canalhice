
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace canalhice.api.Helpers
{
    public class RequestGenericExceptionHandler<TRequest, TException, TResponse> : RequestExceptionHandler<TRequest, TResponse, TException>
        where TException : Exception
    {
        private readonly ILogger<TRequest> _logger;

        public RequestGenericExceptionHandler(
            ILogger<TRequest> logger
        )
        {
            this._logger = logger;
        }
         
        protected override void Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state)
            =>
            _logger.LogError("Identificado erro no serviço: {@Requisicao}",
                typeof(TRequest).Name,
                exception.Message,
                request
                );
    }
}
