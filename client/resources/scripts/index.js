let app = document.getElementById('App');
const url = "https://localhost:7159/api/song";

// var songs = function()
//     {
//         fetch(url).then(function(response){
//             return response.json();
//         })
//         .then(function(data) ){
//             CreateTable(data);
//         }
//     }

function HandleOnLoad()
{
    // ReadAllSongs(); // function used for testing
    // CreateTable();
    let songs = Array.from(function()
    {
        fetch(url).then(function(response){
            return response.json();
        })
    })
    CreateTable(songs);
    CreateForm();
}
function ReadAllSongs()
{
    songs.forEach(song => {
        console.log("Title: " + song.title + "Artist: " + song.artist + "Deleted " + song.isDeleted + "Favorited " + song.isFavorited)
    });
}
function CreateTable(songs)
{
    let table = document.createElement("table")
    table.border = '1'
    table.id = 'songsTable'
    let tablebody = document.createElement("tbody")
    tablebody.id = 'songsTableBody'
    table.appendChild(tablebody)
    
    let tableRow = document.createElement("tr")
    tablebody.appendChild(tableRow)
    
    let th1 = document.createElement("th")
    th1.width = 500
    th1.appendChild(document.createTextNode('ID'))
    tableRow.appendChild(th1)   

    let th2 = document.createElement("th")
    th2.width = 500
    th2.appendChild(document.createTextNode('Title'))
    tableRow.appendChild(th2)

    let th3 = document.createElement("th")
    th3.width = 500
    th3.appendChild(document.createTextNode('Artist'))
    tableRow.appendChild(th3)

    let th4 = document.createElement("th")
    th4.width = 500
    th4.appendChild(document.createTextNode('Date Added'))
    tableRow.appendChild(th4)

    let th5 = document.createElement("th")
    th5.width = 500
    th5.appendChild(document.createTextNode('Favorite'))
    tableRow.appendChild(th5)

    let th6 = document.createElement("th")
    th6.width = 500
    th6.appendChild(document.createTextNode('Delete'))
    tableRow.appendChild(th6)
    
    songs.forEach(song =>
    {
        if (song.isDeleted == false)
    {
        let tableRow = document.createElement("tr")
        tablebody.appendChild(tableRow)
        
        let td1 = document.createElement("td")
        td1.width = 500
        td1.appendChild(document.createTextNode(`${song.id}`))
        tableRow.appendChild(td1)

        let td2 = document.createElement("td")
        td2.width = 500
        td2.appendChild(document.createTextNode(`${song.title}`))
        tableRow.appendChild(td2)

        let td3 = document.createElement("td")
        td3.width = 500
        td3.appendChild(document.createTextNode(`${song.artist}`))
        tableRow.appendChild(td3)

        let td4 = document.createElement("td")
        td4.width = 500
        td4.appendChild(document.createTextNode(`${song.dateAdded}`))
        tableRow.appendChild(td4)

        if (song.isFavorited != true)
        {
            let td5 = document.createElement("td")
            td5.width = 500
            let favoriteButton = document.createElement("button")
            favoriteButton.id = "favorite"
            favoriteButton.textContent = "Favorite"
            td5.appendChild(favoriteButton)
            tableRow.appendChild(td5)
            favoriteButton.onclick = function()
            {
                song.isFavorited = true
                SaveToCookies(song)
                location.reload()
            }
            let td6 = document.createElement("td")
            td6.width = 500
            let deleteButton = document.createElement("button")
            deleteButton.id = "delete"
            deleteButton.textContent = "Delete"
            td6.appendChild(deleteButton)
            tableRow.appendChild(td6)
            deleteButton.onclick = function()
            {
                song.isDeleted = true
                SaveToCookies(song)
                location.reload()
            }
        }
        else
        {
            let td5 = document.createElement("td")
            td5.width = 500
            let favoriteButton = document.createElement("img")
            favoriteButton.id = "favorite"
            favoriteButton.setAttribute("src", "./resources/image/heart.jpg")
            favoriteButton.setAttribute("height", "100px")
            favoriteButton.setAttribute("width", "100px")
            td5.appendChild(favoriteButton)
            tableRow.appendChild(td5)
            favoriteButton.onclick = function()
            {
                song.isFavorited = true
                SaveToCookies(song)
                location.reload()
            }
            
            let td6 = document.createElement("td")
            td6.width = 500
            let deleteButton = document.createElement("button")
            deleteButton.id = "delete"
            deleteButton.textContent = "Delete"
            td6.appendChild(deleteButton)
            tableRow.appendChild(td6)
            deleteButton.onclick = function()
            {
                song.isDeleted = true
                SaveToCookies(song)
                location.reload()
            }
        }
    }
    })
    app.appendChild(table)
}
function CreateForm()
{
    let form = document.createElement("form")
    let textInput = document.createElement("input")
    textInput.type = "text"
    textInput.placeholder = "Song title"
    textInput.id = "newSong"
    form.appendChild(textInput)

    let textInput2 = document.createElement("input")
    textInput2.type = "text"
    textInput2.placeholder = "Artist"
    textInput2.id = "newArtist"
    form.appendChild(textInput2)

    let submitButton = document.createElement("button")
    submitButton.textContent = "Add song"
    form.appendChild(submitButton)

    form.addEventListener("submit", function(e)
    {
        e.preventDefault()
        let song = {
            id: songs.length,
            title: e.target.elements.newSong.value,
            artist: e.target.elements.newArtist.value,
            dateAdded: new Date().toJSON().slice(0,10),
            isFavorited: false,
            isDeleted: false
        }
        AddRow(song)
        songs.push(song)
        SaveToCookies()
        e.target.elements.newSong.value = " "
        e.target.elements.newArtist.value = " "
        location.reload()
    })

    app.appendChild(form)

}
function AddRow(song)
{
    let tablebody = document.getElementById("songsTableBody")
    let tableRow = document.createElement("tr")
    tablebody.appendChild(tableRow)
    
    let td1 = document.createElement("td")
    td1.width = 500
    td1.appendChild(document.createTextNode(`${song.id}`))
    tableRow.appendChild(td1)

    let td2 = document.createElement("td")
    td2.width = 500
    td2.appendChild(document.createTextNode(`${song.title}`))
    tableRow.appendChild(td2)

    let td3 = document.createElement("td")
    td3.width = 500
    td3.appendChild(document.createTextNode(`${song.artist}`))
    tableRow.appendChild(td3)

    let td4 = document.createElement("td")
    td4.width = 500
    td4.appendChild(document.createTextNode(`${song.dateAdded}`))
    tableRow.appendChild(td4)
    
    tablebody.appendChild(tableRow)
}