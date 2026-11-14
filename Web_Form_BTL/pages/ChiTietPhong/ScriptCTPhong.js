function moModal() {
    document.getElementById("modalDatPhong").style.display = "flex";
    tinhTien();
}

function dongModal() {
    document.getElementById("modalDatPhong").style.display = "none";
}

const txtNgayNhan = document.getElementById("txtNgayNhan");
const txtNgayTra = document.getElementById("txtNgayTra");

const giaPhong = Number(
    document.getElementById("hdnGiaPhong").value
);

const lblTongModal = document.getElementById("lblTongModal");

function tinhTien() {
    const nhan = new Date(txtNgayNhan.value);
    const tra = new Date(txtNgayTra.value);
    const soKhach = document.getElementById("txtSoKhach").value;
    const soDem = Math.round(
    (tra - nhan) / (1000 * 60 * 60 * 24)
    );  

    const tongTien = soDem * giaPhong;

    document.getElementById("modalNgayNhan").textContent = nhan.toLocaleDateString("vi-VN");
    document.getElementById("modalNgayTra").textContent = tra.toLocaleDateString("vi-VN");
    document.getElementById("modalSoKhach").textContent = soKhach;
    alert(document.getElementById("modalNgayNhan").textContent);
    lblTongModal.textContent =
        soDem + " x " + giaPhong.toLocaleString("vi-VN") + " = " + tongTien.toLocaleString("vi-VN") + " VND";
    // LẮNG NGHE SỰ KIỆN THAY ĐỔI NGÀY
    txtNgayNhan.addEventListener("change", tinhTien);
    txtNgayTra.addEventListener("change", tinhTien);
}


