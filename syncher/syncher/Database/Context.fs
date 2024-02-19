module Context

open Models.Sync
open Microsoft.EntityFrameworkCore


type Context = 
   inherit DbContext

    new() = { inherit DbContext() }
    new(options: DbContextOptions<Context>) = { inherit DbContext(options) }

    [<DefaultValue>]
    val mutable syncs : DbSet<Sync>

    member public this.Syncs with get() = this.syncs
                               and set p = this.syncs <- p

    override __.OnConfiguring(optionsBuilder : DbContextOptionsBuilder) =
      optionsBuilder.UseSqlite("db.db")
      |> ignore


