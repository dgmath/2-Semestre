using Health_Clinic.Utils;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parametros de avaliacao do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //VALIDA QUEM ESTA SOLICITANDO
        ValidateIssuer = true,

        //valida quem esta recebendo
        ValidateAudience = true,

        //Define se o tempo de expiracao do token sera validado
        ValidateLifetime = true,

        //Forma de criptografia e ainda validacao da chave de autenticacao
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-health_clinic-webapi-key-autenticacao")),

        //valida o trempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde esta vindo (issuer)
        ValidIssuer = "Healt_Clinic",

        //Para onde esta indo (Audience)
        ValidAudience = "Health_Clinic"
    };

});

// Configurar a Program.cs

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Health Clinic Web Api",
        Description = "API para gerenciamento de uma Clinica - Atividade da Sprint 2 - Backend API ",
        Contact = new OpenApiContact
        {
            Name = "Matheus Dias",
            Url = new Uri("https://github.com/dg-math")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado com as instruções anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticacao do swagger

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
