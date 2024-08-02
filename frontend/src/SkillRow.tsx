import SkillIcon from "./SkillIcon";
import { Entry } from "./types";



type SkillEntryProps = {
    entry: Entry
}



const SkillRow = ({entry}: SkillEntryProps) => {
    return ( 
    <div style={{display: "flex", flexDirection: "row"}}>
        <SkillIcon name={entry.Name}/> 
       <div>{entry.Name} | {entry.Level} ({entry.NewLevel}) | {entry.Rank} ({entry.RankChange})| {entry.XP} + {entry.XPGained}</div>
    </div>
    )
}

export default SkillRow;