using Microsoft.EntityFrameworkCore;
using ModuleGate.EntityFrameworkCore;
using ModuleGate.EntityFrameworkCore.Migrator;

var context = new AppDbContextFactory().CreateDbContext(args);
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run();
