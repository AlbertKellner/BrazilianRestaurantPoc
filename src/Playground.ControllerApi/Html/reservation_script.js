document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('submitOrderAndReserve').addEventListener('click', function (event) {
        sendOrderAndReserve(event);
    });
});

function sendOrderAndReserve(event) {
    event.preventDefault();

    reserveTable(event, { order_id: '00000000-0000-0000-0000-000000000000' });
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
