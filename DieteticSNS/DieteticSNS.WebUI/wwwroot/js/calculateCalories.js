function start() {
    calculateCalories();
}
window.onload = start;

function calculateCalories() {
    let protein = parseInt(document.getElementById("protein").value) || 0;
    let carbohydrate = parseInt(document.getElementById("carbohydrate").value) || 0;
    let fat = parseInt(document.getElementById("fat").value) || 0;

    let sum = protein * 4 + carbohydrate * 4 + fat * 9;

    document.getElementById("calories").value = sum;
}
