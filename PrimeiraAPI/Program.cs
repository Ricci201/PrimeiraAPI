using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add os serviços básicos para a aplicação, como controladores e OpenAPI.

builder.Services.AddControllers();

// Add OpenAPI (Necessário para gerar a documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// builder.Build() => É onde a aplicação é construída.
var app = builder.Build();

// Pipeline de processamento de requisições HTTP/HTTPS.
if (app.Environment.IsDevelopment())
{
    // Endpoint OpenAPI.
    app.MapOpenApi();

    // Interface do Scalaro para testar a API.
    app.MapScalarApiReference(options =>
    {
        options.Title = "Primeira API com Scalar";
        options.Theme = ScalarTheme.Default;
        options.ShowSidebar = true;
    });

    // Redireciona a pagina raiz "/" para "/scalar"
    app.MapGet("/", () => Results.Redirect("/scalar")); 
}

// Redireciona todas as requisições HTTP para HTTPS.
app.UseHttpsRedirection();

// Middleware de autorização (pode ser configurado para proteger endpoints específicos).
app.UseAuthorization();

// Mapeia os controladores para os endpoints da API.
app.MapControllers();

// Inicia a aplicação e começa a escutar as requisições.
app.Run();

