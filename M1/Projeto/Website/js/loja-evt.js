const loginButton = document.getElementById("loginButton");
const loginModal = document.getElementById("loginModal");
const loginForm = document.getElementById("loginForm");
const loginUsername = document.getElementById("username");
const loginPassword = document.getElementById("password");
const welcomeUser = document.getElementById("welcomeUser");
const infoCardModal = document.getElementById("infoCard");
const infoCardModalContent = document.getElementById("infoCard-content");
const searchIcon = document.getElementById("pesquisa");
const searchInput = document.getElementById("buscador");

loginForm.addEventListener("submit", login);
searchIcon.addEventListener("submit", searchInDB);

window.onclick = function (event) {
	if (event.target == loginModal) {
		closeLoginModal();
	}
	if (event.target == infoCardModal) {
		closeInfoCardModal();
	}
};

function openLoginModal() {
	loginModal.style.display = "block";
}

function closeLoginModal() {
	loginUsername.value = "";
	loginPassword.value = "";
	loginModal.style.display = "none";
}

function authentication() {
	if (utilizador.getUsername === undefined)
	{
		openLoginModal();
		return false;
	}
	return true;
}

function afterLogin() {
	loginButton.style.display = "none";
	welcomeUser.style.display = "block";
	welcomeUser.textContent = "Bem vind@, " + utilizador.getUsername + "!";
}

function login(event) {
	event.preventDefault();
	if (loginUsername.value == "") {
		showPopup("Não submeteu os seus dados de login!");
		return ;
	}
	if (loginPassword.value.length < 4) {
		showPopup("Password tem de ter mais de 4 caracteres!");
		loginPassword.value = "";
		return ;
	}
	let i = 0;
	let data;
	while (i <= userList.length)
	{
		if (userList[i] === undefined)
			break ;
		data = JSON.parse(userList[i]);
		if (data.username == loginUsername.value && data.password == loginPassword.value)
		{
			utilizador = new User(data);
			showPopup("Perfil encontrado. Olá novamente!");
			break ;
		}
		i++;
	}
	if (utilizador.getUsername === undefined)
	{
		utilizador = new User({ username: loginUsername.value, password: loginPassword.value , favorites: [], cart: [] });
		showPopup("Novo perfil criado. Bem vind@!");
	}
	closeLoginModal();
	afterLogin();
	buildPage();
}

function showInfoCardModal(isbn) {
	infoCardModal.style.display = "block";
	let curso = db.filter(list => list.ISBN === isbn);
	if (curso.length > 0)
		curso = curso[0];
	let content = document.createElement("div");
	content.classList.add("card");
	let priceLine = isOnSale(curso.preco, curso.promocao);
	content.innerHTML = `<img class="imagen-curso u-full-width" onclick="showInfoCardModal(alt)" src=${isImg(curso.imagem)} alt="${curso.ISBN}"/>
		<div class="info-card">
			<h4>${curso.titulo} <span class="rating">${curso.rating} <img src="img/estrela.png" /></span></h4>
			<p>&nbsp;&nbsp;&nbsp;&nbsp;Por: ${curso.autor}</p>
			<p>Resumo: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus luctus vel dolor id imperdiet. Nam a placerat elit. Maecenas auctor mi sapien, sed mattis nisl pellentesque et. Sed at velit mollis, lobortis lectus sit amet, posuere quam. Nam augue ligula, vestibulum id mi vel, aliquam sagittis massa. Vestibulum eu congue arcu. In venenatis malesuada imperdiet. Nullam viverra erat sit amet nulla convallis commodo. Donec laoreet dictum tincidunt. Etiam id elementum lectus. Etiam eu purus odio. Proin tempor blandit risus non volutpat.</p>
			<p class="preco">${priceLine}</p>
			<a id="addFavButton" class="u-full-width button-primary button input adicionar-carrinho" ${isFav(curso.ISBN)}<img src="img/estrela.png" alt="star">
			</a>
			<a id="addCartButton" class="u-full-width button-primary button input adicionar-carrinho" onclick="addToCart('${curso.ISBN}')">
				Adicionar ao Carrinho
			</a>
		</div>`;
	infoCardModalContent.appendChild(content);
}

function closeInfoCardModal() {
	infoCardModalContent.removeChild(infoCardModalContent.lastElementChild);
	infoCardModal.scrollTop = 0;
	infoCardModal.style.display = "none";
}

function searchInDB(event) {
	event.preventDefault();
	cardListArray = db.filter(obj => Object.values(obj).some(value => String(value).toLowerCase().includes(searchInput.value.toLowerCase())));
	createCardListArray(cardListArray);
	buildCart();
	clearPage();
	buildCatSelector();
	buildCardList();
	buildPagination();
	const courseList = document.getElementById("lista-cursos");
	courseList.firstElementChild.textContent = "Pesquisa por: " + searchInput.value;
	searchInput.value = "";
}