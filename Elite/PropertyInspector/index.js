console.log("Index");
document.addEventListener('websocketCreate', function () {
    console.log("Websocket created!");
    window.setTimeout(updateDelayLabel, 500);

    websocket.addEventListener('message', function (event) {
        console.log("Got message event!");
        window.setTimeout(updateDelayLabel, 500);
    });
});
document.addEventListener('settingsUpdated', function (event) {
    console.log("Got settingsUpdated event!");
    window.setTimeout(updateDelayLabel, 500);
});


function updateDelayLabel() {
    var delayLabel = document.getElementById('delay_label');
    var delay = document.getElementById('delay');

    delayLabel.innerText = delay.value + " ms (Use left/right keys for added precision)";
    console.log("label");
}