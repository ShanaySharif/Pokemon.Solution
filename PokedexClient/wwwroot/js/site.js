// Utilizing AJAX to asynchronously delete a stylist after user-confirmation.
const typeSearch = document.querySelectorAll('.type-checkbox');

// Create click handler for every deleteLink element.
typeSearch.forEach((typeSearch) => {
    typeSearch.addEventListener('click', (e) => {
        e.preventDefault(); 
        
        // Grab the type name from the data-type attribute.
        let typeName = typeSearch.getAttribute('data-type');
        
        // Initiates an AJAX request on confirmation.
        $.ajax({
            // Route and type of request.
            url: "/Pokemons/TypeFilter",
            type: 'POST',
            // Delete route requires an Id.
            data: { name: typeName },
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
