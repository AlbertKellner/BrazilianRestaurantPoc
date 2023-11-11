function getQueryStringParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
}

function displayOrderDetails(orderId) {
    document.getElementById('orderInfo').innerHTML = orderId;
}

var orderId = getQueryStringParameter('orderid');
if (orderId) {
    displayOrderDetails(orderId);
} else {
    document.getElementById('orderInfo').innerHTML = 'No order ID provided.';
}
