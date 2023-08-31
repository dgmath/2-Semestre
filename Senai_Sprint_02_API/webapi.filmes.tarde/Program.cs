using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de Controllers.
builder.Services.AddControllers();

//Adiciona o serviço/gerador do Swagger.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para gerenciamento de Filmes - Introdução à Sprint 2 - Backend API ",
        Contact = new OpenApiContact
        {
            Name = "Matheus Dias",
            Url = new Uri("https://github.com/Matheus-Dias-Gomes")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado com as instruções anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Atender a interface do swagger na raiz do alicativo, prefixando uma rota
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Mapear os controllers
app.MapControllers();

app.Run();  