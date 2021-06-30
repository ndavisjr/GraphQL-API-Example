using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents an executable command to be used in a command line interface.");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform to which the command belongs.");

            descriptor
                .Field(c => c.Id)
                .Description("Internal Id of the command.");

            descriptor
                .Field(c => c.HowTo)
                .Description("General description of what the command accomplishes.");

            descriptor
                .Field(c => c.CommandLine)
                .Description("The command string used in the command line interface.");

            descriptor
                .Field(c => c.PlatformId)
                .Description("The platform the command is used for/apart of.");
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}