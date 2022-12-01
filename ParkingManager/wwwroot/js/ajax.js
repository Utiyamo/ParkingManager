var ajaxFactory = () => {
    function ajaxPost(url, data, callback) {
        global.animation.start();

        var result = $.post(url, data, callback)
            .fail(() => {
                global.alertError("Houve um erro (POST)");
            });

        result.done((response) => {
            if (response.ResponseType === 0)
                global.alertError(response.Message);
            else if (response.ResponseType === 1)
                global.warning(response.Message);

            global.animation.stop();
        });
    }

    function ajaxGet(url, callback) {
        global.animation.start();

        var result = $.get(url, callback)
            .fail(() => {
                global.alertError("Houve um erro (GET)");
            });

        result.done(response => {
            if (response.ResponseType === 0)
                global.alertError(response.Message)
            else if (response.ResponseType === 1)
                global.warning(response.Message);

            global.animation.stop();
        })
    }

    return {
        ajaxPost,
        ajaxGet
    };
}

var ajax = ajaxFactory();