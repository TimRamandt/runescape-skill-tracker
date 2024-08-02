import { useState, useEffect } from 'react'
import SkillRow from './SkillRow';
import { SkillEntry, DiffEntry, Entry } from './types';

function App() {
  const [entries, setEntries] = useState<Entry[]>()
  const [loading, setLoading] = useState<boolean>()

  const fetchSkills = async () => {
    const response = await fetch("http://localhost:5268/", {method: "GET"}) 
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return await response.json();
  }

  const fetchDiff = async () => {
    const response = await fetch("http://localhost:5268/diff", {method: "GET"}) 
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    const rawDiff = await response.text()
    const diffEntries: DiffEntry[] = rawDiff.split(`\n`).map(line => {
         const [NewLevel, RankChange, XPGained] = line.split(',').map(Number);
         return { NewLevel, RankChange, XPGained };
    });
    return diffEntries;
  }
    useEffect(() => {
      const startState = async() => {
      try {
        const [skills, diff] = await Promise.all([fetchSkills(), fetchDiff()]);
        const entries: Entry[] = skills.map((skill: SkillEntry, index: number) => ({
            ...skill,
            ...diff[index]
        }))
        setEntries(entries)
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false); 
      }
    };
      startState()
    }, []);

    if (loading) {
      return <>
         Loading...
      </>;
    }

  return (
    <>
    {entries?.map(e => <SkillRow entry={e}/>)}
    </>
  );
}

export default App
