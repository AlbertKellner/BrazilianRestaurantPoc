document.addEventListener('DOMContentLoaded', function () {
    fetchAllOrders();
});

function fetchAllOrders() {
    fetch(`https://localhost:7066/Order`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(orders => {
            orders.forEach(order => {
                displayOrder(order);
                let dishesPromises = order.dishes_ids.map(dishId => fetchDishDetails(dishId));
                Promise.all(dishesPromises).then(dishes => {
                    displayDishes(dishes, order.id);
                });
            });
        })
        .catch(error => console.error('Error fetching orders:', error));
}

function displayOrder(order) {
    const ordersContainer = document.getElementById('ordersList');
    const orderCard = document.createElement('div');
    orderCard.className = 'card beige-card mb-3';
    orderCard.id = `order-${order.id}`;

    const cardBody = document.createElement('div');
    cardBody.className = 'card-body';

    const orderTitle = document.createElement('h5');
    orderTitle.className = 'card-title';
    orderTitle.textContent = `Order #${order.order_code}`;

    cardBody.appendChild(orderTitle);
    orderCard.appendChild(cardBody);
    ordersContainer.appendChild(orderCard);
}


function displayDishes(dishes, orderId) {
    const orderItem = document.getElementById(`order-${orderId}`);
    const dishesList = document.createElement('ul');
    let totalCost = 0;

    dishes.forEach(dish => {
        totalCost += dish.price;
        const dishItem = document.createElement('li');
        //dishItem.textContent = `${dish.dish_name} - $ ${dish.price.toFixed(2)}`;
        dishItem.textContent = `(${dish.category}) ${dish.dish_name}`;
        dishesList.appendChild(dishItem);
    });

    const dishItem = document.createElement('br');
    dishesList.appendChild(dishItem);

    orderItem.appendChild(dishesList);
    document.getElementById(`totalCost-${orderId}`).textContent = totalCost.toFixed(2);
}

function fetchDishDetails(dishId) {
    return fetch(`https://localhost:7066/Dish/${dishId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .catch(error => console.error('Error fetching dish details:', error));
}
