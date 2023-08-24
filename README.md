# Pokemon.Solution Web Application

This is a web application that implements a simple Pokédex using ASP.NET Core MVC.


## Description

The Pokédex Web Application is built using ASP.NET Core MVC and provides a simple user interface to browse and search for Pokémon cards. It allows users to search for Pokémon by name and type, and view details about each Pokémon.

## Technologies Used
* C#
* ASP.NET Core
* JavaScript
* HTML/CSS
* MySQL
* Visual Studio Code
* Entity Framework Core
* EF Core Identity
* JQuery

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your system.

## Project Setup

* Clone this repository: `git clone https://github.com/austinpapritz/Pokemon.Solution.git

### Database Setup

* Search online to install MySQL on your computer. Remember your username and password.
* Add appsettings.json file to project folder. Paste the following code, inserting your own information where {indicated}.

{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database={DATABASENAME};uid={USERNAME};pwd={PASSWORD};"
    }
}

## Usage

1. Navigate to the project directory: `cd pokedexClient`
2. Restore dependencies: `dotnet restore`
3. Build the application: `dotnet build`

### Running the Application

To run the application locally:

1. Navigate to the project directory if you're not already there.
2. 
 Run the application: `dotnet run`
 Open a web browser and go to `http://localhost:5000` to access the Pokédex.

### Searching for Pokémon

- The main page displays a list of Pokémon.
- You can use the search bar to search for Pokémon by name.

## Contributing

We welcome contributions from the community! To contribute to this project:

1. Fork the repository.
2. Create a new branch for your feature or bug fix: `git checkout -b feature/your-feature-name`
3. Make your changes and commit them: `git commit -m 'Add new feature'`
4. Push your changes to your fork: `git push origin feature/your-feature-name`
5. Create a pull request to the main repository.

## Known Bugs

## License