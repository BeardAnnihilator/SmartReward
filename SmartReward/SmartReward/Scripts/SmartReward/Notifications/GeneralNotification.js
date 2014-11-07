// Reference the auto-generated proxy for the hub.
var chat = $.connection.chatHub;

// Create a function that the hub can call back to display new notif.
chat.client.Notify = function (nbNotif) {
    $('#notificationCount').html(nbNotif);
};

$.connection.hub.start();

