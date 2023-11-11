document.addEventListener('DOMContentLoaded', function () {
    fetchDishes();
    document.getElementById('submitOrder').addEventListener('click', sendOrder);
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

    fetch('https://localhost:7066/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(order)
    })
        .then(response => response.json())
        .then(data => console.log('Order successful:', data))
        .catch(error => console.error('Error:', error));
}
