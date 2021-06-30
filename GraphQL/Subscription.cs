using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL
{
    [GraphQLDescription("Subscription services")]
    public class Subscription
    {
        [Topic]
        [Subscribe]
        [GraphQLDescription("Subscription for when platforms are added")]
        public Platform OnPlatformAdded([EventMessage] Platform platform)
        {
            return platform;
        } 

        [Topic]
        [Subscribe]
        [GraphQLDescription("Subscription for when commands are added")]
        public Command OnCommandAdded([EventMessage] Command command)
        {
            return command;
        } 
        
    }
}