// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// this function is to add the selected pie to your cart
function AddToCart(id) {
    let hiddenCart = document.getElementById('HiddenPiesInCart');
    let cartValue = hiddenCart.getAttribute('value');
    if (cartValue == "") {
        cartValue = id;
    } else {
        cartValue += ',' + id;
    }
    hiddenCart.setAttribute('value', cartValue);
}

// Update number of pies in cart
function UpdateNumberShown(changeNum) {
    let cart = document.getElementById('Cart');
    let numberInCart = parseInt(cart.textContent);
    if (Number.isNaN(numberInCart)) {
        numberInCart = 0;
    }
    numberInCart += changeNum;
    cart.textContent = numberInCart;
}

function UpdateCart(id, changeNum) {
    AddToCart(id);
    UpdateNumberShown(changeNum);
}

function SubmitForm(name) {
    let form = document.getElementById(name);
    form.submit();
}

function CheckDates() {
    let pickupDateStr = document.getElementById('PickupDate');
    if (pickupDateStr == null) {
        return;
    }

    if (pickupDateStr.value == null) {
        return alert('Please fill in the date field.')
    }

    let pickupDate = new Date(pickupDateStr.value + 'T00:00'); // the T00:00 makes Date not assume UTC time
    let pieContainer = document.getElementById('PieContainer');
    let pickupDateLabel = document.getElementById('PickupDateLabel');

    if (pickupDate.getDay() == 6 || pickupDate.getDay() == 0) {
        if (pickupDateLabel.hasAttribute('hidden'))
            pickupDateLabel.removeAttribute('hidden');

        if (!pieContainer.hasAttribute('hidden'))
            pieContainer.setAttribute('hidden', '');

        pickupDateLabel.textContent = 'You have selected a weekend, please choose a non-weekend date.';
        return;
    }

    if (!pickupDateLabel.hasAttribute('hidden'))
        pickupDateLabel.setAttribute('hidden', '');

    if (pieContainer.hasAttribute('hidden'))
        pieContainer.removeAttribute('hidden');
}

function SetHiddenFor(id) {
    let input = document.getElementById(id);
    let hidden = document.getElementById('Hidden' + id);
    if (input.value != null)
        hidden.value = input.value;
}