var modal2;
var isErrorTxtCurrentlyDisplayed;


function DisplayLoginModalProcedure() {

    document.getElementById('id02').style.display = 'block';

    // Get the login modal
    modal2 = document.getElementById('id02');

    // When the user clicks anywhere outside of the login modal, close it
    window.onclick = function (event) {
        if (event.target == modal2) {
            modal2.style.display = "none";
        }
    }

    StopLoader();

}


function DisplayErrorMessage(message)
{
    $("#errorMessageHolder").text(message);
    isErrorTxtCurrentlyDisplayed = true;
    $("#errorMessageHolder").fadeIn(1500).delay(500).fadeOut(1500, function () {
        // Animation complete.
        isErrorTxtCurrentlyDisplayed = false;
    });
}


function ShowLoader()
{
    $("#loginFormLoader").show();
}


function StopLoader()
{
    $("#loginFormLoader").hide();
}



///should get called when user presses login btn on login form. This calls the method for login in home controller
function LoginUser()
{
    
    if (ValidateLoginForm()) {


        ShowLoader();

        var delayInMilliseconds = 300;

        setTimeout(function () {

            var loginData = GetLoginFormData();

            $.ajax({
                type: 'POST',
                url: 'Home/Login',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(loginData),
                dataType: 'json',
                async: false,
                success: function (data) {
                    StopLoader();
                    alert("prijava uspješna! :)");
                    modal2.style.display = "none";
                    getTeamData();
                },
                error: function (xhr, status, error) {
                    StopLoader();
                    if (!isErrorTxtCurrentlyDisplayed) {
                        DisplayErrorMessage(xhr.responseText.replace('[', '').replace("]", "").replace("\"", "").replace("!\"", ""));
                    }
                }
            });

        }, delayInMilliseconds);
    } 
}


function ValidateLoginForm()
{
    var teamData = GetLoginFormData();
    if (teamData.Teamname.trim().length === 0 )
    {
        //alert("niste unjeli ime tima");
        if (!isErrorTxtCurrentlyDisplayed)
        {
            DisplayErrorMessage("niste unjeli ime tima");
        }
        return false;
    }
    else if (teamData.Password.trim().length === 0)
    {
        if (!isErrorTxtCurrentlyDisplayed)
        {
            DisplayErrorMessage("niste unjeli lozinku");
        }
        return false;
    }
    else
    {
        return true;
    }
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







