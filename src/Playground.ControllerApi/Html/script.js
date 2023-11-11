document.addEventListener('DOMContentLoaded', function () {
    fetchDishes();
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
        listItem.textContent = `Name: ${dish.dish_name}, Price: ${dish.price}`;
        dishesList.appendChild(listItem);
    });
}
