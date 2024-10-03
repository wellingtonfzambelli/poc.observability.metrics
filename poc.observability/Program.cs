using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Prometheus
//var counter = Metrics.CreateCounter("apiobservability", "Counts requests to the Poc.Observability.Api endpoints");
//app.MapGet("/incrementar", () =>
//{
//    counter.Inc();  // Incrementing the count for each request
//    return "Incremented count!";
//});

app.UseMetricServer(); // setup the middleware of Prometheus to expose the endpoint /metrics
app.UseHttpMetrics();  // add metrics of request and response

app.UseAuthorization();

app.MapControllers();

app.Run();
