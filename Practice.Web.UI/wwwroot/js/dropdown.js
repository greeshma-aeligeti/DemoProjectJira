window.registerDropdown = function (dotNetObjRef) {
    document.addEventListener('click', function (event) {
        const dropdowns = document.querySelectorAll('.dropdown-menu');
        dropdowns.forEach(dropdown => {
            if (!dropdown.contains(event.target)) {
                dotNetObjRef.invokeMethodAsync('CloseDropdown');
            }
        });
    });
};
