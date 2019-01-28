# WebAPI for Ludo game



Status for main build:
[![Build status](https://dev.azure.com/olssonolof/Hackerman%20Fia%20web%20api/_apis/build/status/Hackerman%20Fia%20web%20api-ASP.NET%20Core-CI)](https://dev.azure.com/olssonolof/Hackerman%20Fia%20web%20api/_build/latest?definitionId=3)


## Database
Create database (SQL). We start with creating the database and connect it to our classes and objects in our C# project.
The database should not include gamelogic.

## API

#### Link to published API
http://ludoapi.azurewebsites.net/api/ludo/game/gameinfo

#### Postman
We test the published API on Postman. Through the API we have created methods to:

`POST` - create game sessions

`GET` - get saved game sessions

`GET` - get the game session you are currently playing

`GET` - load saved game



**Save to local JSON** - `POST`

**Update saved game** - `PUT`

**Load saved game** - `GET`

**Delete saved game** - `DELETE`

**Load game info each dicethrow** - `GET`

#### Path for pieces
`GET:` *Who's turn, dice throw, position of pieces*

`PUT:` *Update piece position*


#### Path for game
`GET:` *Get list of games*

`POST:` *Create New game*

`DELETE:` *Get rid of game*


#### Connect database and API
Database (SQL server) connected to C# project via Entity Framework. Data input in SQL server can be reached through HTTP method `POST` in C# project. Validation of correct data flow through Postman.

*2019-01-23:* Trying to extract data from database to Entity Framework Models. Due to risk of destroying app new branch *HopefullyWorking* created where different approaches can be tested. 
*HopefullyWorking* can extract all data from database to Entity Framework. Merging *HopefullyWorking* with *ApproveOrDie*
Merging *TestSave* with *ApproveOrDie*.

*2019-01-24:* Our goal was to send objects to the database. We changed approach and changed the database to One table and one collumn. The collumn contains all game info as one string. 

*2019-01-25:* Our goal to use SQL in our project failed. Instead we use a local JSON file for saved games.


#### Multiplayer multiple devices
TBA

## Azure

#### API
On Azure we have published API and database.

## DevOps
Handling structure of building application, API and database.

Handling strutucre of workload by using the built in *Boards*.

Unit testing through *Builds* in *Pipelines*.


## GameEngine

#### Add functionallity for saving
Save game in json format.
Data is kept in app untill user saves game. Then data is saved to a local JSON file.

#### Logic for loading game
Load game in json format. 

#### Add function so you can finish

- [x] New testbranch in GameEngine created. Possibly a lot of changes needed in GameEngine. *2019-01-21*

## Console APP
- [x] Create a console app to run Ludo game from API. 





## Other

- [x] Add comments in code

- [x] YAML documentation

- [x] Add GUI for GameEngine

- [x] Clean up documentation

- [ ] Easteregg



