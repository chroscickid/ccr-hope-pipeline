// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Generate Reports
//...
require('dotenv').config();
console.log(process.env);

function addSearchField(count) {
    switch (count) {
        case 1:
            document.getElementById("part2").style.display = "";
            break;
        case 2:
            document.getElementById("part3").style.display = "";
            break;
        case 3:
            document.getElementById("part4").style.display = "";
            break;
        case 4:
            document.getElementById("part5").style.display = "";
            break;
    }
    return false;
}

//Datatables 
//...
$(document).ready(function () {
    $('#tracklist').DataTable({
        "columns": [
            'Name',
            'Phone Number',
            'Status',
            'More Options'
        ]
    })});
