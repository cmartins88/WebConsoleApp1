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

console.log(arr1.);

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
    document.getElementById('btnUserSubmit').onclick = (e) => {
        e.preventDefault();

        try {
            var form = document.forms["userForm"];
            var inputs = form.getElementsByTagName("input"); // [input]

            for (var i = 0; i < form.inputs; ++i) {
                var input = inputs[i];
                if (input.value == "" || input.value == null) {
                    input.style.borderColor = "red";
                }
            }
        } catch (err) {
            console.error(err);
        }

        var newDiv = document.createElement("div");
        var text = document.createTextNode("Enviado com sucesso");
        newDiv.appendChild(text);
        document.body.appendChild(newDiv);

        alert("Enviado com sucesso");
        var remove = confirm("Tem certeza que deseja remover o item?");
        if (remove) {
            alert("Removido com sucesso");
        }

        var msg = prompt("Insira o seu nome");
        alert(msg);
    }
});