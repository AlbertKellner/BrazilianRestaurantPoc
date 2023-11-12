document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('customerContact').addEventListener('input', applyPhoneMask);

    document.getElementById('submitOrderAndReserve').addEventListener('click', function (event) {
        sendOrderAndReserve(event);
    });

    document.getElementById('customerName').addEventListener('input', function (event) {
        // Substitui quaisquer caracteres que não sejam letras ou espaços
        this.value = this.value.replace(/[^a-zA-Z\s]/g, '');

        // Substitui dois ou mais espaços consecutivos por um único espaço
        this.value = this.value.replace(/\s{2,}/g, ' ');
    });

    setMinReservationDate();
});

function setMinReservationDate() {
    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);

    var day = tomorrow.getDate().toString().padStart(2, '0');
    var month = (tomorrow.getMonth() + 1).toString().padStart(2, '0');
    var year = tomorrow.getFullYear();

    var minDate = `${year}-${month}-${day}T00:00`;
    document.getElementById('reservationDateTime').setAttribute('min', minDate);
}

function sendOrderAndReserve(event) {
    event.preventDefault();

    if (!areFieldsValid()) {
        alert("Please make sure to fill in all required fields: Reservation Date and Time, Customer Name, and Customer Contact.");
        return;
    }

    reserveTable(event, { order_id: '00000000-0000-0000-0000-000000000000' });
}

function reserveTable(event, orderResponse) {
    if (event) event.preventDefault();

    const urlParams = new URLSearchParams(window.location.search);
    const tableId = urlParams.get('tableId') || Math.floor(Math.random() * 10) + 1;

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
            document.getElementById('displayDateTime').innerText = formatDateTime(reservationDateTime);
            document.getElementById('displayTableId').innerText = tableId;
            document.getElementById('displayCustomerName').innerText = customerName;
            document.getElementById('displayCustomerContact').innerText = customerContact;
            document.getElementById('displayReservationCode').innerText = reservationCode;

            document.getElementById('confirmationSection').style.display = 'block';
            document.getElementById('reservationForm').style.display = 'none';
        })
        .catch(error => console.error('Error:', error));
}

function areFieldsValid() {
    const reservationDateTime = document.getElementById('reservationDateTime').value;
    const customerName = document.getElementById('customerName').value;
    const customerContact = document.getElementById('customerContact').value;

    return reservationDateTime && customerName && customerContact;
}

function formatDateTime(dateTime) {
    var date = new Date(dateTime);
    var day = date.getDate().toString().padStart(2, '0');
    var month = (date.getMonth() + 1).toString().padStart(2, '0');
    var year = date.getFullYear();
    var hours = date.getHours().toString().padStart(2, '0');
    var minutes = date.getMinutes().toString().padStart(2, '0');

    return `${day}/${month}/${year} ${hours}:${minutes}`;
}

function applyPhoneMask(event) {
    var numbers = event.target.value.replace(/\D/g, '');
    var char = { 0: '(', 2: ') ', 7: '-' };
    var phone = '';

    for (var i = 0; i < numbers.length && i < 11; i++) {
        phone += (char[i] || '') + numbers[i];
    }

    event.target.value = phone;
}