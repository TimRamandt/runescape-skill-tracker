# RuneScape Skill Tracker 
Installation info coming soon™


## Development

### Run Backend locally:
The backend is written in F#, in `.NET v6`. this contains all the data.
Start the backend with `dotnet run --project .\Backend\Backend.fsproj` or run with Visual Studio.

#### Database
Database is SQLite, currently no dummy database provided, this will change in the future.

#### Unit tests
There are unit tests, so it doesn't constantly pull data from the RuneScape hiscores. It is best to test functionality here.

##### Running the converter
Since new lines in Windows end with `\r\n`, I made a quick script to make it them end with `\n`.
This converter is only used for testing purposes.

```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

After running the script, you can disable this setting again, should you wish with:
```powershell
Set-ExecutionPolicy Restricted -Scope CurrentUser
```

### Run the frontend locally:
The frontend is written in React. Nodejs is required, with atleast version `20.12.2`.
To run the frontend: 
```
cd frontend
npm run dev
```
Install the packages with `npm install` if its the first time running this project.