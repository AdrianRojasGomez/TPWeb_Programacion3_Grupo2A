//https://getbootstrap.com/docs/5.3/forms/validation/
//Script snippet sacado de bootstrap para deshabilitar submissions si hay fields invalidos

(() => {
    'use strict';
    const onReady = () => {
        const form = document.querySelector('form.needs-validation');
        if (!form) return;

        form.addEventListener('submit', (event) => {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    };

    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', onReady);
    } else {
        onReady();
    }
})();