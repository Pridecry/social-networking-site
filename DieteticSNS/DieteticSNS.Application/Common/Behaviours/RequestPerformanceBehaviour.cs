﻿using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DieteticSNS.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 5000)
            {
                var name = typeof(TRequest).Name;

                _logger.LogWarning("DieteticSNS Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    name, _timer.ElapsedMilliseconds, _currentUserService.GetUserId(), request);
            }

            return response;
        }
    }
}
