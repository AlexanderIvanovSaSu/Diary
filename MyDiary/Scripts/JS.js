function DeleteStroy(id) {
    var form = document.getElementById("deleteForm");
    //var form = document.getElementsByTagName("form");
    form.setAttribute("method", "post");
    //form.setAttribute("action", "Delete/" + id);//Tova e pytq koito e v delete stranicata
    form.setAttribute("action", "Stories/Delete/" + id);//Tova e pytq koito e v delete stranicata
    //document.body.appendChild(form);
    form.submit();
    // window.open("Stories", "_self");
}

function Confirmation(id) {
    var yes;
    var r = confirm("Do you want to delete this story?");
    if (r == true) {
        yes = DeleteStroy(id);
    } else {
        return "Index";
    }
}