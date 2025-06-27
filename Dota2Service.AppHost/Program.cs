var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Dota2Service_UserService>("dota2service-userservice");

builder.Build().Run();
