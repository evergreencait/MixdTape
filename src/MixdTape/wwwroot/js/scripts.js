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
                    $('#search-result').append('<p class="clickedArtist">' + artists[i].name+ '</p>');
                }
                $(".clickedArtist").click(function () {
                    var artist = $(this).html();
                    console.log("ARTIST" + artist)
                    $.ajax({
                        type: 'GET',
                        datatype: 'json',
                        data: $(this).serialize(),
                        url: 'Artists/GetTracks',
                        success: function (artist) {
                            console.log("artist" + artist);
                            for (var i = 0; i < artist.length; i++) {
                                $('#track-result').append('<p>' + artist[i].name + '</p>');
                            }
                        }
                    });
                });

            }

        });
    });
});
