
using E_Learning.DAL;
using E_Learning.BL;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

#region Service

//database
builder.Services.AddDbContext<ELearningContext>();

//repos
builder.Services.AddScoped<IUserrepository, Userrepository>();
builder.Services.AddScoped<IUserAnswerrepository, UserAnswerrepository>();
builder.Services.AddScoped<IClassrepository, Classrepository>();
builder.Services.AddScoped<ILecturerepository, Lecturerepository>();

builder.Services.AddScoped<IUserLecturerepository, UserLecturerepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 


//mangers 

builder.Services.AddScoped<IUserManger, UserManger>();
builder.Services.AddScoped<IClassManger, ClassManger>(); 

#endregion
var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
    
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
app.UseCors("AllowAll");


app.MapControllers();

            app.Run();
        
    
