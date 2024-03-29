using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Server
{
    ///protocol-buffers : https://developers.google.com/protocol-buffers/docs/csharptutorial
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogTrace($"TRACE>>{nameof(SayHello)}");

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name + $" Age:{request.Age}"
            });
        }
    }
}
