using agendamento_webapi.Data;
using agendamento_webapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        InitializeDb(context);
    }
    catch (Exception ex)
    {
        // Trate qualquer erro relacionado � inicializa��o do banco de dados aqui.
        Console.WriteLine("Erro na inicializa��o do banco de dados: " + ex.Message);
    }
}

app.Run();

// Fun��o para inicializar o banco de dados
void InitializeDb(AppDbContext context)
{
    context.Database.EnsureCreated();

    if (!context.Medicos.Any())
    {
        var medicos = new List<Medico>
        {
            new Medico
            {
                Nome = "Dr. Jo�o",
                Especialidade = "Cardiologia",
                NumeroRegistroProfissional = "12345",
                ConsultasAgendadas = new List<Consulta>()
            },
            new Medico
            {
                Nome = "Dra. Maria",
                Especialidade = "Dermatologia",
                NumeroRegistroProfissional = "67890",
                ConsultasAgendadas = new List<Consulta>()
            }
            // Adicione mais m�dicos conforme necess�rio
        };

        context.Medicos.AddRange(medicos);
        context.SaveChanges();
    }
}
