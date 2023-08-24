# SEARCH THE POKÉDEX &#x1F6E1;

By: Austin Papritz,Hernan Verar,Pier Rodriguez,Raed Alkhanbashi,Shankaron Mohamed


## ```Description``` &#x1F481; &#x1F4D6;
The Pokédex Web Application, built on ASP.NET Core MVC, presents users with an intuitive interface to delve into and search for Pokémon cards. It empowers users to effortlessly seek out Pokémon by name and type, while delivering exhaustive details about each unique creature. In terms of functionality, the application enables users to establish profiles, giving them the capacity to curate a collection of their favored Pokémon cards, thereby creating a personal catalog of beloved Pokémon.

## Utilized Technologies
* C#
* ASP.NET Core
* JavaScript
* HTML/CSS
* MySQL
* Visual Studio Code
* Entity Framework Core
* EF Core Identity
* JQuery


## ```Setup/Installation Requirements``` &#x1F4BB;
```

- In the terminal run these commands in order: $ git clone Pokemon.Solution
- Cd Pokemon.Solution
- Next in the command line: touch .gitignore, then copy/paste this into the .gitignore file: obj bin appsettings.json
- Navigate to this project's production directory called "PokedexClient" with $ cd PokedexClient. 
- Within the production directory run the command $ touch appsettings.json. - In the appsettings.json file, paste in the following code, replacing [user-id] and [password] with your username and password for MySQL Workbench. (Remember to remove the square brackets when inputting your details):

``` { `"ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=factory;uid=[user-id];pwd=[password];" } }```

- Within the production directory "SweetAndSavory", run $ dotnet ef database update to instantiate the database.
- Still within the production directory, run $ dotnet watch run in the command line to launch the application in development mode in a browser, and interact with the application.
- Once on the application,navigate to  sign up on the right hand corner and create Login information.
- Enjoy!




```

 ## ```Prerequisites```
```
- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your system.
```

## ```Project Setup```
```
* Clone this repository: `git clone https://github.com/austinpapritz/Pokemon.Solution.git`
```

### Database Setup

* Search online to install MySQL on your computer. Remember your username and password.
* Add appsettings.json file to project folder. Paste the following code, inserting your own information where {indicated}.


```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database={DATABASENAME};uid={USERNAME};pwd={PASSWORD};"
    }
}


## ```Usage```

1. Navigate to the project directory: `cd pokedexClient`
2. Restore dependencies: `dotnet restore`
3. Build the application: `dotnet build`
```

### Running the Application

```
To run the application locally:
```
1. Navigate to the project directory if you're not already there.
2. Run the application: `dotnet run`
 Open a web browser and go to `http://localhost:5000` to access the Pokédex.
 ```
 
### Searching for Pokémon
```
- The main page displays a list of Pokémon.
- You can use the search bar to search for Pokémon by name.
```

## Contributing
We welcome contributions from the community! To contribute to this project:
```
1. Fork the repository.
2. Create a new branch for your feature or bug fix: `git checkout -b feature/your-feature-name`
3. Make your changes and commit them: `git commit -m 'Add new feature'`
4. Push your changes to your fork: `git push origin feature/your-feature-name`
5. Create a pull request to the main repository.


## ```Known Bugs``` &#x1F41E;



## ```License``` &#x1F4C4;&#x270D;

```
Copyright (c) 2023 Austin Papritz, Hernan verar, Pier Rodriguez, Raed Alkhanbashi, Shankaron Mohamed.
```
