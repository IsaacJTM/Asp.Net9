var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

//No sigue los principios de REST
app.MapPost("createrUser", (HttpContext context)=>{
    var user = new {Id = Guid.NewGuid(), Name = "Jhon Doe", Email = "correo@correo.com"};
    return Results.Ok(user);
}
);

//Sigue los principios de REST
app.MapPost("user",(HttpContext context)=>{
    var user = new {Id = Guid.NewGuid(), Name = "Isaac Jhon", Email = "correo@correo.com"};
    return Results.Created($"user/{user.Id}",user);
});


//Vamos a recibir parámetros}
//Esto es un síncrno (espera que termine una respuesta para continuar con la otra)
app.MapPost("beer",(HttpContext context)=>{
    var requestBody = context.Request.ReadFromJsonAsync<Bear>().Result;
    if(requestBody == null || string.IsNullOrWhiteSpace(requestBody.name)){
        return Results.BadRequest("Respuesta Invalida");
    }
    //Para renterizar 
    Thread.Sleep(2000);

    var beer = new Bear(Guid.NewGuid(), requestBody.name);
    return Results.Created($"beer/{beer.id}", beer);
});

app.MapPost("wine", async (HttpContext context)=>
{

//Manejamos lo que es el task, async and await (Asíncrono)
    var requestBody = await context.Request.ReadFromJsonAsync<Wine>();
    if(requestBody == null || string.IsNullOrWhiteSpace(requestBody.name)){
        return Results.BadRequest("Respuesta Invalida");
    }

    Thread.Sleep(2000);

    var wine = new Wine(Guid.NewGuid(), requestBody.name);
    return Results.Created($"wine/{wine.id}", wine);

});
app.Run();

//Creamos objetos 
record Bear(Guid id, string name);
record Wine(Guid id, string name);