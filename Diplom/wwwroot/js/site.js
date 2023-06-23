
var elems = document.getElementsByClassName("payment-method-item");
for (let i = 0; i < elems.length; i++) {
    elems[i].onclick = function (event) {
        this.querySelector('input').checked = true;
    }
}

var sorts = document.getElementsByClassName("sort-method-item");
for (let i = 0; i < sorts.length; i++) {
    sorts[i].onclick = function (event) {
        this.querySelector('input').checked = true;
    }
}

var types = document.getElementsByClassName("form-item-radio");
for (let i = 0; i < types.length; i++) {
    types[i].onclick = function (event) {
        this.querySelector('input').checked = true;
        if (this.id == "show-dates") {
            document.getElementById("dates").style.display = "flex";
            document.getElementsByClassName("date")[0].setAttribute("required", "true");
        }

        else {
            
            document.getElementsByName("itemDate")[0].removeAttribute("required");
            document.getElementById("dates").style.display = "none";        
        }
    }
}

var items = document.getElementsByClassName("form-item-date");
for (let i = 0; i < items.length; i++) {
    items[i].onclick = function (event) {
        DeleteBorder();
        this.querySelector('input').checked = true;
        this.style.border = "2px solid #F40F31";
        this.style.color = "#F40F31";
    }
}

var payments = document.getElementsByClassName("form-payment");
for (let i = 0; i < payments.length; i++) {
    payments[i].onclick = function (event) {
        this.querySelector('input').checked = true;
    }
}

function RedIcon() {
    document.getElementById("search_icon").src = "/img/search_red.png";
}
function BlackIcon() {
    document.getElementById("search_icon").src = "/img/search_black.png";
}

function RedLogout() {
    document.getElementById("logout-img").src = "/img/red_logout.svg";
}
function GrayLogout() {
    document.getElementById("logout-img").src = "/img/gray_logout.svg";
}

function RedBack() {
    document.getElementById("back-img").src = "/img/red_back.svg";
}
function GrayBack() {
    document.getElementById("back-img").src = "/img/gray_back.svg";
}
function RedSort() {
    document.getElementById("sort-img").src = "/img/sort-red.svg";
}
function GraySort() {
    document.getElementById("sort-img").src = "/img/sort-gray.svg";
}


function HideDivs() {
    document.getElementById("payment").style.display = "none";
    document.getElementById("user-form").style.display = "none";
    document.getElementById("orders").style.display = "none";
    document.getElementById("notifications").style.display = "none";
    document.getElementById("help").style.display = "none";
    

    document.getElementById("redlinePayment").style.width = "0";
    document.getElementById("redlineUserForm").style.width = "0";
    document.getElementById("redlineOrders").style.width = "0";
    document.getElementById("redlineNotifications").style.width = "0";
    document.getElementById("redlineHelp").style.width = "0";

    document.getElementById("payment-link").style.color = "#9A9A9D";
    document.getElementById("user-form-link").style.color = "#9A9A9D";
    document.getElementById("orders-link").style.color = "#9A9A9D";
    document.getElementById("notifications-link").style.color = "#9A9A9D";
    document.getElementById("help-link").style.color = "#9A9A9D";
}
function ShowPayment() {
    HideDivs();
    document.getElementById("payment").style.display = "flex";
    document.getElementById("payment-link").style.color = "#F40F31";
    document.getElementById("redlinePayment").style.width = "100%";
}
function ShowUserForm() {
    HideDivs();
    document.getElementById("user-form").style.display = "flex";
    document.getElementById("user-form-link").style.color = "#F40F31";
    document.getElementById("redlineUserForm").style.width = "100%";
}
function ShowOrders() {
    HideDivs();
    document.getElementById("orders").style.display = "flex";
    document.getElementById("orders-link").style.color = "#F40F31";
    document.getElementById("redlineOrders").style.width = "100%";
}
function ShowNotifications() {
    HideDivs();
    document.getElementById("notifications").style.display = "flex";
    document.getElementById("notifications-link").style.color = "#F40F31";
    document.getElementById("redlineNotifications").style.width = "100%";
}
function ShowHelp() {
    HideDivs();
    document.getElementById("help").style.display = "flex";
    document.getElementById("help-link").style.color = "#F40F31";
    document.getElementById("redlineHelp").style.width = "100%";
}
function DeleteBorder() {
    var items = document.getElementsByClassName("form-item-date");
    for (let i = 0; i < items.length; i++) {
        items[i].style.border = "1px solid #F4F3F3";
        items[i].style.color = "black";
    }     
}




