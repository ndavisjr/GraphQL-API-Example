using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL.Commands
{
    [GraphQLDescription("Delete a command. Returns the deleted command.")]
    public record DeleteCommandPayload(Command command);
}