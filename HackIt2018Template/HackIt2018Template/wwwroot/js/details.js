﻿$(document).ready(function () {

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

            var gameChangerDevs = document.getElementsByClassName('gameChangersDevs');
            for (i = 1; i <= gameChangerDevs.length; i++) {
                var memberPicId = "member" + i.toString() + "Pic";

               if (teamName == "Game_changers")
               {
                   console.log("GameChangers");
                   $(".gameChangersDevs").show();
                   var gameChangerPicName = "picT" + i.toString() + ".gif";
                   document.getElementById(memberPicId).src = "images/picTeam/" + gameChangerPicName;
                }
                else
                {
                   console.log("Drugi tim");
                   $(".gameChangersDevs").hide();
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

