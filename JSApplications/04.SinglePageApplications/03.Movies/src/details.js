import { loadHome } from "./home.js";
import { hideElements, showView } from "./util.js"
import { loadEdit } from "./edit.js";

const section = document.querySelector('#movie-example')
const container = section.querySelector('.container');
let movieId;

export async function loadDetails(id) {
  movieId = id;
  showView(section);
  loadMovie();
}

async function loadMovie() {
  const movie = await getMovie(movieId);
  section.replaceChildren(await createMovieCard(movie));
}

async function createMovieCard(movie) {

  const user = JSON.parse(localStorage.getItem('user'));
  const card = container.cloneNode(true);
  card.querySelector('h1').textContent = movie.title;
  card.querySelector('img').src = movie.img;
  card.querySelector('p').textContent = movie.description;

  const delBtn = card.querySelector('.btn.btn-danger');
  const editBtn = card.querySelector('.btn.btn-warning');
  const likeBtn = card.querySelector('.btn.btn-primary');
  const likes = card.querySelector('.enrolled-span');

  hideElements([delBtn, editBtn, likeBtn, likes]);

  if (!user) {
    likes.style.display = 'inline-block';
  }
  else if (user._id == movie._ownerId) {
    delBtn.style.display = 'inline-block';
    editBtn.style.display = 'inline-block';
  }
  else {
    likeBtn.style.display = 'inline-block';
  }

  card.querySelector('.enrolled-span').textContent = `Liked ${await getLikesCount()}`;
  card.querySelector('.col-md-4.text-center').addEventListener('click', (e) => onClick(e, movie, user));

  return card;
}

function onClick(e, movie, user) {

  if (e.target.tagName == 'A') {

    let command = e.target.textContent;
    
    if (command == 'Delete') {
      deleteMovie(movie, user);
    }
    else if (command == 'Edit') {
      loadEdit(movie, user);
    }
    else {
      likeMovie(movie, user);
    }
  }
}

async function deleteMovie(movie, user) {

  try {
    if (user._id != movie._ownerId) {
      throw new Error('You cannot delete this movie!')
    }

    const res = await fetch('http://localhost:3030/data/movies/' + movie._id, {
      method: 'delete',
      headers: {
        'X-Authorization': user.accessToken
      }
    });

    if (!res.ok) {
      const err = await res.json();
      throw new Error(err.message);
    }
    loadHome();
  }
  catch (err) {
    alert(err.message);
  }
}
async function likeMovie(movie, user) {

  try {

    if (!getOwnLike(user, movie)) {
      throw new Error('You cannot like this movie or already liked it.')
    }

    const res = await fetch(`http://localhost:3030/data/likes`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'X-Authorization': user.accessToken
      },
      body: JSON.stringify({ movieId: movie._id })
    });

    if (!res.ok) {
      throw new Error(err.message);
    }

  } catch (err) {
    alert(err.message)
  }

}
async function getOwnLike(movie, user) {

  if (!user) {
    return false;
  }

  const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movie._id}%22%20and%20_ownerId%3D%22${user._id}%22`)
  const like = await res.json();

  return like.length > 0;
}
async function getMovie() {
  const res = await fetch(`http://localhost:3030/data/movies/${movieId}`);
  return await res.json();
}

async function getLikesCount() {
  const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%224${movieId}%22&distinct=_ownerId&count`)
  return await res.json();
}



