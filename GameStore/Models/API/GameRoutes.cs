//using GameStore.Data;
//using GameStore.Models.API;
//using Microsoft.EntityFrameworkCore;
//
//public static class GamesRoutes
//{
    //public static void AddRoutes (this WebApplication app)
    //{
        //var gameRoutes = app.MapGroup("Games");

        //gameRoutes.MapPost("", 
         //   async(AddGamesRequest request, GameDbContext context) =>
       // {

            //var existing = await context.Games.AnyAsync(Game => Game.Id == request.Id);

            //if (existing)
              //  return Results.Conflict("This Game Already Exists!");
       
            //
            //var newGame = new Game(request.Id);
      //      await context.Games.AddAsync(newGame);
        //    await context.SaveChangesAsync();
    //    });
  //  }
//}
