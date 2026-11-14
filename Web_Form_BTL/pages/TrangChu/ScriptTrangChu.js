function checkDate() {
    let dateNhan = document.getElementById("txtNgayNhan").value;
    let dateTra = document.getElementById("txtNgayTra").value;
    let today = new Date;

    let year = today.getFullYear();
    let month = String(today.getMonth() + 1).padStart(2, '0');
    let day = String(today.getDate()).padStart(2, '0');

    let ngayHienTai = `${year}-${month}-${day}`;

    if (dateNhan < ngayHienTai) {
        alert("Ngày nhận phòng không được nhỏ hơn ngày hiện tại!");
        return false;
    }

    if (dateTra <= dateNhan) {
        alert("Ngày trả phải lớn hơn ngày nhận");
        return;
    }
    if (dateNhan == "" || dateTra == "") {
        alert("Vui lòng nhập đầy đủ ngày nhận và ngày trả");
        return;
    }
   
}

function themNgayVaoLink(link) {
    var ngayNhan = document.getElementById("txtNgayNhan").value;
    var ngayTra = document.getElementById("txtNgayTra").value;

    var url = new URL(link.href);

    if (ngayNhan) {
        url.searchParams.set("ngayNhan", ngayNhan);
    }
    if (ngayTra) {
        url.searchParams.set("ngayTra", ngayTra);
    }
    link.href = url.href;

    return true;
}