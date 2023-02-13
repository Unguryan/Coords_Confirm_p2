using ConfirmCoords.EF_Core;
using ConfirmCoords.EF_Core.Context;
using ConfirmCoords.Infrastructure;
using ConfirmCoords.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEFCore(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRabbit(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");
using (var scope = app.Services.CreateScope())
{
    using (var db = scope.ServiceProvider.GetRequiredService<CoordContext>())
    {
        await db.Database.EnsureCreatedAsync();
    }
}

app.Run();