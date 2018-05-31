// Display all notes on page load 
$(document).ready(function(){
    getNotes();
});

/* 
Create a new note using an AJAX call. If the reponse is not failure, 
calls upon the displayNote function to display note
*/
$(document).on('submit', '#noteForm', function(e){
    e.preventDefault();
    $('#error').html("");
    $.post("/create", $('#noteForm').serialize(), function(response){
        if(response.failed == "true"){
            $("#error").html("Title and content cannot be empty");
        }else{
            for (note of response){
                displayNote(note);
            }
        }
        $("#noteForm")[0].reset();
    })
})

/* 
Clicking the note's title will replace it with a new form to update title. Typing a new
title and pressing enter will make an AJAX call to update the title and replace the form with the response
*/
$(document).on('click', 'h2', function(){
    var id = $(this).closest('div').attr('id')
    $(this).replaceWith(
        `<form id="titleForm" action="/update/title/${id}" method="post">
            <input type="text" name="NoteTitle" placeholder="Update title...">
        </form>`
    )
    $('#titleForm').on('submit', function(e){
        e.preventDefault();
        $.post(`/update/title/${id}`, $('#titleForm').serialize(), function(response){
            for (note of response){
                $('#titleForm').replaceWith(`<h2>${note.title}</h2>`)
            }
        })
    })
})

/* 
Clicking on the content of the note will replace it with a form to update the content. Once 
new content is entered, app will listen for event handler "pressing ENTER". If enter is pressed, AJAX
call will be made to update the note content and replace it with the response 
*/
$(document).on('click', '.contentTag', function(){
    var id = $(this).closest('div').attr('id')
    $(this).replaceWith(
        `<form id="contentForm" action="/update/content/${id}" method="post">
            <textarea style="display: block; margin: 5px 0px;" name="NoteContent" id="" cols="40" rows="6" placeholder="Update note content here..."></textarea>
        </form>`
    )
    $('#contentForm').on('keypress', function(e){
        if (e.which == 13){
            $(this).submit()
        }
    })
    $('#contentForm').on('submit', function(e){
        e.preventDefault();
        $.post(`/update/content/${id}`, $('#contentForm').serialize(), function(response){
            for (note of response){
                $('#contentForm').replaceWith(`<p class="contentTag">${note.content}</p>`)
            }
        })
    })
})

// Function to retrieve all notes. Calls the 'notes' route to retrieve all notes as a JSON response 
function getNotes(){
   $('#placeholder').text("");
   $.get("/notes", function(response){
       for(note of response){
           displayNote(note);
       }
   })
}

// Function to display a note
function displayNote(note){
    $('#placeholder').prepend(
        `<div id="${note.id}" style="border-bottom: 1px solid silver;">
            <h2>${note.title}</h2>
            <p class="contentTag">${note.content}</p>
            <p style="text-align: right;">Created on ${note.updated_at}</p>
            <p style="text-align: right; font-size: 8pt; font-style: italic;">Click title or description to edit content</p>
            <a style="display: block; text-align: right;" onclick="deleteNote(${note.id})">Delete Note</a>
        </div>`
    )
}

// Function to make AJAX call to delete a note and display all notes by calling the getNotes function
function deleteNote(id){
    $.post(`/delete/${id}`, function(){
        getNotes();
    })
}