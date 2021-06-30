using HotChocolate;

namespace CommanderGQL.GraphQL.Commands
{
    [GraphQLDescription("Input for deleting a command. Requires {Id}")]
    public record DeleteCommandInput(int Id);
}