// Declara a classe Pessoa
class Pessoa
{
    // Declara as propriedades Nome, Sobrenome, DataNascimento, Identificacao e Endereco, com seus respectivos getters e setters
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Identificacao { get; set; }
    public string Endereco { get; set; }
}

// Declara a classe Cartorio
class Cartorio
{
    // Declara uma lista de pessoas registradas
    private List<Pessoa> pessoas = new List<Pessoa>();

    // Declara o método para adicionar uma pessoa à lista
    public void AdicionarPessoa(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
    }

    // Declara o método para remover uma pessoa da lista
    public void RemoverPessoa(Pessoa pessoa)
    {
        pessoas.Remove(pessoa);
    }

    // Declara o método para buscar uma pessoa na lista pelo número de identificação
    public Pessoa BuscarPessoaPorIdentificacao(string identificacao)
    {
        return pessoas.FirstOrDefault(p => p.Identificacao == identificacao);
    }
}

// Declara a classe Program
class Program
{
    // Declara o método principal
    static void Main(string[] args)
    {
        // Cria uma instância do cartório
        Cartorio cartorio = new Cartorio();

        // Inicia um loop infinito
        while (true)
        {
            // Exibe as opções para o usuário
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar pessoa");
            Console.WriteLine("2 - Remover pessoa");
            Console.WriteLine("3 - Buscar pessoa");
            Console.WriteLine("4 - Sair");

            // Lê a opção selecionada pelo usuário
            string opcao = Console.ReadLine();

            // Verifica a opção selecionada
            if (opcao == "1") // Se a opção for 1 (adicionar pessoa)
            {
                // Cria uma nova instância da classe Pessoa
                Pessoa pessoa = new Pessoa();

                // Lê e armazena o nome da pessoa
                Console.WriteLine("Digite o nome:");
                pessoa.Nome = Console.ReadLine();

                // Lê e armazena o sobrenome da pessoa
                Console.WriteLine("Digite o sobrenome:");
                pessoa.Sobrenome = Console.ReadLine();

                // Lê e armazena a data de nascimento da pessoa, convertendo-a para o tipo DateTime
                Console.WriteLine("Digite a data de nascimento (DD/MM/AAAA):");
                pessoa.DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                // Lê e armazena o número de identificação da pessoa
                Console.WriteLine("Digite o número de identificação:");
                pessoa.Identificacao = Console.ReadLine();

                // Lê e armazena o endereço da pessoa
                Console.WriteLine("Digite o endereço:");
                pessoa.Endereco = Console.ReadLine();

                // Adiciona a pessoa à lista de pessoas registradas no cartório
                cartorio.AdicionarPessoa(pessoa);

                // Exibe uma mensagem de sucesso
                Console.WriteLine("Pessoa adicionada com sucesso!");
            }
            else if (opcao == "2") // Se a opção for 2 (remover pessoa
            {
                // Lê o número de identificação da pessoa a ser removida
                Console.WriteLine("Digite o número de identificação da pessoa a ser removida:");
                string identificacao = Console.ReadLine();

                // Busca a pessoa na lista de pessoas registradas pelo número de identificação
                Pessoa pessoa = cartorio.BuscarPessoaPorIdentificacao(identificacao);

                // Verifica se a pessoa foi encontrada
                if (pessoa != null)
                {
                    // Remove a pessoa da lista de pessoas registradas no cartório
                    cartorio.RemoverPessoa(pessoa);

                    // Exibe uma mensagem de sucesso
                    Console.WriteLine("Pessoa removida com sucesso!");
                }
                else
                {
                    // Exibe uma mensagem de erro caso a pessoa não tenha sido encontrada
                    Console.WriteLine("Pessoa não encontrada.");
                }
            }
            else if (opcao == "3") // Se a opção for 3 (buscar pessoa)
            {
                // Lê o número de identificação da pessoa a ser buscada
                Console.WriteLine("Digite o número de identificação da pessoa:");
                string identificacao = Console.ReadLine();

                // Busca a pessoa na lista de pessoas registradas pelo número de identificação
                Pessoa pessoa = cartorio.BuscarPessoaPorIdentificacao(identificacao);

                // Verifica se a pessoa foi encontrada
                if (pessoa != null)
                {
                    // Exibe os dados da pessoa encontrada
                    Console.WriteLine($"Nome: {pessoa.Nome} {pessoa.Sobrenome}");
                    Console.WriteLine($"Data de nascimento: {pessoa.DataNascimento.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Identificação: {pessoa.Identificacao}");
                    Console.WriteLine($"Endereço: {pessoa.Endereco}");
                }
                else
                {
                    // Exibe uma mensagem de erro caso a pessoa não tenha sido encontrada
                    Console.WriteLine("Pessoa não encontrada.");
                }
            }
            else if (opcao == "4") // Se a opção for 4 (sair)
            {
                // Sai do loop infinito
                break;
            }
            else // Se a opção selecionada não for válida
            {
                // Exibe uma mensagem de erro
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}