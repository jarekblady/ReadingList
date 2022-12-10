using Microsoft.EntityFrameworkCore;
using ReadingList.Repository;
using ReadingList.Repository.Context;
using ReadingList.Repository.Repositories.BookRepository;
using ReadingList.Repository.Repositories.CategoryRepository;
using ReadingList.Service.Services.BookService;
using ReadingList.Service.Services.CategoryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookConnectionString")));

//builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    //c.IgnoreObsoleteActions();
    //c.IgnoreObsoleteProperties();
    //c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactJSDomain",
    policy => policy.WithOrigins("https://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API");
    });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BookDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.UseHttpsRedirection();
app.UseCors("ReactJSDomain");

app.UseAuthorization();

app.MapControllers();

app.Run();
