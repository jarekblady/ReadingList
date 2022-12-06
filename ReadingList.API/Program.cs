using Microsoft.EntityFrameworkCore;
using ReadingList.API.Entities;
using ReadingList.API.Repositories.BookRepository;
using ReadingList.API.Repositories.CategoryRepository;
using ReadingList.API.Services.BookService;
using ReadingList.API.Services.CategoryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookConnectionString")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

app.UseHttpsRedirection();
app.UseCors("ReactJSDomain");

app.UseAuthorization();

app.MapControllers();

app.Run();
