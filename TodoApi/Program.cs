var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var todos = new List<TodoGetDto>
{
    new(1, "Learn C#", true),
    new(2, "Learn ASP.NET Core", false),
    new(3, "Build a web API", false),
};

app.MapGet("/api/todos", () =>
    Results.Ok(todos));

app.MapGet("/api/todos/{id}", (int id) =>
{
    var todo = todos.FirstOrDefault(x => x.Id == id);

    return todo;
});

app.Run();

public record TodoGetDto(int Id, string Name, bool IsComplete);