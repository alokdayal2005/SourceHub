$(function () {

    var MovieFormSubmit = function () {
        //Grab the refernce of the form
        var $form = $(this);

        //Build the options object
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $($form.attr("data-movie-target"));
            target.replaceWith(data);
        });
         
        //To prevent the browser from doing it's defualt action means navigating away and redrawing the complete page
        return false;
    };

    var fetchPage = function () {
        //Get the anchor tag that user clicked on
        var $anchor = $(this);

        //Extract values like Href attributes which is in the anchor tag
        var options = {
            url: $anchor.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        //make the ajax request with options object, when the data retrieved successfully,
        //go and find out the target and then replace the taret with the fetched one
        $.ajax(options).done(function (data) {
            var target = $anchor.parents("div.pagedList").attr("data-movie-target");
            $(target).replaceWith(data);
        });
        return false;
    };
    //Look for Form with the name "data-movie-ajax", then wire up the submit event.
    $("form[data-movie-ajax='true']").submit(MovieFormSubmit);
    //Find the main-content and wire up the click event then filter these events based on ".pagedList a"
    //then call the method fetchPage
    $(".main-content").on("click", ".pagedList a", fetchPage);
});