# _Factory App_

#### By _Robert Onstott_

#### _Web-based business application for tracking the machines that are on-line in a factory, the engineers who work in that factory, and which engineers are authorized to perform maintenance on which machines_

## Technologies Used

* _C# and .NET 6.0_
* _ASP.NET core MVC_
* _Entity Framework Core_
* _MySQL community server_
* _MySQL Workbench_
* _VS Code_
* _Github_

## Description

_This is a C# web app built with the ASP.NET Core MVC web development framework. It utilizes Entity Framework Core for mapping C# object classes into SQL database schemas. For the purposes of development, the database is hosted through a local server using MySql. It is intended for a hypothetical client who runs a factory, with machines and engineers. The client is able to add both engineers and machines to the database, assigning them names upon creating. The client is then able to indicate, through many-to-many relationships, which engineers are trained/authorized to perform maintenance on given machines. The client is able to view individual engineers and see a list of all of the machines that the engineer is able to service, and the client is able to view individual machines and see a list of all of the engineers that are authorized to that machine. The client can also delete machines or engineers and remove client-machine connections. The program stores these values in a SQL database, and the database schema is constructed using code-first development and migrations through EF Core Design package_

## Setup/Installation Requirements

* _Download the .NET framework if you do not already have it (version 6.0 or later)_
 
  _https://dotnet.microsoft.com/en-us/download/dotnet_
  
* _Download MySQL Community Server and MySQL Workbench if you don't already have them (both from this link). Make note of both the `User ID (UID)` and the `Password (PWD)` that you define in your setup configurations for MySQL. These values will go into your `appsettings.json` file in a few steps_
  
    _https://dev.mysql.com/downloads/_
  
* _Clone this repository to your machine_

* _Open the repository (VS Code is recommended) and create a new file in the root directory called `appsettings.json`. Copy the following code into the file, with your own values for `uid` and `pwd`_
 
 
  
  ```
       {
         "ConnectionStrings": {
           "DefaultConnection": "Server=localhost;Port=3306;database=factory_manager;uid=[***your user ID here ***];pwd=[*** your password here *** ];"
         }
       }      
  ```
  
  
  
* _Entity Framework Core has tools to automatically build the database schema utiliaing object mapping. To build the database, open a terminal, go to the `Factory` directory: `$ cd Factory` and enter the following commands_

```
    $ dotnet ef database update   
```

* _While still in the `Factory` directory, enter the command `$ dotnet run`. This will start the local web server. Enter the URL https://localhost:5001 in a browser window. You are now interacting with the web app_
  
  ```
        $ dotnet run
  ```  
  
  _https://localhost:5001_
  
 * _If the localhost:5001 is not loading, you may need to authenticate the https certificate by entering the admnistrator password_

## Known Bugs

* _No known bugs at this time_

## License

_MIT_

_Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._

Copyright (c) January 2022_ _Robert Onstott_
