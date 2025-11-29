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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
builder.Services.AddScoped<IAssessmentService, AssessmentService>();

builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<ICertificateService, CertificateService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialService, MaterialService>();

builder.Services.AddScoped<IProgressoCursoRepository, CourseProgressRepository>();
builder.Services.AddScoped<ICourseProgressService, CourseProgressService>();

builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddScoped<IModuleRepository, ModuleRepository>();


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
