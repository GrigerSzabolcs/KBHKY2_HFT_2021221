let brands = [];
let connection = null;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:54669/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on('BrandCreated', (user, message) => {
        getdata();
    });
    connection.on('BrandDeleted', (user, message) => {
        getdata();
    });
    connection.on('BrandUpdated', (user, message) => {
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
    await fetch('http://localhost:54669/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            display();
        });
}



function display() {
    document.getElementById('resultareaBrand').innerHTML = '';
    brands.forEach(t => {
        document.getElementById('resultareaBrand').innerHTML +=
            '<tr><td>' + t.id + '</td>' +
            '<td>' + t.name + '</td><td>' +
            `<button type="button" onclick="removeBrand(${t.id})">Delete</button>` +
            `<button type="button" onclick="updateBrand(${t.id})">Update</button>` +
            '</td></tr>';
    })
}

function createBrand() {
    let brandname = document.getElementById('brandname').value;
    fetch('http://localhost:54669/brand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: brandname })})
        .then(response => response)
        .then(data =>
        {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); }); 
}

function removeBrand(id) {
    fetch('http://localhost:54669/brand/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function updateBrand(brandID) {
    let brandname = document.getElementById('brandname').value;
    fetch('http://localhost:54669/brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id: brandID, name: brandname})})
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}