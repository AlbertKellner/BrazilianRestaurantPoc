document.addEventListener('DOMContentLoaded', function () {
    var orderId = getQueryStringParameter('orderid');
    var tableId = getQueryStringParameter('tableid');

    document.getElementById('orderId').innerHTML = orderId;
    document.getElementById('tableId').innerHTML = tableId;

    fetchTableReservation(tableId);
    fetchOrderDetails(orderId);
});

function getQueryStringParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
}

function fetchTableReservation(reservationId) {
    fetch(`https://localhost:7066/table-reservation/${reservationId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('Reservation details:', data);
        })
        .catch(error => console.error('Error fetching reservation:', error));
}

function fetchOrderDetails(orderId) {
    let totalCost = 0;

    fetch(`https://localhost:7066/Order/${orderId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('Order details:', data);

            var dishesIds = data.dishes_ids;
            let dishesPromises = dishesIds.map(dishId => fetchDishDetails(dishId, totalCost));

            Promise.all(dishesPromises).then(results => {
                totalCost = results.reduce((sum, value) => sum + value, 0);
                document.getElementById('totalCost').innerHTML = totalCost.toFixed(2);
            });

            document.getElementById('reservationCode').innerHTML = data.order_code;
        })
        .catch(error => console.error('Error fetching order:', error));
}

function fetchDishDetails(dishId, totalCost) {
    return fetch(`https://localhost:7066/Dish/${dishId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(dishData => {
            console.log('Dish details:', dishData);
            var dishesList = document.getElementById('dishesList');
            var dishItem = document.createElement('li');
            dishItem.textContent = `${dishData.dish_name} - $ ${dishData.price.toFixed(2)}`;
            dishesList.appendChild(dishItem);

            return totalCost + dishData.price;
        })
        .catch(error => console.error('Error fetching dish details:', error));
}

