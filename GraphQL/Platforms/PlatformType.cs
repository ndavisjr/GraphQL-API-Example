using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is a list of available commands for this platform.");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the name of a platform.");

            descriptor
                .Field(p => p.Id)
                .Description("Internal Id of the platform.");
        }

        private class Resolvers 
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}