
using CreateAPI.App;
var connectionString = "Server=tcp:daleyserver.database.windows.net,1433;Initial Catalog=ShopApp;Persist Security Info=False;User ID=dbadmin;Password=adminpw1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
IRepository repository = new SqlRepository(connectionString);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//provide any other dependencies that e.g., the controllers need injected into them
//if anyone ask for Irepository , give them this object
//controller will ask for this - ask by requiring it in params - set up where its being requested and provided?? (need in two places)
builder.Services.AddSingleton<IRepository>(repository);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// disallowing http => redirect to https
app.UseHttpsRedirection();

//not doing anything
app.UseAuthorization();

//shortcut for  routbuilder
app.MapControllers();

app.Run();




