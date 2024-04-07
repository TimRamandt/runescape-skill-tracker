module SyncDb 

open Context
open Models.Sync
open Microsoft.EntityFrameworkCore
open System;

type Repository(ctx: Context) =
    member this.Ctx = ctx

    member this.getSynchronisationsAsync(): Async<Synchronisation[]> =
        async {
            let! syncs = this.Ctx.Synchronisations.ToArrayAsync() |> Async.AwaitTask
            return syncs
        }
    
    member this.addSynchronisationAsync(sync: Synchronisation) =
        this.Ctx.Synchronisations.AddAsync(sync).AsTask() |> Async.AwaitTask |> ignore 
        this.Ctx.SaveChangesAsync() |> Async.AwaitTask   

    member this.findSynchronisationByDateAsync(date: DateTime): Async<Synchronisation option> =
      async {
          let query = query {
              for sync in this.Ctx.Synchronisations do
              where (sync.createdAt = date)
              select sync
          }

          return query |> Seq.tryFind(fun _ -> true)
      }
