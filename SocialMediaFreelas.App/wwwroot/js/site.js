// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    var freelancerRadio = document.getElementById('freelancer-radio');
    var salaryContainer = document.getElementById('salary-container');

    freelancerRadio.addEventListener('change', function () {
        if (freelancerRadio.checked) {
            salaryContainer.style.display = 'block';
        }
    });

    var empresaRadio = document.querySelector('input[name="user-type"][value="empresa"]');
    empresaRadio.addEventListener('change', function () {
        if (empresaRadio.checked) {
            salaryContainer.style.display = 'none';
        }
    });
});

