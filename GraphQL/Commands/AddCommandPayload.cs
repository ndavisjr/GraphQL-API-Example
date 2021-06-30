using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL.Commands
{
    [GraphQLDescription("Add a command. Returns the command added.")]
    public record AddCommandPayload(Command command);
}