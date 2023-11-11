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
            
            document.getElementById('reservationCode').innerHTML = data.reservation_code;
        })
        .catch(error => console.error('Error fetching reservation:', error));
}

function fetchOrderDetails(orderId) {
    fetch(`https://localhost:7066/Order/${orderId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('Order details:', data);

            document.getElementById('totalCost').innerHTML = data.price;

            var dishesIds = data.dishes_ids;
            dishesIds.forEach(dishId => {
                fetchDishDetails(dishId);
            });
        })
        .catch(error => console.error('Error fetching order:', error));
}

function fetchDishDetails(dishId) {
    fetch(`https://localhost:7066/Dish/${dishId}`)
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
            dishItem.textContent = `${dishData.dish_name} - NZD$ ${dishData.price.toFixed(2)}`;
            dishesList.appendChild(dishItem);
        })
        .catch(error => console.error('Error fetching dish details:', error));
}

