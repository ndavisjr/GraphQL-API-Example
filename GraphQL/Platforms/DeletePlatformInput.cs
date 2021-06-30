using HotChocolate;

namespace CommanderGQL.GraphQL.Platforms
{
    [GraphQLDescription("Input for deleting a platform. Requires {Id}.")]
    public record DeletePlatformInput(int Id);
}