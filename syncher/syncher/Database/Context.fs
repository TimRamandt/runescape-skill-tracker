module Context

open Models.Sync
open Microsoft.EntityFrameworkCore


type Context = 
   inherit DbContext

    new() = { inherit DbContext() }
    new(options: DbContextOptions<Context>) = { inherit DbContext(options) }

    [<DefaultValue>]
    val mutable Synchronisations : DbSet<Synchronisation>

    member public this.Synchronisation with get() = this.Synchronisations and set syncs = this.Synchronisations <- syncs 


    override __.OnConfiguring(optionsBuilder : DbContextOptionsBuilder) =
      optionsBuilder.UseSqlite("Data Source=db.sqlite")
      |> ignore

    member this.EnsureDatabaseCreated() =
      this.Database.EnsureCreated()

