module Context

open Models.Sync
open Microsoft.EntityFrameworkCore


type DatabaseType =
    | InMemory
    | SQLite

type Context(options: DbContextOptions<Context>) = 
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable Synchronisations : DbSet<Synchronisation>

    member public this.Synchronisation 
        with get() = this.Synchronisations 
        and set syncs = this.Synchronisations <- syncs 

    member this.EnsureDatabaseCreated() =
        this.Database.EnsureCreated()

let createContext (dbType: DatabaseType) =
    let options =
        match dbType with
        | InMemory ->
            DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("database_name")
                .Options
        | SQLite ->
            DbContextOptionsBuilder<Context>()
                .UseSqlite("Data Source=db.sqlite")
                .Options

    new Context(options)
