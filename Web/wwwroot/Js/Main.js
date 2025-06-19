document.getElementById("formCadastro").addEventListener("submit", async function (e) {
  e.preventDefault();

  const nome = document.getElementById("nome").value;
  const email = document.getElementById("email").value;
  const idade = document.getElementById("idade").value;

  await fetch("/api/usuario", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ nome, email, idade })
  });

  this.reset();
  carregarUsuarios();
});

async function carregarUsuarios() {
  const resposta = await fetch("/api/usuario");
  const usuarios = await resposta.json();

  const lista = document.getElementById("listaUsuarios");
  lista.innerHTML = "";

  usuarios.forEach(u => {
    const item = document.createElement("li");
    item.textContent = `Nome: ${u.nome} | Email: ${u.email} | Idade: ${u.idade}`;
    lista.appendChild(item);
  });
}

window.onload = carregarUsuarios;
