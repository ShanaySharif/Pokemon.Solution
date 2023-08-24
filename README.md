# SEARCH THE POKÉDEX &#x1F6E1;

By: Austin Papritz, Hernan Verar, Pier Rodriguez, Raed Alkhanbashi, Shankaron Mohamed

![Sceenshot of homepage search](/PokedexClient/wwwroot/pokedex_home_ss.png)


## ```Description``` &#x1F481; &#x1F4D6;
The Pokédex Web Application, built on ASP.NET Core MVC, presents users with an intuitive interface to delve into and search for Pokémon cards. It empowers users to effortlessly seek out Pokémon by name and type, while delivering exhaustive details about each unique creature. In terms of functionality, the application enables users to establish profiles, giving them the capacity to curate a collection of their favored Pokémon cards, thereby creating a personal catalog of beloved Pokémon. Dataset downloaded from [www.kaggle.com](https://www.kaggle.com/datasets/dizzypanda/gen-1-pokemon).

![Sceenshot of search page](/PokedexClient/wwwroot/pokedex_search_ss.png)


## `Utilized Technologies`
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


- _In the terminal run these commands:_ 

    ```$ git clone Pokemon.Solution```

    ```$ cd Pokemon.Solution```

- _Then enter:_

    ```$ touch .gitignore```

- _Add the following to `.gitignore`:_

```
    obj 
    bin 
    appsettings.json
```

- _Navigate to the project folder:_

    ```$ cd PokedexClient```

- _Add an `appsettings.json` file:_

    ```$ touch appsettings.json```

- _Add the following to `appsettings.json`, replacing [user-id] and [password] with your MySQL username and password. Give the database a name by replacing [database-name]._

```
{ 
    "ConnectionStrings": { 
     "DefaultConnection": "Server=localhost;Port=3306;database=[database-name];uid=[user-id];pwd=[password];" 
    } 
}
```

- _Create a database schema with the following command:_

    ```$ dotnet ef database update```

- The first time you run the app, `PokedexClient/Models/PokemonDataSeeder.cs` will automatically seed your database with all of the Pokémon data! 

    ```$ dotnet watch run```

- _Open your browser and enter `https://localhost:7015/` into the url bar, if it doesn't automatically._
- _You may need to give yourself security certs by entering `$ dotnet dev-certs https --trust`._
- _There will be a confirmation pop-up in your browser, you might also need to click `Advanced` and then click to proceed to site_
- _Enjoy!_

 ## `Prerequisites`

- _Search online to install MySQL on your computer. Remember your username and password._
- _[.NET Core SDK](https://dotnet.microsoft.com/download) installed on your system._


## ```Contributing```

_We welcome contributions from the community! To contribute to this project:_

1. _Fork the repository._
2. _Create a new branch for your feature or bug fix: `git checkout -b feature/your-feature-name`_
3. _Make your changes and commit them: `git commit -m 'Add new feature'`_
4. _Push your changes to your fork: `git push origin feature/your-feature-name`_
5. _Create a pull request to the main repository._


## ```Known Bugs``` &#x1F41E;

- _None_

## ```License``` &#x1F4C4;&#x270D;

Copyright (c) 2023 Austin Papritz, Hernan verar, Pier Rodriguez, Raed Alkhanbashi, Shankaron Mohamed.

