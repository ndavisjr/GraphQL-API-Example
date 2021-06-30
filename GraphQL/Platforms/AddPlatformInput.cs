using HotChocolate;

namespace CommanderGQL.GraphQL.Platforms
{
    [GraphQLDescription("Input for adding a platform. Requires {name}.")]
    public record AddPlatformInput(string Name);
}