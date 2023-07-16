using apiwise.Data;
using apiwise.Helps;
using apiwise.Interface;
using apiwise.Mapper;
using apiwise.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

var MyCors = "MyCors";
var VersionApi = "v2_2";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(p => p.AddPolicy(MyCors, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(VersionApi, new OpenApiInfo
    {
        Title = "My API",
        Version = VersionApi,
        Description = "An API WISE"
    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(AutomapperProfiles.ProfilesConfig, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("ConnectionDB"),
        ServerVersion.Parse("5.7.34-mysql"));
        options.EnableSensitiveDataLogging();
    });
builder.Services.AddDbContext<DataContextProcedures>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("ConnectionDB"),
        ServerVersion.Parse("5.7.34-mysql"));
        options.EnableSensitiveDataLogging(true);
    });
builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
var appSettingsSection = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSetting = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSetting.JwtSettings.secret);
// dentro de esta sección estamos configurando la autenticación y estableciendo el esquema predeterminado
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(opt =>
 {
     opt.RequireHttpsMetadata = false;
     opt.SaveToken = true;
     opt.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(key),
         ValidateIssuer = false,
         ValidateAudience = false,
         ValidateLifetime = true,
     };
 });
//Registro de interfaces
builder.Services.AddScoped<IUserService, ServicesUsuario>();
builder.Services.AddScoped<IProcedureSql, ServiceProcedureSql>();
builder.Services.AddScoped<ILoggerWise, ServicioLogger>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddScoped<IHostedService,MyHostedService>();
//builder.Services.AddHostedService<MyHostedService>();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});


var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}
// Configure the HTTP request pipeline.
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.SwaggerEndpoint($"/swagger/{VersionApi}/swagger.json", $"API {VersionApi}");
    // custom CSS
    c.InjectStylesheet("/swagger-ui/custom.css");
});
app.Use(async (ctx, next) => { await next(); if (ctx.Response.StatusCode == 204) { ctx.Response.ContentLength = 0; } });
app.UseHttpsRedirection();
// AÑADIMOS EL MIDDLEWARE DE SWAGGER (NSwag)
app.UseRouting();
if (app.Environment.IsProduction() || app.Environment.IsStaging())
{
    app.UseExceptionHandler("/Error/index.html");
}

app.UseCors(MyCors);
app.UseAuthorization();
app.MapControllers();
app.Run();
