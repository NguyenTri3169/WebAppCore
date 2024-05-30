$("#btnLogin").click(function () {
    debugger;

    var email = $('#txtEmail').val();
    var password = $('#txtPassWord').val();
    var data = {

        UserName: email,
        UserPass: password
    };
    console.log(data);
    $.ajax({
        url: '/Account/Login',
        type: 'POST',
        dataType: 'json',
        data: data,
        // success: function (d) {
        //     console.log(d);
        // }
    }).done(function (ketqua) {
        console.log('Done')
        alert(ketqua.returnMsg);
        var token = ketqua.token;
        // lưu token vào cookie
        setCookie("StoreCookie", token, 1);
    });
});

$("#btnSubmitUpate").click(function () {
    debugger;

    var email = $("#txtEmail").val();
    var password = $("#txtPassWord").val();
    var account = {
        email: email,
        password: password
    };

    $.ajax({
        url: '/Home/EditAccount',
        type: 'POST',
        dataType: 'html',
        data: account
    }).done(function (ketqua) {
        alert(ketqua.Description);
        LoadAccountPartialView();
    });
});
function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function LoadAccountPartialView() {

    $.ajax({
        url: '/Home/ListDataPartialView',
        type: 'POST',
        dataType: 'html',
        data: {}
    }).done(function (result) {
        $("#noidung").html("");
        $("#noidung").html(result);
    });
}