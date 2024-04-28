using System.Diagnostics.CodeAnalysis;

using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrustructure.Extensions;

public static class ServiceScopeExtensions
{
    [SuppressMessage("Category", "IDE0060", Justification = "aboba")]
    public static void UseInfrastructureDataAccess(this IServiceScope scope)
    {
        scope.UsePlatformMigrationsAsync(CancellationToken.None);
    }
}