# WebAPI for Ludo game



Status for main build:
[![Build status](https://dev.azure.com/olssonolof/Hackerman%20Fia%20web%20api/_apis/build/status/Hackerman%20Fia%20web%20api-ASP.NET%20Core-CI)](https://dev.azure.com/olssonolof/Hackerman%20Fia%20web%20api/_build/latest?definitionId=3)


## API

#### Link to published API
~~http://ludoapi.azurewebsites.net/api/ludo/~~
Update:
The API was published on Azure Cloud services but has now been deleted. 



#### Postman
We test the published API on Postman. Through the API we have created methods to:

Created a team on Postman to share and collabare all the test for the Api.
Loaded the API Yaml documentation in to the api and added local variables to test the api on both local adress and on the published API.

![Screenshot](https://github.com/PGBFDH18/ludo-web-api-hackermanludo/blob/master/docs/Images/Postman.PNG)


- [x] `POST` - create game sessions

- [x] `GET` - get saved game sessions

- [x] `GET` - get the game session you are currently playing

- [x] `GET` - load saved game

- [x] **Save to local JSON** - `POST`

- [x] **Update saved game** - `PUT`

- [x] **Load saved game** - `GET`

- [x] **Delete saved game** - `DELETE`

- [x] **Load game info each dicethrow** - `GET`

#### Path for pieces
- [x] `GET:` *Who's turn, dice throw, position of pieces*

- [x] `PUT:` *Update piece position*


#### Path for game
- [x] `GET:` *Get list of games*

- [x] `POST:` *Create New game*

- [x] `DELETE:` *Get rid of game*


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
- [ ] On Azure we have published API and database.

## DevOps
- [x] Handling structure of building application, API and database.

- [x] Handling strutucre of workload by using the built in *Boards*.

- [x] Unit testing through *Builds* in *Pipelines*.

![Screenshot](https://github.com/PGBFDH18/ludo-web-api-hackermanludo/blob/master/docs/Images/DevOps%20Overview.png)

![Screenshot](https://github.com/PGBFDH18/ludo-web-api-hackermanludo/blob/master/docs/Images/DevOps%20Backlog.PNG)

![Screenshot](https://github.com/PGBFDH18/ludo-web-api-hackermanludo/blob/master/docs/Images/DevOps%20Boards.PNG)

![Screenshot](https://github.com/PGBFDH18/ludo-web-api-hackermanludo/blob/master/docs/Images/DevOps%20Pipeline.PNG)



## GameEngine

#### Add functionallity for saving
- [x] Save game in json format.
- [x] Data is kept in app untill user saves game. Then data is saved to a local JSON file.

#### Logic for loading game
- [x] Load game in json format. 

#### Add function so you can finish

- [x] New testbranch in GameEngine created. Possibly a lot of changes needed in GameEngine. *2019-01-21*

## Console APP
- [x] Create a console app to run Ludo game from API. 

## TestOfEngine
- [x] In solution for LudoWebApi we have a project called TestOfEngine for a simple way of testing the functions of the model *GamSession*.





## Other

- [x] Add comments in code

- [x] YAML documentation

- [x] Add GUI for GameEngine

- [x] Clean up documentation

- [ ] Easteregg



