import SkillIcon from "./SkillIcon";
import { SkillEntry } from "./types";



type SkillEntryProps = {
    entry: SkillEntry
}



const SkillRow = ({entry}: SkillEntryProps) => {
    return ( 
    <div style={{display: "flex", flexDirection: "row"}}>
        <SkillIcon name={entry.Name}/> 
       <div>{entry.Name} | {entry.Level} | {entry.Rank} | {entry.XP}</div>
    </div>
    )
}

export default SkillRow;