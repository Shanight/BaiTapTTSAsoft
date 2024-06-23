var kiemtraemail = "0";
function checkEmail() {
    console.log("ok");
    var emailcheck = document.getElementById("Emailcheck").value;
    var baoloi = document.getElementById("checkemail");
    var filter = /\S+@\S+/;

    if (!filter.test(emailcheck)) {
        kiemtraemail = "0";
        baoloi.innerHTML = "Vui lòng nhập đúng định dạng email VD: test1@gmail.com";
        document.getElementById("Email").value = "";
        console.log("loi " + emailcheck +loikendo);
        
        return false;
    } else {
        kiemtraemail = "1";
        document.getElementById("Email").value = emailcheck;
        baoloi.innerHTML = "Email đã đúng định dạng";
        console.log("thanhcong" + loikendo);
        
    }
}

function updateDisabledValue(checkbox) {
    
    var value = checkbox.checked ? "1" : "0";
    document.getElementById("Disabled").value = value;
    var test1 = document.getElementById("Disabled").value;
    console.log(value + " "+test1);
        
}

function validateEmail(email) {
    // Biểu thức chính quy để kiểm tra định dạng email
    var re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}
function onEmailChange(e) {
    alert("test1");
    var email = e.sender.value();
    var isValid = validateEmail(email);

    // Hiển thị thông báo lỗi nếu email không hợp lệ
    if (!isValid) {
        e.sender.addClass("k-invalid");
        e.sender.attr("title", "Email không hợp lệ");
    } else {
        e.sender.removeClass("k-invalid");
        e.sender.attr("title", "");
    }
}