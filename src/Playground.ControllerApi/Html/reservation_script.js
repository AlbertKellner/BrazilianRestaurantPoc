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

    const reservationDateTime = document.getElementById('reservationDateTime').value;
    const customerName = document.getElementById('customerName').value;
    const customerContact = document.getElementById('customerContact').value;
    const orderId = '00000000-0000-0000-0000-000000000000';
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
        .then(response => response.json())
        .then(data => {
            console.log('Reservation successful:', data);

            document.getElementById('confirmationMessage').innerText = "Your table has been successfully reserved!";
            document.getElementById('displayDateTime').innerText = reservationDateTime;
            document.getElementById('displayTableId').innerText = tableId;
            document.getElementById('displayCustomerName').innerText = customerName;
            document.getElementById('displayCustomerContact').innerText = customerContact;
            document.getElementById('displayReservationCode').innerText = reservationCode;
            document.getElementById('confirmationSection').style.display = 'block';

            document.getElementById('reservationForm').style.display = 'none';
        })
        .catch(error => console.error('Error:', error));
}
