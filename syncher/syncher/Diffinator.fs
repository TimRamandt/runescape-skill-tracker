module Diffinator
open Models.Sync
open Newtonsoft.Json
open SkillEntry
open System
open SyncDb

let calculateDiff(startSync: Synchronisation, endSync: Synchronisation) =
     let mutable diff : string list = []
     let startData : SkillEntry.Entry[]  = JsonConvert.DeserializeObject<SkillEntry.Entry[]>(startSync.data);
     let endData : SkillEntry.Entry[]  = JsonConvert.DeserializeObject<SkillEntry.Entry[]>(endSync.data);
     for i in 0 .. startData.Length-1  do 
         diff <- sprintf "%d,%d,%d" endData[i].Level (startData[i].Rank - endData[i].Rank) (endData[i].XP-startData[i].XP) :: diff 
     diff |> List.rev

let LatestDiff(syncRepo: SyncDb.Repository) =
    let latestSyncs = syncRepo.getSynchronisationsAsync() |> Async.RunSynchronously |> Seq.sortByDescending(fun sync -> sync.createdAt) |> Seq.take 2 |> Seq.toList
    calculateDiff(latestSyncs[1], latestSyncs[0])

let SpecificDiff(startTime: DateTime, endTime: DateTime, syncRepo: SyncDb.Repository) = 
    //call 2 syncs from the specific dateTime
    //call calculateDiff then
    None
