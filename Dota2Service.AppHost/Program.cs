using Microsoft.Extensions.DependencyInjection;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Dota2Service_UserService>("dota2service-userservice");

builder.AddProject<Projects.Dota2Service_SubscriptionService>("dota2service-subscriptionservice");

builder.Build().Run();
