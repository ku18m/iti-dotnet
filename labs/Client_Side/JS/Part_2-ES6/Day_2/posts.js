async function getUsers() {
    let response = await fetch('https://jsonplaceholder.typicode.com/users');
    let data = await response.json();
    return data;
}

async function getPosts(userId) {
    let response = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`);
    let data = await response.json();
    return data;
}

async function showUsers() {
    var users = await getUsers();
    renderUsers(users);
}


function renderUsers(users) {
    var usersDiv = document.getElementById('users');
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
    let posts = await getPosts(userId);
    renderPosts(posts);
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