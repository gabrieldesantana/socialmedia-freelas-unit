using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFreelancerService, FreelancerService>();
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<IExperienciaService, ExperienciaService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<IExperienciaService, ExperienciaService>();

var connectionString = builder.Configuration.GetConnectionString("SqliteConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialMediaFreelas.API", Description = "Backend for SocialMediaFreelasApp", Version = "v1" });
});



var app = builder.Build();

#region ObjetosEndpoint
app.MapGet("/", () =>
{
    var listaObjects = new List<object>();

    listaObjects.Add(new ClienteViewModel());
    listaObjects.Add(new FreelancerViewModel());
    listaObjects.Add(new VagaViewModel());
    listaObjects.Add(new ExperienciaViewModel());
    return listaObjects;
});
#endregion

#region FreelancersEndpoint
app.MapGet(@"/api/freelancers", async (IFreelancerService service) => 
await service.GetAllAsync());

app.MapGet(@"/api/freelancers/{id:int}", async (int id, IFreelancerService service) =>
await service.GetByIdAsync(id));

app.MapPost(@"/api/freelancers", async ([FromBody] FreelancerInputModel inputModel, IFreelancerService service) 
=> await service.PostAsync(inputModel));

app.MapPut(@"/api/freelancers/{id:int}", async (int id, [FromBody] FreelancerUpdateModel updateModel, IFreelancerService service) =>
await service.PutAsync
(
    id, 
    new Freelancer(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone, updateModel.PretensaoSalarial) )
);

app.MapDelete(@"/api/freelancers/{id:int}", async (int id, IFreelancerService service) =>
 await service.DeleteAsync(id));

#endregion

#region ClientesEndpoint
app.MapGet(@"/api/clientes", async (IClienteService service) =>
await service.GetAllAsync());

app.MapGet(@"/api/clientes/{id:int}", async (int id, IClienteService service) =>
await service.GetByIdAsync(id));

app.MapPost(@"/api/clientes", async ([FromBody] ClienteInputModel inputModel, IClienteService service)
=> await service.PostAsync(inputModel));

app.MapPut(@"/api/clientes/{id:int}", async (int id, [FromBody] ClienteUpdateModel updateModel, IClienteService service) =>
await service.PutAsync
(
    id,
    new Cliente(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone))
);

app.MapDelete(@"/api/clientes/{id:int}", async (int id, IClienteService service) =>
 await service.DeleteAsync(id));
#endregion

#region VagasEndpoint
//GET 
app.MapGet(@"/api/vagas", async (IClienteService service) =>
await service.GetAllAsync());
//GET/1
app.MapGet(@"/api/vagas/{id:int}", async (int id, IClienteService service) =>
await service.GetByIdAsync(id));
//POST
app.MapPost(@"/api/vagas", async ([FromBody] FreelancerInputModel inputModel, IClienteService service)
=> await service.PostAsync(inputModel));
//PUT
app.MapPut(@"/api/vagas/{id:int}", async (int id, [FromBody] FreelancerUpdateModel updateModel, IClienteService service) =>
await service.PutAsync
(
    id,
    new Freelancer(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone, updateModel.PretensaoSalarial))
);
//DELETE
app.MapDelete(@"/api/vagas/{id:int}", async (int id, IClienteService service) =>
 await service.DeleteAsync(id));
#endregion

//#region ExperienciasEndpoint
////// EXPERIENCIA
////GET 
//app.MapGet(@"/api/experiencias", async (IClienteService service) =>
//await service.GetAllAsync());
////GET/1
//app.MapGet(@"/api/experiencias/{id:int}", async (int id, IClienteService service) =>
//await service.GetByIdAsync(id));
////POST
//app.MapPost(@"/api/experiencias", async ([FromBody] FreelancerInputModel inputModel, IClienteService service)
//=> await service.PostAsync(inputModel));
////PUT
//app.MapPut(@"/api/experiencias/{id:int}", async (int id, [FromBody] FreelancerUpdateModel updateModel, IClienteService service) =>
//await service.PutAsync
//(
//    id,
//    new Freelancer(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone, updateModel.PretensaoSalarial))
//);
////DELETE
//app.MapDelete(@"/api/experiencias/{id:int}", async (int id, IClienteService service) =>
// await service.DeleteAsync(id));
//#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMediaFreelas.API v1");
    });
}

app.Run();
