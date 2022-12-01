using Microsoft.EntityFrameworkCore;
using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.DataAccess.Repository;
using NegosudAPI.Service.Middleware;
using NegosudAPI.Service;
using NegosudAPI.Business;
using NegosudAPI.Utils.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IRepository<UtilisateurDAO, UtilisateurDTO, string>, UtilisateurRepo>();
builder.Services.AddTransient<IRepository<PanierDAO, PanierDTO, int>, PanierRepo>();
builder.Services.AddTransient<IRepository<FournisseurDAO, FournisseurDTO, int>, FournisseurRepo>();
builder.Services.AddTransient<IRepository<FamilleDAO, FamilleDTO, int>, FamilleRepo>();
builder.Services.AddTransient<IRepository<ConnexionDAO, ConnexionDTO, int>, ConnexionRepo>();
builder.Services.AddTransient<IRepository<CommandeDAO, CommandeDTO, int>, CommandeRepo>();
builder.Services.AddTransient<IRepository<CommandeArticleDAO, CommandeArticleDTO, int>, CommandeArticleRepo>();
builder.Services.AddTransient<IRepository<PanierDAO, PanierDTO, int>, PanierRepo>();
builder.Services.AddTransient<IRepository<ArticleDAO, ArticleDTO, int>, ArticleRepo>();
builder.Services.AddTransient<IRepository<FamilleDAO, FamilleDTO, int>, FamilleRepo>();
builder.Services.AddTransient<IRepository<ApplicationDAO, ApplicationDTO, int>, ApplicationRepo>();
builder.Services.AddTransient<IRepository<AchatDAO, AchatDTO, int>, AchatRepo>();



builder.Services.AddTransient<IBusiness<UtilisateurDTO, string>, UtilisateurService>();
builder.Services.AddTransient<IBusiness<PanierDTO, int>, PanierService>();
builder.Services.AddTransient<IBusiness<FournisseurDTO, int>, FournisseurService>();
builder.Services.AddTransient<IBusiness<FamilleDTO, int>, FamilleService>();
builder.Services.AddTransient<IBusiness<ConnexionDTO, int>, ConnexionService>();
builder.Services.AddTransient<IBusiness<CommandeDTO, int>, CommandeService>();
builder.Services.AddTransient<IBusiness<CommandeArticleDTO, int>, CommandeArticleService>();
builder.Services.AddTransient<IBusiness<PanierDTO, int>, PanierService>();
builder.Services.AddTransient<IBusiness<ArticleDTO, int>, ArticleService>();
builder.Services.AddTransient<IBusiness<FamilleDTO, int>, FamilleService>();
builder.Services.AddTransient<IBusiness<ApplicationDTO, int>, ApplicationService>();
builder.Services.AddTransient<IBusiness<AchatDTO, int>, AchatService>();
//builder.Services.AddTransient<IUserService, UserService>();
// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))

 );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
