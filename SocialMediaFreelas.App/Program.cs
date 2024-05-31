using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRegisterServices(builder.Configuration);

var app = builder.Build();

const string tenantId = "B4ck3ndS0c14lM3d14";

#region FreelancersEndpoint
app.MapGet(@"/api/freelancers", async (IFreelancerService service) =>
await service.GetAllAsync())
.WithSummary("Retorna todos os freelancers")
.WithDescription("GET - Retorna todos os freelancers");

app.MapGet(@"/api/freelancers/{id:int}", async (int id, IFreelancerService service) =>
await service.GetByIdAsync(id))
.WithSummary("Retorna freelancer por Id")
.WithDescription("GET - Retorna freelancer por Id");

app.MapPost(@"/api/freelancers", async ([FromBody] FreelancerInputModel inputModel, IFreelancerService service)
=> await service.PostAsync(inputModel))
.WithSummary("Adiciona freelancer")
.WithDescription("POST - Adiciona freelancer");

app.MapPut(@"/api/freelancers/{id:int}", async (int id, [FromBody] FreelancerUpdateModel updateModel, IFreelancerService service) =>
await service.PutAsync
(
    id,
    new Freelancer(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone, updateModel.PretensaoSalarial))
)
.WithSummary("Atualiza freelancer")
.WithDescription("PUT - Atualiza freelancer");

app.MapDelete(@"/api/freelancers/{id:int}", async (int id, IFreelancerService service) =>
await service.DeleteAsync(id))
.WithSummary("Remove freelancer")
.WithDescription("DELETE - Remove freelancer");

#endregion

#region ClientesEndpoint
app.MapGet(@"/api/clientes", async (IClienteService service) =>
await service.GetAllAsync())
.WithSummary("Retorna todos os clientes")
.WithDescription("GET - Retorna todos os clientes");

app.MapGet(@"/api/clientes/{id:int}", async (int id, IClienteService service) =>
await service.GetByIdAsync(id))
.WithSummary("Retorna cliente por Id")
.WithDescription("GET - Retorna cliente por Id");

app.MapPost(@"/api/clientes", async ([FromBody] ClienteInputModel inputModel, IClienteService service)
=> await service.PostAsync(inputModel))
.WithSummary("Adiciona cliente")
.WithDescription("POST - Adiciona cliente");

app.MapPut(@"/api/clientes/{id:int}", async (int id, [FromBody] ClienteUpdateModel updateModel, IClienteService service) =>
await service.PutAsync
(
    id,
    new Cliente(updateModel.Nome, updateModel.NumeroDocumento, updateModel.DataNascimento, updateModel.Email, updateModel.Telefone))
)
.WithSummary("Atualiza cliente")
.WithDescription("PUT - Atualiza cliente");

app.MapDelete(@"/api/clientes/{id:int}", async (int id, IClienteService service) =>
 await service.DeleteAsync(id))
.WithSummary("Remove cliente")
.WithDescription("DELETE - Remove cliente");
#endregion

#region VagasEndpoint

app.MapGet(@"/api/vagas", async (IVagaService service) =>
await service.GetAllAsync(tenantId))
.WithSummary("Retorna todos os vagas")
.WithDescription("GET - Retorna todos os vagas");

app.MapGet(@"/api/vagas/{id:int}", async (int id, IVagaService service) =>
await service.GetByIdAsync(id, tenantId))
.WithSummary("Retorna vaga por Id")
.WithDescription("GET - Retorna vaga por Id");

app.MapPost(@"/api/vagas", async ([FromBody] VagaInputModel inputModel, IVagaService service)
=> await service.PostAsync(inputModel))
.WithSummary("Adiciona vaga")
.WithDescription("POST - Adiciona vaga");

app.MapPut(@"/api/vagas/{id:int}", async (int id, [FromBody] VagaUpdateModel updateModel, IVagaService service) =>
await service.PutAsync
(
    id,
    new Vaga(updateModel.Titulo, updateModel.Descricao, updateModel.Cargo, updateModel.Tipo, updateModel.Remuneracao),
    tenantId)
)
.WithSummary("Atualiza vaga")
.WithDescription("PUT - Atualiza vaga");

app.MapDelete(@"/api/vagas/{id:int}", async (int id, IVagaService service) =>
await service.DeleteAsync(id, tenantId))
.WithSummary("Remove vaga")
.WithDescription("DELETE - Remove vaga");
#endregion

#region ExperienciasEndpoint

app.MapGet(@"/api/experiencias", async (IExperienciaService service) =>
await service.GetAllAsync(tenantId))
.WithSummary("Retorna todos os experiencias")
.WithDescription("GET - Retorna todos os experiencias");

app.MapGet(@"/api/experiencias/{id:int}", async (int id, IExperienciaService service) =>
await service.GetByIdAsync(id, tenantId))
.WithSummary("Retorna experiencia por Id")
.WithDescription("GET - Retorna experiencia por Id");

app.MapPost(@"/api/experiencias", async ([FromBody] ExperienciaInputModel inputModel, IExperienciaService service)
=> await service.PostAsync(inputModel))
.WithSummary("Adiciona experiencia")
.WithDescription("POST - Adiciona experiencia");

app.MapPut(@"/api/experiencias/{id:int}", async (int id, [FromBody] ExperienciaUpdateModel updateModel, IExperienciaService service) =>
await service.PutAsync
(
    id,
    new Experiencia(updateModel.Projeto, updateModel.Empresa, updateModel.Tecnologia, updateModel.Valor, updateModel.Avaliacao),
    tenantId)
)
.WithSummary("Atualiza experiencia")
.WithDescription("PUT - Atualiza experiencia");

app.MapDelete(@"/api/experiencias/{id:int}", async (int id, IExperienciaService service) =>
 await service.DeleteAsync(id, tenantId))
.WithSummary("Remove experiencia")
.WithDescription("DELETE - Remove experiencia");
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMediaFreelas.API v1");
    });

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession(); //added it


app.Run();
