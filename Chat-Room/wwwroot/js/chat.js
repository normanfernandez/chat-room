"use strict";

var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/hubs")
    .build();

connection.start()
    .then(function () { })
    .catch(function (err) {
        console.error(err.toString());
    });

connection.on("MessageSentEvent", function (user, message, timestamp, roomId) {
    var hdRoomId = document.getElementById("hdRoomId").value;
    if (hdRoomId != roomId) {
        return;
    }

    var li = document.createElement("li");

    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} says ${message} - sent ${timestamp}`;
});

document.getElementById("sendButton").onclick = function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("MessageSentEvent", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
};