Como Executar o Projeto
  Para rodar este projeto, siga os passos abaixo:

1. Pré-requisitos
  * .NET Core 8.0
  * Visual Studio (versão compatível com .NET Core 8.0)
  * SQL Server (ou outro banco de dados compatível)
  * Pacotes NuGet necessários para cada projeto

2. Configuração da Base de Dados
  * Navegue até o projeto Biblioteca.Infra.Data, dentro da pasta Script, e execute o script Biblioteca - Script de     criação.sql. Esse script criará a estrutura necessária no banco de dados.

  * Após a execução do script, é necessário configurar a conexão com o banco de dados. No momento, o projeto está configurado para uma base de dados local. Altere a string de conexão de acordo com a sua configuração.

3. Baixar os Pacotes
  * Abra o projeto no Visual Studio e certifique-se de que todos os pacotes necessários foram baixados. Caso algum pacote esteja faltando, use o Gerenciador de Pacotes NuGet para restaurar os pacotes.

4. Configuração da Solução
  * A solução contém dois projetos principais: a API (Biblioteca.API) e o projeto MVC (Biblioteca.Aplicacao.Mvc).
Para rodá-los simultaneamente, configure a solução para iniciar ambos os projetos:
No Visual Studio, clique com o botão direito sobre a solução e selecione "Propriedades".
No menu "Configurações de inicialização", selecione a opção "Iniciar múltiplos projetos".
Para cada projeto, defina a ação "Iniciar".

6. Rodando o Projeto
  * Com a configuração concluída, basta rodar a solução no Visual Studio. O projeto MVC será executado no navegador, enquanto a API estará disponível para ser consumida.
