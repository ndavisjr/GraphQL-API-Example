using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL.Platforms
{
    [GraphQLDescription("Add a platform. Returns the platform added.")]
    public record AddPlatformPayload(Platform platform);
}