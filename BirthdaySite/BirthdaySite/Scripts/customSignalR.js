var rooms = "";

$(document).ready(function () {

    $.connection.hub.start();

    var chat = $.connection.chat;

    $('#input-submit-button').click(function () {

        var msg = $('#input-message-content').val();

        var room = $('#hidden-group').text().trim();

        chat.server.joinRoom(room)

        chat.server.sendMessageToRoom(msg, room);
    });

    chat.client.addMessage = addMessage;
});

function addMessage(message, user) {
    $('.panel-body').children('.container').append('<div class="row message-bubble">' +
        '<p class="text-muted">' + user + '</p>' +
        '<span>' + message + '</span>' +
        '</div>');

    $('#input-message-content').val('');
}