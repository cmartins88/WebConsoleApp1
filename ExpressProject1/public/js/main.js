function onBtnMenuClick() {
    document.getElementById('menu').style.display = 'block';
}

document.getElementById('btnUserSubmit').onclick = (e) => {
    e.preventDefault();

    try {
        var form = document.forms["userForm"];
        var inputs = form.getElementsByTagName("input");

        for (var i = 0; i < inputs.length; ++i) {
            var input = inputs[i];
            if (input.value == "" || input.value == null) {
                input.style.borderColor = "red";
            }
        }
    } catch (err) {
        console.error(err);
    }
}