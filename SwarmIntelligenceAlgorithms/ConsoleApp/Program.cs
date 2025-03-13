using Cocona;
using ConsoleApp.Commands;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();

//builder.Logging.AddFilter("", LogLevel.Error);

var app = builder.Build();

app.AddCommands<WhaleOptimizationAlgorithmCommand>();

app.Run();
