using FileSaverShowerSystem.Abstractions;
using FileSaverShowerSystem.Constants;
using FileSaverShowerSystem.Options;

var builder = WebApplication.CreateBuilder(args);
var localFileManagerOptions = builder.Configuration.GetSection(LocalFileManagerConstants.LocalFileManagerSection);
builder.Services.Configure<LocalFileManagerOptions>(localFileManagerOptions);
builder.Services.AddScoped<IFileManagerService, FileSaverShowerSystem.Service.FileManagerService>();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseSwaggerUI();
app.UseSwagger();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();