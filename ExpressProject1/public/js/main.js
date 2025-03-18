function onBtnMenuClick() {
    //document.getElementById('menu').style.display = 'block';
    // =
    document.querySelector('#menu').style.display = 'block';
}

const ff = 0;
let x = 0.1;
let y = "0.1";
let b = false;
let c = 'c'; // string
var j = `kweoewm ${ff} ${x}`;   // string
var u;                          // undefined
var m = null;
var h = 0x1112297347;           // hexadecimal
console.log(u === undefined);
console.log("x == y", x == y);
console.log("x === y", x === y);


y = "uhi"; // == false
y = undefined; // == false

var arr1 = ["a", 3, false, 6.5, "dd", { x: 5, y: 7 }];
var arr2 = new Array("a", 3, false, 6.5, "dd", { x: 5, y: 7 });

if (y) {

} else {

}

z = 3;
console.log(z);

window.capybara = window.capybara || {};
capybara.z = 3;

var car = {
    speed: 0,
    color: '',
    horsepower: 0, 

    speedup: () => {
        this.speed += 1;
    },

    speeddown: function () {
        this.speed -= 1;
    }
};

var car1 = car;
car1.speedup();
car1.speeddown();

class Person {
    construtor(name, address) {
        this.name = name;
        this.address = address;
        //this.speed = 0;
    }

    speedup () {
        this.speed += 1; // undefined1
    }

    speeddown() {
        this.speed -= 1;
    }
}

window.addEventListener('load', () => {

    // get all users and create a table
    const xhr_all = new XMLHttpRequest();
    xhr_all.open("GET", "http://localhost:5062/api/users");

    xhr_all.onreadystatechange = () => {
        if (xhr_all.readyState == XMLHttpRequest.DONE) {
            var newTable = document.createElement("table");

            var users = JSON.parse(xhr_all.responseText);
            console.log(users);
            users.forEach(user => {
                var newLine = document.createElement("tr");
                var td1 = document.createElement("td");
                var text = document.createTextNode(user.name);
                td1.appendChild(text);

                var td2 = document.createElement("td");
                var btnRmv = document.createElement("button");
                var btnRmvText = document.createTextNode("Remove");
                btnRmv.value = user.userId;
                btnRmv.onclick = (e) => {
                    // remove user
                    const xhr_del = new XMLHttpRequest();
                    xhr_del.open("DELETE", "http://localhost:5062/api/users/" + e.target.value);
                    xhr_del.send();
                }
                btnRmv.appendChild(btnRmvText);
                td2.appendChild(btnRmv);

                newLine.appendChild(td1);
                newLine.appendChild(td2);
                newTable.appendChild(newLine);
            });
            document.body.appendChild(newTable);
        }
    }

    xhr_all.send();

    // get an user and fill the form
    const xhr = new XMLHttpRequest();
    xhr.open("GET", "http://localhost:5062/api/users/dd3c4d3d-860b-4105-a581-203da180da64");

    xhr.onreadystatechange = () => {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            var form = document.forms["userForm"];
            var inputs = form.getElementsByTagName("input");

            var res = JSON.parse(xhr.responseText);

            for (var i = 0; i < inputs.length; ++i) {
                var input = inputs[i];

                if (input.name == "vegetarian") {
                    if (res[input.name]) input.checked = true;
                } else if (input.type != "submit") {
                    input.value = res[input.name];
                }
            }
        }
    }

    xhr.send();

    document.getElementById('btnUserSubmit').onclick = (e) => {
        e.preventDefault();

        var form = document.forms["userForm"];
        try {
            var inputs = form.getElementsByTagName("input"); // [input]
            var isErr = false;
            for (var i = 0; i < inputs.length; ++i) {
                var input = inputs[i];
                if (input.value == "" || input.value == null) {
                    input.style.borderColor = "red";
                    isErr = true;
                }
            }

            if (isErr) return;

        } catch (err) {
            console.error(err);
        }

        // create or update user
        var formData = new FormData(form);
        var jsonData = Object.fromEntries(formData);
        jsonData.vegetarian = jsonData.vegetarian == "1";
        var body = JSON.stringify(jsonData);

        const userId = jsonData["userId"];
        const xhr = new XMLHttpRequest();
        xhr.open(!userId ? "POST" : "PUT", "http://localhost:5062/api/users" + `/${userId}`);
        xhr.setRequestHeader("Content-Type", "application/json; charset=UTF-8");

        // send form to server in json format
        xhr.onreadystatechange = () => {
            if (xhr.readyState == XMLHttpRequest.DONE) {
                form.reset();

                var newDiv = document.createElement("div");
                var text = document.createTextNode("Enviado com sucesso");
                newDiv.appendChild(text);
                document.body.appendChild(newDiv);

                alert("Enviado com sucesso");
            }
        }

        xhr.send(body);

        /*
        var remove = confirm("Tem certeza que deseja remover o item?");
        if (remove) {
            alert("Removido com sucesso");
        }

        var msg = prompt("Insira o seu nome");
        alert(msg);*/
    }
});