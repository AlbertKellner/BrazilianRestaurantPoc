document.addEventListener('DOMContentLoaded', function () {
    const urlParams = new URLSearchParams(window.location.search);
    const dishId = urlParams.get('dishid');

    if (dishId) {
        fetch(`https://localhost:7066/dish/${dishId}`)
            .then(response => response.json())
            .then(data => populateForm(data))
            .catch(error => console.error('Error:', error));
    }

    document.getElementById('updateDishForm').addEventListener('submit', function (e) {
        e.preventDefault();

        const dishData = {
            dishName: document.getElementById('dishName').value,
            price: document.getElementById('price').value,
            chefRecommendation: document.getElementById('chefRecommendation').checked,
            quantity: document.getElementById('quantity').value,
            category: document.getElementById('category').value
        };

        console.log(dishData);
    });
});

document.getElementById('updateDishForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const dishId = new URLSearchParams(window.location.search).get('dishid');

    const dishData = {
        dish_name: document.getElementById('dishName').value,
        price: parseFloat(document.getElementById('price').value),
        chef_recommendation: document.getElementById('chefRecommendation').checked,
        quantity: parseInt(document.getElementById('quantity').value, 10),
        category: document.getElementById('category').value
    };

    fetch(`https://localhost:7066/dish/${dishId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(dishData)
    })
        .then(response => {
            if (response.ok) {
                console.log('Dish updated successfully');
                window.location.href = 'menu.html?tableid=12';
            } else {
                console.error('Error updating dish');
            }
        })
        .catch(error => console.error('Error:', error));
});


function populateForm(data) {
    if (!data) return;

    document.getElementById('dishName').value = data.dish_name || '';
    document.getElementById('price').value = data.price || '';
    document.getElementById('chefRecommendation').checked = data.chef_recommendation || false;
    document.getElementById('quantity').value = data.quantity || '';
    document.getElementById('category').value = data.category || '';
}
