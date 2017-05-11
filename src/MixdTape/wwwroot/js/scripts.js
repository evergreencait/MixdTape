$(document).ready(function () {
    $('.artist').submit(function (event) {
        event.preventDefault();
        alert("hello");
        $.ajax({
            type: 'GET',
            dataType: 'json',
            data: $(this).serialize(),
            url: 'Artists/GetArtists',
            success: function (artists) {
                
                for (var i = 0; i < artists.length; i++)
                {
                    $('#search-result').append('<p>' + artists[i].name + '</p>');
                }
                
            }
        });
    })

});