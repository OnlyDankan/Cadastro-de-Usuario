using System;
using System.Collections.Generic;

namespace CadastroUsuarios
{
    class Usuario
    {
        public string Nome { get; set; } //nome do usuário
        public string Email { get; set; } //email do usuário
        public int Idade { get; set; } //idade do usuário

        public Usuario(string nome, string email, int idade)
        {
            Nome = nome;
            Email = email;
            Idade = idade;
        }

        //Aqui é o que retorna as informações do usuário como string
        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, Idade: {Idade}";
        }
    }

    class Program
    {
        static List<Usuario> usuarios = new List<Usuario>(); //Aqui é feita a lista para armazenar os usuários

        static void Main()
        {
            int opcao; //opção escolhida pelo usuário

            //Aqui deixei um loop pra mostrar o menu
            do
            {
                //Exibição do Menu
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Buscar Usuário");
                Console.WriteLine("4. Editar Usuário");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                //aqui vai executar toda a ação com base na opção escolhida
                if (opcao == 1) CadastrarUsuario(); //Essa parte é onde o usuário vai se cadastrar
                else if (opcao == 2) ListarUsuarios(); //Aqui vai listar todos os usuários
                else if (opcao == 3) BuscarUsuario(); //vai fazer uma busca pelo usuário
                else if (opcao == 4) EditarUsuario(); //Vai editar o usuário já listado
                else if (opcao != 0) Console.WriteLine("Opção Invalida!"); //Caso o usuário escolha uma opção inválida

                Console.WriteLine(); //Aqui deixei uma linha em branco pra separar as opções e ficar com uma melhor visualização
            } while (opcao != 0); //O loop continua até o usuário decidir sair
        }

        //Aqui vai começar um método para cadastrar um novo usuário
        static void CadastrarUsuario()
        {
            Console.Write("Nome: ");
            string nome = (Console.ReadLine() ?? "").Trim(); //É lido o nome do usuário e removido espaços extras

            Console.Write("Email: ");
            string email = (Console.ReadLine() ?? "").Trim(); //o mesmo que foi aplicado anteriormente

            Console.Write("Idade: ");
            int idade = int.TryParse(Console.ReadLine(), out int idadeValida) ? idadeValida : 0; //Vai coletar a idade e verificar se é um número válido

            usuarios.Add(new Usuario(nome, email, idade)); //Agora aqui vai add o usuário na lista
            Console.WriteLine("Usuário cadastrado!"); //Mensagem de confirmação
        }

        //Nessa parte vou usar um método pra listar todos os usuários
        static void ListarUsuarios()
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado."); //Caso não haja usuários cadastrados
                return;
            }

            foreach (var usuario in usuarios)
                Console.WriteLine(usuario); //vai mostrar as informações do usuário
        }

        //esse código vai ser usado pra buscar o usuário pelo nome digitado
        static void BuscarUsuario()
        {
            Console.Write("Nome do usuário: ");
            string nomeBusca = (Console.ReadLine() ?? "").Trim(); //Vai ler o nome que foi digitado e remover espaços extras

            var usuario = usuarios.Find(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase)); //vai fazer uma busca no usuário na lista

            //vai iniciar um IF/ELSE pra verificar se o usuário foi encontrado
            if (usuario != null) //aqui vê se ele tá na lista ou não 
                Console.WriteLine(usuario); //Mostra as informações do usuário encontrado
            else
                Console.WriteLine("Usuário não encontrado."); //Caso não ache nenhum usuário
        }

        //Método corrigido para editar o usuário
        static void EditarUsuario()
        {
            Console.Write("Digite o nome do usuário que deseja editar: ");
            string nomeBusca = (Console.ReadLine() ?? "").Trim(); //Vai ler o nome que foi digitado e remover espaços extras

            var usuario = usuarios.Find(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase)); //Busca o usuário

            //Verifica se o usuário foi encontrado
            if (usuario != null)
            {
                Console.Write("Novo nome (ou pressione ENTER para manter o mesmo): ");
                string novoNome = (Console.ReadLine() ?? "").Trim(); //Nome a ser atualizado, com remoção de espaços extras
                if (!string.IsNullOrWhiteSpace(novoNome)) //Verifica se o nome não está vazio
                    usuario.Nome = novoNome;

                Console.Write("Novo email (ou pressione ENTER para manter o mesmo): ");
                string novoEmail = (Console.ReadLine() ?? "").Trim(); //Email a ser atualizado, com remoção de espaços extras
                if (!string.IsNullOrWhiteSpace(novoEmail)) //Verifica se o email não está vazio
                    usuario.Email = novoEmail;

                Console.Write("Nova idade (ou pressione ENTER para manter o mesmo): ");
                string novaIdade = (Console.ReadLine() ?? "").Trim(); //Idade a ser atualizada, com remoção de espaços extras
                if (!string.IsNullOrWhiteSpace(novaIdade)) //Verifica se a idade foi preenchida
                {
                    if (int.TryParse(novaIdade, out int idadeConvertida)) //Tenta converter para int
                        usuario.Idade = idadeConvertida;
                    else
                        Console.WriteLine("Idade inválida!"); //Mensagem de erro caso a conversão falhe
                }

                Console.WriteLine("Usuário atualizado com sucesso!"); //Mensagem de confirmação
            }
            else
            {
                Console.WriteLine("Usuário não encontrado."); //Mensagem caso o usuário não seja encontrado
            }
        }
    }
}
