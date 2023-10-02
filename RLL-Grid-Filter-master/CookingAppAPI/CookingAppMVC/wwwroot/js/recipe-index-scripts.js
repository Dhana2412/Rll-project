$(document).ready(function () {
    $(".dropdown-item").click(function () {
        var selectedOption = $(this).data("value");
        var buttonText = $(this).text();

        $("#sortButton").text(buttonText);

        if (selectedOption === 'Featured') {
            sortRecipesById();
        } else {
            if (selectedOption === 'A to Z' || selectedOption === 'Z to A') {
                sortRecipesByName(selectedOption);
            } else {
                sortRecipesById();
            }
        }
    });

    function sortRecipesByName(selectedOption) {
        var container = $(".recipe-grid");
        var recipeCards = container.find('.recipe-card').get();

        recipeCards.sort(function (a, b) {
            var keyA = $(a).find('.recipe-name').text();
            var keyB = $(b).find('.recipe-name').text();

            if (selectedOption === 'A to Z') {
                return keyA.localeCompare(keyB);
            } else if (selectedOption === 'Z to A') {
                return keyB.localeCompare(keyA);
            } else {
                return 0;
            }
        });

        $.each(recipeCards, function (index, card) {
            container.append(card);
        });
    }
    function SortRecipesById() {
        var container = $(".recipe-grid");
        var recipeCards = container.find('.recipe-card').get();

        recipeCards.sort(function (a, b) {
            var idA = parseInt($(a).data("recipe-id"));
            var idB = parseInt($(b).data("recipe-id"));
            return idA - idB;
        });

        $.each(recipeCards, function (index, card) {
            container.append(card);
        });
    }


});
