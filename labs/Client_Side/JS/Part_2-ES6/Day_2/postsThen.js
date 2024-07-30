function getUsers() {
    fetch('https://jsonplaceholder.typicode.com/users')
    .then(response => response.json())
    .then(data => renderUsers(data));
    return data;
}

function getPosts(userId) {
    fetch(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`)
    .then(response => response.json())
    .then(data => renderPosts(data));
    return data;
}

async function showUsers() {
    getUsers();
}


function renderUsers(users) {
    var usersDiv = document.getElementById('users');
    var header = document.createElement('p');
    usersDiv.innerHTML = '';
    usersDiv.className = 'container d-flex flex-wrap';
    users.forEach(
        user => {
            var userButton = document.createElement('button');
            userButton.className = 'btn btn-primary m-3';
            userButton.innerHTML = user.name;
            userButton.onclick = _ => showPosts(user.id);
            usersDiv.appendChild(userButton);
        }
    );
}

async function showPosts(userId) {
    getPosts(userId);
}

function renderPosts(posts) {
    var postsDiv = document.getElementById('posts');
    postsDiv.innerHTML = '<h2>Posts</h2>';
    postsDiv.className = 'list-group';
    posts.forEach(
        post => {
            console.log(post);
            var postLi = document.createElement('li');
            postLi.className = 'list-group-item list-group-item-dark';
            postLi.innerHTML = post.title;
            postsDiv.appendChild(postLi);
        }
    );
}
// showUsers();

export default { showUsers, showPosts };