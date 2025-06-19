using Microsoft.AspNetCore.Mvc;
using Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            usuarios.Add(usuario);
            return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarios);
        }

        [HttpGet("{nome}")]
        public IActionResult Buscar(string nome)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Nome.ToLower() == nome.ToLower());
            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            return Ok(usuario);
        }

        [HttpPut("{nome}")]
        public IActionResult Editar(string nome, Usuario novoUsuario)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Nome.ToLower() == nome.ToLower());
            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            usuario.Email = novoUsuario.Email;
            usuario.Idade = novoUsuario.Idade;

            return Ok(new { mensagem = "Usuário atualizado com sucesso!" });
        }
    }
}
