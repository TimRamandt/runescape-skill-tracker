open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.Extensions.DependencyInjection
open Diffinator
open SyncRepository
open Context
open Newtonsoft.Json
open Microsoft.AspNetCore.Http

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
    let syncRepo = new SyncRepository.Repository(context)


    app.MapGet("/", Func<string>(fun () -> 
        syncRepo.getSynchronisationsAsync() 
            |> Async.RunSynchronously 
            |> Seq.last 
            |> fun sync -> sync.data)) |> ignore

    app.MapGet("diff", Func<HttpContext ,string>(fun (ctx: HttpContext) -> 
       match ctx.Request.Query.["id"] |> Seq.toList with
       | [value] -> value
       | [] -> Diffinator.LatestDiff(syncRepo) |> String.concat "\n"
       | _ -> "Ignored multiple values."
    )) |> ignore



    app.MapGet("/syncs", Func<string>(fun () -> 
        syncRepo.getSynchronisationsAsync() |> Async.RunSynchronously |> JsonConvert.SerializeObject))
        |> ignore


    app.Run()

    0 // Exit code

