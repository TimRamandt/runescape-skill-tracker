open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.Extensions.DependencyInjection
open Diffinator
open SyncDb
open Context
open System.Linq
open Newtonsoft.Json

let ConfigureServices (services : IServiceCollection) =
    services.AddCors() |> ignore

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    ConfigureServices(builder.Services)

    let app = builder.Build()

    app.UseCors(Action<CorsPolicyBuilder>(fun builder -> 
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() |> ignore
    )) |> ignore

    let context = createContext(DatabaseType.SQLite)
    context.EnsureDatabaseCreated() |> ignore
    let syncRepo = new SyncDb.Repository(context)


    app.MapGet("/", Func<string>(fun () -> 
        syncRepo.getSynchronisationsAsync() 
            |> Async.RunSynchronously 
            |> Seq.last 
            |> fun sync -> sync.data)) |> ignore

    app.MapGet("/diff", Func<string>(fun () -> Diffinator.LatestDiff(syncRepo) |> String.concat "\n")) 
    |> ignore

    app.MapGet("/syncs", Func<string>(fun () -> 
        syncRepo.getSynchronisationsAsync() |> Async.RunSynchronously |> JsonConvert.SerializeObject))
        |> ignore


    app.Run()

    0 // Exit code

