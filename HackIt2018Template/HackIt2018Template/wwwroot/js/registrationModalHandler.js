//used for team registration on modal window, home


function DisplayRegisterModalProcedure()
{

    document.getElementById('id01').style.display = 'block';
    // Get the modal
    var modal = document.getElementById('id01');

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}



//ajax for sending form data to the controller !
function SendFormData()
{
    var teamData = GetTeamData();

    $.ajax({
        type: 'POST',
        url: 'Home/Register',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(teamData),
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

function GetTeamData()
{
    var td = {
        Teamname: document.getElementById("TeamName").value,
        Password: document.getElementById("TeamPassword").value,
        Members: GetMembers()
    };

    return td;
}

//returns array of all 4 members in form provided
function GetMembers()
{
    //name, surname, mail
    var members = [];

    for (var i = 1; i <= 4; i++)
    {
        var memberNameId = "member" + i.toString() + "_name";
        var memberSurnameId = "member" + i.toString() + "_surname";
        var memberMailId = "member" + i.toString() + "_mail";

        members.push
        ({
            name: document.getElementById(memberNameId).value,
            surname: document.getElementById(memberSurnameId).value,
            mail: document.getElementById(memberMailId).value,
        })
    }
    return members; 
}

