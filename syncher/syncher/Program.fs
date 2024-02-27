open System.Net.Http
open System
open SkillEntry
open SyncRepository
open Models.Sync
open Newtonsoft.Json

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
        XP = uint64 dataEntry[2]
      }
      skills <- entry :: skills 
   skills |> List.rev


let parseToJson(skills: SkillEntry.Entry list) =
   JsonConvert.SerializeObject(skills)

   
[<EntryPoint>]
let main argv = 
    printfn "enter thy name:"
    let name = Console.ReadLine()
    let skills = fetchProgress(name) |> Async.RunSynchronously |> filterSkills |> parseToJson
    let simpleSync = Synchronisation(id = 1, data = skills, createdAt = DateTime.Now)
    SyncRepository.addSynchronisationAsync(simpleSync) |> Async.RunSynchronously |> ignore
    let allSyncs = SyncRepository.getSynchronisationsAsync
    printfn "done"
    0