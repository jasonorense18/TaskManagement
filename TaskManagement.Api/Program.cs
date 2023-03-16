using TaskManagement.Api;
using TaskManagement.Application;
using TaskManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddPresentatiion()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}



var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}


