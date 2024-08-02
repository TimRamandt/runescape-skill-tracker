export type SkillEntry  = {
    Name: string
    Rank: number
    Level: number
    XP: number
}

export type DiffEntry = {
    NewLevel: number,
    RankChange: number,
    XPGained: number,
}

export type Entry = SkillEntry & DiffEntry;