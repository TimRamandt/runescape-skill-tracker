open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Diffinator
open SyncDb
open Context
open System.Linq

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()
    let context = createContext(DatabaseType.SQLite)
    context.EnsureDatabaseCreated() |> ignore
    let syncRepo = new SyncDb.Repository(context)


    app.MapGet("/", Func<string>(fun () -> 
        syncRepo.getSynchronisationsAsync() 
            |> Async.RunSynchronously 
            |> Seq.last 
            |> fun sync -> sync.data)) |> ignore

    app.MapGet("/diff", Func<string>(fun () -> Diffinator.LatestDiff(syncRepo) |> String.concat "\n")) |> ignore

    app.Run()

    0 // Exit code

