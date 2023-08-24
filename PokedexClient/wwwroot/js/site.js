// Utilizing AJAX to asynchronously filter Pokémon by type.
const typeSearch = document.querySelectorAll('.type-div');

// Create click handler for every type div.
typeSearch.forEach((typeSearch) => {
    typeSearch.addEventListener('click', (e) => {
        e.preventDefault(); 
        
        // Grab the type name from the data-type attribute.
        let typeName = typeSearch.getAttribute('data-type');
        
        // Initiates an AJAX request.
        $.ajax({
            // Route and type of request.
            url: "/Pokemons/TypeFilter",
            type: 'POST',
            // Filter route requires a type name.
            data: { typeName: typeName },
            success: function(response) {
                // Replace the container's content with the returned HTML
                document.getElementById("pokemonContainer").innerHTML = response;
            },
            error: function(err) {
                console.error("Error:", err);
            }      
        });
    });
});


