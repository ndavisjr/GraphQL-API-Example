using HotChocolate;

namespace CommanderGQL.GraphQL.Commands
{
    [GraphQLDescription("Input for adding a command. Requires {HowTo}, {CommandLine}, {Platform Id}.")]
    public record AddCommandInput(string Howto, string CommandLine, int PlatformId);
}