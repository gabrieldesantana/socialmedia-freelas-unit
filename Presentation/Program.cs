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

//GET api/freelancers/
app.MapGet(@"/api/freelancers", async (IFreelancerService service) => 
await service.GetAllAsync());

//GET api/freelancers/1
app.MapGet(@"/api/freelancers/{id:int}", async (int id, IFreelancerService service) =>
await service.GetByIdAsync(id));

//POST api/freelancers/
app.MapPost(@"/api/freelancers", async ([FromBody] FreelancerInputModel inputModel, IFreelancerService service) 
=> await service.PostAsync(inputModel));

//PUT api/freelancers/1
app.MapPut(@"/api/freelancers/{id:int}", async (int id, [FromBody] FreelancerUpdateModel updateModel, IFreelancerService service) =>
await service.PutAsync
(
    id, 
    new Freelancer(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone, updateModel.PretensaoSalarial) )
);

//DELETE api/freelancers/1
app.MapDelete(@"/api/freelancers/{id:int}", async (int id, IFreelancerService service) =>
 await service.DeleteAsync(id));

#endregion

#region ClientesEndpoint
//// CLIENTE
//GET 
app.MapGet(@"/api/clientes",  (AppDbContext context) => 
     context.Clientes.Select(x => new ClienteViewModel
    {
        Nome = x.Nome,
        NumeroDocumento = x.NumeroDocumento,
        DataNascimento = x.DataNascimento,
        Email = x.Email,
        Telefone = x.Telefone,
    }).ToList()
);
//GET/1
app.MapGet(@"/api/clientes/{id:int}", (int id, AppDbContext context) => 
    context.Clientes.FirstOrDefault(x => x.Id == id));
//POST
app.MapPost(@"/api/clientes", ([FromBody] ClienteInputModel inputModel, AppDbContext context) 
=> context.Clientes.Add(new Cliente(
    inputModel.Nome,
    inputModel.NumeroDocumento,
    inputModel.DataNascimento,
     inputModel.Email,
      inputModel.Telefone,
       inputModel.Senha)));
//PUT
app.MapPut(@"/api/clientes/{id:int}", (int id, AppDbContext context) => 
{
    var cliente = context.Clientes.FirstOrDefault(x => x.Id == id);
    return cliente;
});
//DELETE
app.MapDelete(@"/api/clientes/{id:int}", (int id, AppDbContext context) => 
{
    var cliente = context.Clientes.FirstOrDefault(x => x.Id == id);
    cliente!.Actived = false;
    return cliente;
});
#endregion

#region VagasEndpoint
//// VAGA
//GET 
app.MapGet(@"/api/vagas", (AppDbContext context) => 
    context.Vagas.Select(x => new VagaViewModel 
    {
        Titulo = x.Titulo,
        Descricao = x.Descricao,
        Cargo = x.Cargo,
        Tipo = x.Tipo,
        Remuneracao = x.Remuneracao
    }).ToList()
);
//GET/1
app.MapGet(@"/api/vagas/{id:int}",  (int id, AppDbContext context) => 
    context.Vagas.FirstOrDefault(x => x.Id == id));
//POST
app.MapPost(@"/api/vagas", ([FromBody] VagaInputModel inputModel, AppDbContext context) 
=> context.Vagas.Add(new Vaga(
    inputModel.Titulo,
    inputModel.Descricao,
     inputModel.Cargo,
      inputModel.Tipo,
      inputModel.Remuneracao,
       inputModel.ClienteId)));
//PUT
app.MapPut(@"/api/vagas/{id:int}", (int id, AppDbContext context) => 
{
    var vaga = context.Vagas.FirstOrDefault(x => x.Id == id);
    return vaga;
});
//DELETE
app.MapDelete(@"/api/vagas/{id:int}", (int id, AppDbContext context) => 
{
    var vaga = context.Vagas.FirstOrDefault(x => x.Id == id);
    vaga!.Actived = false;
    return vaga;
});
#endregion

#region ExperienciasEndpoint
//// EXPERIENCIA
//GET 
app.MapGet(@"/api/experiencias", (AppDbContext context) => 
    context.Experiencias.Select(x => new ExperienciaViewModel 
    {
        FreelancerId = x.FreelancerId,
        Projeto = x.Projeto,
        Empresa = x.Empresa,
        Tecnologia = x.Tecnologia,
        Valor = x.Valor,
        Avaliacao = x.Avaliacao,
    }).ToList()
);
//GET/1
app.MapGet(@"/api/experiencias/{id:int}", (int id, AppDbContext context) => 
    context.Experiencias.FirstOrDefault(x => x.Id == id));
//POST
app.MapPost(@"/api/experiencias", ([FromBody] ExperienciaInputModel inputModel, AppDbContext context) 
=> context.Experiencias.Add(new Experiencia(
    inputModel.UsuarioId,
    inputModel.Projeto,
    inputModel.Empresa,
     inputModel.Tecnologia,
      inputModel.Valor,
       inputModel.Avaliacao)));
//PUT
app.MapPut(@"/api/experiencias/{id:int}", (int id, AppDbContext context) => 
{
    var experiencia = context.Experiencias.FirstOrDefault(x => x.Id == id);
    return experiencia;
});
//DELETE
app.MapDelete(@"/api/experiencias/{id:int}", (int id, AppDbContext context) => 
{
    var experiencia = context.Experiencias.FirstOrDefault(x => x.Id == id);
    experiencia!.Actived = false;
    return experiencia;
});
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMediaFreelas.API v1");
    });
}

app.Run();
