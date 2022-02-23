
using CreateAPI.App;

var builder = WebApplication.CreateBuilder(args);

var connectionString = System.IO.File.ReadAllText(@"/Users/kareem/Desktop/KareemD-P1/CreateAPI/ConnectionString.txt");
IRepository repository = new SqlRepository(connectionString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository>(repository);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



