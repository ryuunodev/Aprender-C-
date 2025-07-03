var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// va a mapear los controladores a rutas
app.MapControllers();

app.UseAuthorization();


app.Run();


// UN ENDPOINT ES UN DIRECCION WEB
// UN MIDDLWARES SON COMPONENTES QUE MANIPULAN LOS HTTP REQUEST