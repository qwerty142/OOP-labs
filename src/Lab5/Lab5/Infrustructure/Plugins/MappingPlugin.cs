using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrustructure.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.MapEnum<UserRole>();
    }
}