GraphQL API development with documentation
using VSCode with .NET 5
using Hot Chocolate framework
using Insomnia API Client by Kong
using GraphQL Voyager
Using WebSockets for subscriptions


Database: SQL Server Express running in Docker



Process:

-- General setup for nearly anything .Net --
1) Set up a Model in Models folder
2) Set up a DbContext
    - connection string in appsettings.json
    - Create Data folder and add AppDbContext class inheriting from DbContext
    - Update Startup.cs to register the DbContext in services
3) Migrate to database

-- Graph QL specific -- 
-- Querying --
4) Create GraphQL Query.cs and intial query GetPlatforms
5) Register it (and the server) as a service in Startup.cs; then update endpoint 
6) update dbcontext to work in parallel in startup.cs and query.cs
7) created Command.cs and linked it via AppDbContext
8) update Query.cs and Startup.cs to AddProjections (later taken out with use of Resolvers)
9) Add a GetCommands to Query.cs
10) Add documentation via [GraphQLDescription("")]
11) Create abstraction layer for GraphQL and the Models => called Types
    - Create PlatformType and move GraphQL documentation to it
    - Repeat for CommandType
    - need to add Resolvers to hand the relationships in tables/classes
12) add filtering and sorting via Hot Chocolate framework

-- Mutations --
13) create Mutation.cs to handle mutations and add it to Startup.cs
14) "AddMutation" add two record types (for each mutation), 
    - one to contain the input and the other is called payload (returned output)
15) "DeleteMutation" repeat similar step 14

-- Subscriptions --
16) Create Subscriptions.cs
17) Add websockets to the pipeline in Startup.cs and subscription service to Services
18) Update Mutation.cs to handle the subscriptions