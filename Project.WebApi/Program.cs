using FluentValidation;
using Project.Bll.DependencyResolvers;
using Project.Validation.FluentValidators.AppUsers;
using Project.WebApi.MapperResolvers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssembly(typeof(CreateAppUserRequestModelValidator).Assembly);


builder.Services.AddDbContextService(); //Context class'ının middleware'e eklenmesi
builder.Services.AddRepositoryService(); //Repository servisinin middleware'e eklenmesi
builder.Services.AddManagerService(); //Manager servisinin middleware'e eklenmesi
builder.Services.AddDtoMapperService(); //Dto mapper servisinin middleware'e eklenmesi
builder.Services.AddVmMapperService(); //Vm Mapper servisinin middleware'e eklenmesi
builder.Services.AddErrorHandlerService(); //Error handler servisinin middleware'a eklenmesi.
builder.Services.AddValidationServices(); // Validationların middleware'a eklenmesi.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
