var globalFactory = () => {
    animation = () => {
        function start() {
            var loading = '<div class="loader"></div>';
            $.blockUI({
                message: loading,
                css: { 'border': 'none', 'background-color': 'transparent' },
                baseZ: 3000,
                overlayCSS: { opacity: 0.3 }
            });
        }

        function stop() {
            $.unblockUI();
        }

        return {
            start,
            stop
        }
    }

    init = () => {
        jQuery.browser = {};
        jQuery.browser.msie = false;
        jQuery.browser.version = 0;
        if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
            jQuery.browser.msie = true;
            jQuery.browser.version = RegExp.$1;
        }
        $('.datepicker').datepicker({ language: "pt-BR", format: 'dd/mm/yyyy' });

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-full-width",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "5000",
            "timeOut": "10000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }

    alertError = (value, title) => { toastr["error"](value, title == undefined ? "Error" : title); }
    success = (value) => { toastr["success"](value); }
    warning = (value) => { toastr["warning"](value); }

    return {
        init,
        animation,
        success,
        warning,
        alertError
    }
}

var global = globalFactory();
global.init();