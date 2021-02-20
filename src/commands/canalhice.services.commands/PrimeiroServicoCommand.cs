using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace canalhice.services.commands
{
    public class PrimeiroServicoCommand : IRequest<string>
    {
        public string Texto;

        public PrimeiroServicoCommand(
            string texto
        )
        {
            Texto = texto;
        }
    }
    public class PrimeiroServicoHandler : IRequestHandler<PrimeiroServicoCommand, string>
    {
        public Task<string> Handle(PrimeiroServicoCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var textoInvertido = request.Texto.Reverse().ToArray();
            return Task.FromResult(new string(textoInvertido));
        }

        private static void Validate(PrimeiroServicoCommand request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (string.IsNullOrWhiteSpace(request.Texto))
            {
                throw new ArgumentException("É necessário informar um texto");
            }
        }
    }
}
