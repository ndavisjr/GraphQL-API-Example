using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL.Platforms
{
    [GraphQLDescription("Deleting a platform. Returns the platform deleted.")]
    public record DeletePlatformPayload(Platform platform);
}