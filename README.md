# RuneScape Skill Tracker 
Installation info coming soon™


## Development
The logic is written in F#.

### Tests
There are unit tests, so it doesn't constantly pull data from the RuneScape hiscores. It is best to test functionality here.

#### Running the converter
Since new lines in Windows end with `\r\n`, I made a quick script to make it them end with `\n`.
This converter is only used for testing purposes.

```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

After running the script, you can disable this setting again, should you wish with:
```powershell
Set-ExecutionPolicy Restricted -Scope CurrentUser
```