using APIEscola.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar Servi�o de banco de dados
builder.Services.AddDbContext<APIEscolaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BancoDeDados")));

// Adicionar o servi�o de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Adicionar o servi�o de autentica��o
// Servi�o de EndPoints do Identity Framework
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false; // Exige confirma��o de email
    options.SignIn.RequireConfirmedAccount = false; // Exige confirma��o de conta
    options.User.RequireUniqueEmail = true; // Exige email �nico
    options.Password.RequireNonAlphanumeric = false; // Exige caracteres n�o alfanum�ricos
    options.Password.RequireLowercase = false; // Exige letras min�sculas
    options.Password.RequireUppercase = false; // Exige letras mai�sculas
    options.Password.RequireDigit = false; // Exige d�gitos num�ricos
    options.Password.RequiredLength = 4; // Exige comprimento m�nimo da senha
})
.AddRoles<IdentityRole>() // Adicionando o servi�o de roles
.AddEntityFrameworkStores<APIEscolaContext>() // Adicionando o servi�o de EntityFramework
.AddDefaultTokenProviders(); // Adiocionando o provedor de tokens padr�o

// Swagger com Autentica��o JWT Bearer
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "APIEscola", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adicionar os Servi�os de Autentica��o e Autoriza��o
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(); // Habilita a interface do Swagger
}

app.UseHttpsRedirection(); // Redireciona requisi��es HTTP para HTTPS

app.UseCors("AllowAll"); // Habilita o CORS

app.UseAuthentication(); // Habilita a autentica��o

app.UseAuthorization(); // Habilita a autoriza��o

app.MapControllers(); // Mapeia os controladores

app.MapGroup("/User").MapIdentityApi<IdentityUser>(); // Mapeia o grupo de endpoints de autentica��o

app.Run(); // Faz a aplica��o rodar
