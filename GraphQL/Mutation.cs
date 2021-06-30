using System;
using System.Threading;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    [GraphQLDescription("Mutations for adding platforms and commands.")]
    public class Mutation
    {
        // ADD platform
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Mutation for adding platforms.")]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
            {
                var platform = new Platform{
                    Name = input.Name
                };

                context.Platforms.Add(platform);
                await context.SaveChangesAsync(cancellationToken);

                await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

                return new AddPlatformPayload(platform);
            }

        // DELETE Platform
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Mutation for deleting platforms.")]
        public async Task<DeletePlatformPayload> DeletePlatformAsync(DeletePlatformInput input,
            [ScopedService] AppDbContext context)
            {
                var platform = context.Platforms.Find(input.Id);
                if (platform == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                context.Platforms.Remove(platform);
                await context.SaveChangesAsync();

                return new DeletePlatformPayload(platform);
            }

        //ADD Command
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Mutation for adding commands.")]
        public async Task<AddCommandPayload> AddCommandAsync(
            AddCommandInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
            {
                var command = new Command{
                    HowTo = input.Howto,
                    CommandLine = input.CommandLine,
                    PlatformId = input.PlatformId
                };

                context.Commands.Add(command);
                await context.SaveChangesAsync(cancellationToken);

                await eventSender.SendAsync(nameof(Subscription.OnCommandAdded), command, cancellationToken);

                return new AddCommandPayload(command);
            }

        // DELETE Command    
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Mutation for deleting commands.")]
        public async Task<DeleteCommandPayload> DeleteCommandAsync(DeleteCommandInput input,
            [ScopedService] AppDbContext context)
            {
                var command = context.Commands.Find(input.Id);
                if (command == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                context.Commands.Remove(command);
                await context.SaveChangesAsync();

                return new DeleteCommandPayload(command);
            }
    }
}