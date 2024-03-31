open System.Net.Http
open System
open SkillEntry
open SyncDb
open Models.Sync
open Newtonsoft.Json
open Context

let fetchProgress(name: string) = 
    async {
        let webClient = new HttpClient()
        let! response = webClient.GetAsync("https://secure.runescape.com/m=hiscore/index_lite.ws?player="+name) |> Async.AwaitTask  
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return content
    }

let filterSkills(body: string) = 
   let data = body.Split '\n' |> Array.take 30 
   let mutable skills : SkillEntry.Entry list = []
   for i in 0 .. data.Length-1 do 
      let dataEntry = data[i].Split ','
      let entry = {
        Name = SkillEntry.skills[i]
        Rank = int dataEntry[0];
        Level = int dataEntry[1];
        XP = int64 dataEntry[2]
      }
      skills <- entry :: skills 
   skills |> List.rev


let parseToJson(skills: SkillEntry.Entry list) =
   JsonConvert.SerializeObject(skills)

   
[<EntryPoint>]
let main argv = 
    let context = createContext(DatabaseType.SQLite)
    context.EnsureDatabaseCreated() |> ignore
    let syncRepo = SyncDb.Repository(context)

    printfn "enter thy name:"
    let name = Console.ReadLine()
    let skills = name |> fetchProgress |> Async.RunSynchronously |> filterSkills |> parseToJson
    let sync = Synchronisation(data = skills, createdAt = DateTime.Now)
    syncRepo.addSynchronisationAsync(sync) |> Async.RunSynchronously |> ignore
    printfn "done"
    0