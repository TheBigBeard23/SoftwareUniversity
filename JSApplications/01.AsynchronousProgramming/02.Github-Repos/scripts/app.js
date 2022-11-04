function loadRepos() {
	const username = document.getElementById('username').value;
	const list = document.getElementById('repos');

	let response = fetch(`https://api.github.com/users/${username}/repos`);

	response
		.then(res => res.json())
		.then(repos => {

			list.innerHTML = '';

			for (const repo of repos) {
				list.innerHTML += `<li>
						<a href="${repo.html_url}" target="_blank">
								${repo.full_name}
						</a>
						</li>`;
			}
		})
		.catch(err => {
			list.innerHTML = err;
		});

}