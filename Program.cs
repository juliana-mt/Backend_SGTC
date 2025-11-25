using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TreinamentosCorp.API.Infra.Data.Context;
using TreinamentosCorp.API.Infra.Data.Repositories;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
//       DATABASE
// -------------------------
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    )
);

// -------------------------
//       DEPENDÊNCIAS
// -------------------------
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

builder.Services.AddScoped<ICertificadoRepository, CertificadoRepository>();
builder.Services.AddScoped<ICertificadoService, CertificadoService>();

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialService, MaterialService>();

builder.Services.AddScoped<IProgressoCursoRepository, ProgressoCursoRepository>();
builder.Services.AddScoped<IProgressoCursoService, ProgressoCursoService>();

builder.Services.AddScoped<IRelatorioService, RelatorioService>();

builder.Services.AddScoped<IModuloRepository, ModuloRepository>();


// -------------------------
//       MVC / SWAGGER
// -------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Garante que a pasta Uploads existe
var uploadsPath = Path.Combine(builder.Environment.ContentRootPath, "Uploads");
Directory.CreateDirectory(uploadsPath);

// -------------------------
//       MIDDLEWARES
// -------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

app.UseAuthorization();
app.MapControllers();
app.Run();


// ✅ Permite acesso à pasta "Uploads"
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Uploads")
    ),
    RequestPath = "/uploads"
});

app.UseAuthorization();
app.MapControllers();
app.Run();
