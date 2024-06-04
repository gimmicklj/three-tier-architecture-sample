using BLL;
using DAL;
using WebApi;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddUserInterface()
    .AddDataAccess(builder.Configuration)
    .AddBusinessLogic();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GloblalExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
