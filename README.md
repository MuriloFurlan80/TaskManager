# TaskManager

Projeto desenvolvido em .NET seguindo os princípios da arquitetura limpa. Gerencia tarefas com separação clara entre camadas de domínio, aplicação, infraestrutura e apresentação.

---

## 🚀 Como configurar o projeto localmente

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/TaskManager.git
   cd TaskManager

2 - Instale os pacotes necessários:
dotnet restore

3 - Configure o banco de dados:
- Verifique se o SQL Server está instalado e em execução.
- Atualize a string de conexão no arquivo appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskManagerDb;Trusted_Connection=True;"

}
4 Execute as migrações:
-dotnet ef database update

▶️ Como rodar a aplicação
dotnet run

🗄️ Banco de dados utilizado
- SQL Server
- Gerenciado via Entity Framework Core
- Migrações armazenadas na pasta Migrations
- Contexto principal: TaskDbContext.cs

 Estrutura do projeto
- Domain: Entidades e enums da regra de negócio
- Application: Interfaces e serviços
- Infrastructure: Repositórios e contexto de banco
- Presentation: Controllers e DTOs da API
