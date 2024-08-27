open System.Net.Http
open System
open SkillEntry
open SyncRepository
open Models.Sync
open Models.Profile
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

let createProfile context =
    printfn "Enter thy name:"
    let name = Console.ReadLine()
    
    printfn "What game do you play?:"
    printfn "RS3 = 0; OSRS = 1"
    
    let gameInput = Console.ReadLine()
    let gameOption = 
      match gameInput with
        | "0" -> Some Game.RS3
        | "1" -> Some Game.OSRS
        | _ -> None
    
    match gameOption with
    | Some game ->
        let profile = Profile(name = name , game = game) 
        printfn "Profile created for %s playing %A!" name game
        ProfileRepository.Repository(context).addProfileAsync(profile) |> Async.RunSynchronously |> ignore
    | None ->
        printfn "Invalid game selection. Please enter 0 for RS3 or 1 for OSRS."

let createSync context name =
    let syncRepo = SyncRepository.Repository(context)

    let skills = name |> fetchProgress |> Async.RunSynchronously |> filterSkills |> parseToJson
    let sync = Synchronisation(data = skills, createdAt = DateTime.Now)
    syncRepo.addSynchronisationAsync(sync) |> Async.RunSynchronously |> ignore

[<EntryPoint>]
let main argv = 
    let context = createContext(DatabaseType.SQLite)
    context.EnsureDatabaseCreated() |> ignore

    let profiles =  ProfileRepository.Repository(context).getProfilesAsync() |> Async.RunSynchronously 
    match profiles with
     | [||] -> 
        createProfile context
     | _ -> 
       ProfileRepository.Repository(context).getLatestProfileAsync() |> Async.RunSynchronously |> fun (profile: Profile) -> createSync context profile.Name

    printfn "done"
    0