$(function () {
    var side = $('#userSide').val('White');

    $('#yes').on('click', function () {
        var side = $('#userSide').val();

        if (side == "White") {
            $('#personHeader').removeClass('white-side');
            $('#personHeader').addClass('black-side');
            $('#personHeader h2').text('Black side');
            $('.navbar-brand').text('Black');
            var side = $('#userSide').val('Black');
        }
        else {
            alert('You can\'t change side!');
        }
    });

    $('#no').on('click', function () {

    });

});