const uri = 'api/raitingitems';
let raitings = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');
    const addRaitingTextbox = document.getElementById('add-raiting');

    const item = {
        grade: addRaitingTextbox.value.trim(),
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
            addRaitingTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'raiting' : 'raitings';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('raitings');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNodeR = document.createTextNode(item.grade);
        td1.appendChild(textNodeR);

        let td2 = tr.insertCell(1);
        let textNodeN = document.createTextNode(item.name);
        td2.appendChild(textNodeN);

        let td4 = tr.insertCell(2);
        td4.appendChild(deleteButton);
    });

    raitings = data;
}