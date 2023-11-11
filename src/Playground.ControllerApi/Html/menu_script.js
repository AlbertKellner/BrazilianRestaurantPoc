document.addEventListener('DOMContentLoaded', function () {
    fetchDishes();

    document.getElementById('submitOrderAndReserve').addEventListener('click', function (event) {
        reserveTable(event);
    });
});

function fetchDishes() {
    fetch('https://localhost:7066/dish')
        .then(response => response.json())
        .then(data => {
            displayDishes(data);
        })
        .catch(error => console.error('Error:', error));
}

function displayDishes(dishes) {
    const dishesList = document.getElementById('dishesList');
    dishes.forEach(dish => {
        let listItem = document.createElement('li');
        listItem.classList.add('list-group-item');

        listItem.innerHTML = `
            <div class="d-flex justify-content-between align-items-center">
                <div>
                    <strong>Name:</strong> ${dish.dish_name}, <strong>Price:</strong> ${dish.price}
                </div>
                <div>
                    <input type="number" min="0" value="0" id="id_${dish.id}" class="form-control" style="width: 60px;">
                </div>
            </div>
        `;

        dishesList.appendChild(listItem);
    });
}

function reserveTable(event) {
    event.preventDefault(); 

    sendOrder().then(guid => {
        const cleanedGuid = guid.replace(/['"]+/g, '');
        reserveTable(event, { order_id: cleanedGuid });
    }).catch(error => console.error('Error:', error));
}

function sendOrder() {
    const dishesList = document.getElementById('dishesList').getElementsByTagName('li');
    let order = {
        dishes_ids: []
    };

    Array.from(dishesList).forEach(listItem => {
        const dishId = listItem.querySelector('input[type=number]').id.split('_')[1];
        const quantity = listItem.querySelector('input[type=number]').value;

        for (let i = 0; i < quantity; i++) {
            order.dishes_ids.push(dishId);
        }
    });

    return fetch('https://localhost:7066/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(order)
    })
        .then(response => response.text()) 
        .then(guid => {
            console.log('Order successful, GUID:', guid);
            return guid; 
        });
}

function reserveTable(event, orderResponse) {
    if (event) event.preventDefault();

    const urlParams = new URLSearchParams(window.location.search);
    const tableId = urlParams.get('tableId') || Math.floor(Math.random() * 10) + 1; // Adicionado para ler da query string

    const reservationDateTime = '2000-01-01T12:00';
    const customerName = 'none';
    const customerContact = 'none';
    const orderId = orderResponse ? orderResponse.order_id : null;
    const reservationCode = (Math.floor(Math.random() * 700) + 300).toString();

    const reservationData = {
        reservation_date_time: reservationDateTime,
        table_id: tableId,
        customer_name: customerName,
        customer_contact: customerContact,
        order_id: orderId,
        reservation_code: reservationCode
    };

    fetch('https://localhost:7066/table-reservation', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(reservationData)
    })
        .then(response => response.json()) // Alterado para json() para obter o corpo da resposta.
        .then(data => {
            console.log('Reservation successful:', data);
            // Redirecionamento para a página de confirmação com o TableReservationId na query string.
            window.location.href = `confirmation.html?TableReservationId=${data}`;
        })
        .catch(error => console.error('Error:', error));
}
