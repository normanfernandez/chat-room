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

document.getElementById("sendButton").onclick = async function (event) {
    await postMessage();
    event.preventDefault();
};

async function postMessage() {
    var messageComponent = document.getElementById("messageInput");
    var message = messageComponent.value;
    if (message == '')
        return;

    var hdRoomId = document.getElementById("hdRoomId").value;
    var hdUserEmail = document.getElementById("hdUserEmail").value;
    await axios.post('/api/Publish/Post', {
        "Content": message,
        "RoomId": parseFloat(hdRoomId),
        "UserEmail": hdUserEmail
    });

    messageComponent.value = '';
}