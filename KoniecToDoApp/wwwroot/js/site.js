$(document).ready(function(){
    $(".changeList").on("change", function(){
        let toId = $(this).val();
        window.location.href = "/"+toId;
    });
    $(".todoDelete").on("click", function(){
        let toId = $(this).data("id");
        if(confirm("Are you sure You want to delete entire list with all the tasks?")){
            window.location.href = "/List/Delete/"+toId;
        }
    });
    $("input[type='checkbox']").on("change", function(){
        let toId = $(this).data("id");
        let listId = $(this).data("listid");
        let checked = $(this).prop("checked");
        window.location.href = "/Task/Complete/"+toId+"/"+checked+"/"+listId;
    });
    $(".deleteTask").on("click", function(){
        let toId = $(this).data("id");
        let listId = $(this).data("listid");
        if(confirm("Are you sure You want to delete this task?")){
            window.location.href = "/Task/Delete/"+toId+"/"+listId;
        }
    });
    $(".datePicker").on("change", function(){
        let selectedDate = $(this).val();
        let listId = $(this).data("listid");
        if (listId > 0){
            window.location.href = "/"+listId+"/Date/"+selectedDate;
        }
        else{
            window.location.href = "/Date/"+selectedDate;
        }
    });
    $(".showCompleted").on("click", function(){
        var listId = $(this).data("listid");
        var dateSet = $(this).data("dateset");
        var completed = $(this).data("completed");
        var displayStr = "";
        if(completed == "False"){
            displayStr = "/Completed/True"
        }
        if(listId != "" && dateSet == ""){
            window.location.href = "/"+listId+displayStr;
        }
        else if(listId == "" && dateSet != ""){
            window.location.href = "/Date/"+dateSet+displayStr;
        }
        else if(listId != "" && dateSet != ""){
            window.location.href = "/"+listId+"/Date/"+dateSet+displayStr;
        }
        else{
            if(displayStr.length > 0){
                window.location.href = displayStr.substring(1, displayStr.length);
            }
            else{
                window.location.href = "/";
            }
        }
    });
});