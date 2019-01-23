Put your documentation in this folder!

You can delete this file

Status for main build:
[![Build status](https://dev.azure.com/olssonolof/Hackerman%20Fia%20web%20api/_apis/build/status/Hackerman%20Fia%20web%20api-ASP.NET%20Core-CI)](https://dev.azure.com/olssonolof/Hackerman%20Fia%20web%20api/_build/latest?definitionId=3)



# WebAPI for Ludo game

## Database
Create database (SQL). We start with creating the database and connect it to our classes and objects in our C# project.
The database should not include gamelogic.

## API

**Save to SQL** - `POST`

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




#### Multiplayer multiple devices
TBA

## GameEngine

#### Add functionallity for saving
Save game in json format.
Data is saved locally untill user saves game. When game saved `POST` to SQL server. 
`PUT`method 

#### Logic for loading game
Load game in json format.
Data `GET` from SQL server to user. 

#### Add function so you can finish

~~New testbranch in GameEngine created. Possibly a lot of changes needed in GameEngine. *2019-01-21*~~





## Other

~~Add comments in code~~

~~YAML documentation~~

Add GUI for GameEngine

Clean up documentation

Easteregg



