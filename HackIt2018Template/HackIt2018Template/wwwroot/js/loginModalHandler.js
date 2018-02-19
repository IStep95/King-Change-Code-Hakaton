
function DisplayLoginModalProcedure() {

    document.getElementById('id02').style.display = 'block';

    // Get the login modal
    var modal2 = document.getElementById('id02');

    // When the user clicks anywhere outside of the login modal, close it
    window.onclick = function (event) {
        if (event.target == modal2) {
            modal2.style.display = "none";
        }
    }

}

///should get called when user presses login btn on login form. This calls the method for login in home controller
function LoginUser()
{
    var loginData = GetLoginFormData();

    $.ajax({
        type: 'POST',
        url: 'Home/Login',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(loginData),
        dataType: 'json',
        async: false,
        success: function (data) {
            alert(data);
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }

    });
}


///login form data ==> same as for registration, except members are null!!
function GetLoginFormData()
{
    var td = {
        Teamname: document.getElementById("Login_TeamName").value,
        Password: document.getElementById("Login_password").value,
    };

    return td;
}







