module Diffinator
open Models.Sync
open Newtonsoft.Json
open SkillEntry

let calculateDiff(startSync: Synchronisation, endSync: Synchronisation) =
     let mutable diff : string list = []
     let startData : SkillEntry.Entry[]  = JsonConvert.DeserializeObject<SkillEntry.Entry[]>(startSync.data);
     let endData : SkillEntry.Entry[]  = JsonConvert.DeserializeObject<SkillEntry.Entry[]>(endSync.data);
     for i in 0 .. startData.Length-1  do 
         diff <- sprintf "%d,%d,%d" endData[i].Level (startData[i].Rank - endData[i].Rank) (endData[i].XP-startData[i].XP) :: diff 
     diff |> List.rev
