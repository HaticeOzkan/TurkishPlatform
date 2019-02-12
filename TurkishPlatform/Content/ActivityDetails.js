function acbtn() {
    var perde = document.getElementById("perde");
    var hayal = document.getElementById("ActivityDetails");
    perde.style.display = 'block';
    hayal.style.display = 'block';
    var kapatbtn = document.getElementById("kapatbtn")
    kapatbtn.onclick = hayalkapat;
    var ac = document.getElementById("Activity");
    //ac.onclick = acbtn;
}
window.setTimeout(acbtn, 10);

function hayalkapat() {
    var perde = document.getElementById("perde");
    var hayal = document.getElementById("ActivityDetails");
    perde.style.display = 'none';
    hayal.style.display = 'none';
    var ac = document.getElementById("Activity");
    ac.onclick = acbtn;
}
function Guncelleme() {

    var katil = document.getElementById("katil");
    var katilmiyorum = document.getElementById("Katilmiyorum");
}