let characters = [];
let connection = null;

let charIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:8797/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CharacterCreated", (user, message) => {
        getdata();
    });

    connection.on("CharacterDeleted", (user, message) => {
        getdata();
    });

    connection.on("CharacterUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

async function getdata() {
    await fetch('http://localhost:8797/playercharacter')
        .then(x => x.json())
        .then(y => {
            characters = y;
            //console.log(characters);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    characters.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + t.id +
        "</td><td>" + t.name +
        "</td><td>" + t.race.name +
        "</td><td>" + t.class.name +
        "</td><td>" + t.characterLevel +
        "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button" onclick="showupdate(${t.id})">Update</button>`
        +
        "</td></tr>"
        //console.log(t.race.name);
        //console.log(t.class.name);
    });
}

function showupdate(id) {
    document.getElementById('charnameupdate').value = characters.find(t => t['id'] == id)['name'];
    document.getElementById('charraceupdate').value = characters.find(t => t['id'] == id)['raceId'];
    document.getElementById('charclassupdate').value = characters.find(t => t['id'] == id)['classId'];
    document.getElementById('charlevelupdate').value = characters.find(t => t['id'] == id)['characterLevel'];
    document.getElementById('updateformdiv').style.display = 'flex';
    charIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let charname = document.getElementById('charnameupdate').value;
    let charrace = document.getElementById('charraceupdate').value;
    let charclass = document.getElementById('charclassupdate').value;
    let charlevel = document.getElementById('charlevelupdate').value;

    fetch('http://localhost:8797/playercharacter', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { id: charIdToUpdate, name: charname, raceId: charrace, classId: charclass, characterLevel: charlevel })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let charname = document.getElementById('charname').value;
    let charrace = document.getElementById('charrace').value;
    let charclass = document.getElementById('charclass').value;

    fetch('http://localhost:8797/playercharacter', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { name: charname, raceId: charrace, classId: charclass }) })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:8797/playercharacter/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}