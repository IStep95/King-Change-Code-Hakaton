$(document).ready(function () {

    getTeamData();

});

function getTeamData(){

    $.ajax({
        url: '/Home/TeamDetails',
        type: 'GET',    
        dataType: 'json',
        success: function (data) {
       
            console.log("success");

            var detailsDiv = document.getElementById("details");
            detailsDiv.style.visibility = "visible";
            detailsDiv.style.height = "500px";

            var teamName = data.TeamName;
            document.getElementById("teamName").innerHTML = teamName;
            var teamMembers = data.Members;

            for (i = 1; i <= 4; i++)
            {
               var memberNameId = "member" + i.toString() + "Name";
               var memberMailId = "member" + i.toString() + "Email";
               console.log(memberMailId);
               console.log(teamMembers[i - 1].Mail);
               document.getElementById(memberNameId).innerHTML = teamMembers[i - 1].Name;
               document.getElementById(memberMailId).innerHTML = teamMembers[i - 1].Mail;
            }

            var elements = document.getElementsByClassName('gameChangers');
            var i;
            for (i = 0; i < elements.length; i++) {
               if (teamName == "Game_changers")
               {
                    console.log("GameChangers");
                    elements[i].style.visibility = "visible";
                }
                else
                {
                    console.log("Drugi tim");
                    elements[i].style.visibility = "hidden";
                    var memberPicId = "member" + i.toString() + "Pic";
                    document.getElementById(memberPicId).src="images/placeholderPerson.png";
                }
             }
        },
        error: function (xhr, status, error) {
           //alert(xhr.responseText);
           console.log("error");
           var detailsDiv = document.getElementById("details");
           detailsDiv.style.visibility = "hidden";
           detailsDiv.style.height = "0px";

        }
    });


}

