function loginFactory() {
    function btnLogin() {
        var username = $("#userName").text();
        var password = $("#passWord").text();

        if (username.length === 0)
            global.warning("Invalid Username");
        else if (password.length === 0)
            global.warning("Invalid Password");
        else {
            var data = {
                user: username,
                pswd: password:
            }

            ajax.ajaxPost("Login", data, (response) => {
                if (response.length > 0) {
                    console.log(response);
                }
            })
        }
    }

    

    function init() {
        $(document).on("click", "#btnLogin", btnLogin);
    }
}