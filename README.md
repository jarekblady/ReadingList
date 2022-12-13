# ReadingList

#### This app allows you to create your own reading list. 
#### The user can add, edit and remove the book.
#### The user has the option to mark the book as read.
#### The user can reorder the books.

## Configuration
#### 1. In the first step, change "ConnectionStrings" in [appsettings.json](https://github.com/jarekblady/ReadingList/blob/master/ReadingList.API/appsettings.json)
#### 2. in Solution Explorer, right click on ReadingList.API and select `Set as Startup Project`.
![Startup Project](https://github.com/jarekblady/ReadingList/blob/master/StartupProject.PNG)
#### 3. In Package Manager Console change Default project as `ReadingList.API`.
![Package Manager Console](https://github.com/jarekblady/ReadingList/blob/master/PackageManagerConsole.PNG)
#### 4. In Package Manager Console run `update-database` command
#### 5. Now you can start `ReadingList.API`.
#### 6. In Visual Studio Code you open `react-app`.
#### 7. In Terminal run `npm install` command.
#### 8. In Terminal run `npm start` command.

## Architecture

#### Layers od Solution: API, Service, Repository, react-app. 
#### EF Core is used for connection with database.
#### Repository-Service pattern divides the business layer into two layers: Repository and Service.
#### Repository handles getting data into and out of database.
#### Fluent Validation is used for validation.
#### Mapping a DTO to an Entity with Automapper.
#### Database (MS SQL Server)

## Database (MS SQL Server)
### Database Diagram
![Database Diagram](https://github.com/jarekblady/ReadingList/blob/master/DatabaseDiagram.PNG)