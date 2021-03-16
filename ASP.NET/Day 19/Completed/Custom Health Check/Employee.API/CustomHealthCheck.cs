using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.API
{
    public class CustomHealthCheck :IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            var healthCheckResultHealthy = true;

            if (healthCheckResultHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("API is healthy."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("API is unhealthy"));
        }
    }
}
