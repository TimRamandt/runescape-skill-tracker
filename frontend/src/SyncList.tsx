import { useEffect, useState } from "react";
import { Sync } from "./types";

const SyncList = () => {
    const [loading, setLoading] = useState<boolean>() 
    const [syncs, setSyncs] = useState<Sync[] | undefined>()
    //TO DO maybe add some kind of filter instead of requesting all
    const fetchSyncs = async (): Promise<Sync[]> => {
        const response = await fetch("http://localhost:5268/syncs")
        if (!response.ok) {
           throw new Error('Network response was not ok');
        }
        return await response.json();
    }

    useEffect(() => {
        const startState = async () => {
          try {
            setSyncs(await fetchSyncs())
            setLoading(false);
          } catch (error) {
            console.error('Error fetching data:', error);
            setLoading(false); 
          }
        }
        startState();
    }, []) 

    if (loading) {
      return <>
         Loading...
      </>;
    }

  console.log(syncs)
  return (
    <>
       {syncs?.map(s => <div><a href="">{s.createdAt}</a></div>)}
    </>
  );
}

export default SyncList