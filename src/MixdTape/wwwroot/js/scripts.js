$(document).ready(function () {
    $('.artist').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'GET',
            dataType: 'json',
            data: $(this).serialize(),
            url: 'Artists/GetArtists',
            success: function (artists) {

                for (var i = 0; i < artists.length; i++) {
                    $('#search-result').append('<p class="clickedArtist">' + artists[i].name + '</p>');
                }
            }
        });
    });
    $('.secondArtist').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'GET',
            datatype: 'json',
            data: $(this).serialize(),
            url: 'Artists/GetTracks',
            success: function (tracks) {
                for (var i = 0; i < tracks.length; i++) {
                    $('#track-result').append('<p>' + tracks[i].name + '</p>');
                }
            }
        });
    })
});