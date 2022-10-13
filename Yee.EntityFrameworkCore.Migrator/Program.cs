using Yee.EntityFrameworkCore.Migrator;

var context = new AppDbContextFactory().CreateDbContext(args);
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run();
