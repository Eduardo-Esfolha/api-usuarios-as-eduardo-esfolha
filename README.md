🚀 Tecnologias Utilizadas

.NET 8.0

ASP.NET Core Minimal APIs

Entity Framework Core 8.0

SQLite

FluentValidation

Swagger / OpenAPI

Dependency Injection

🧩 Padrões de Projeto Implementados

Clean Architecture

Separação clara entre Domain, Application, Infrastructure e API.

Repository Pattern

Abstração da camada de acesso a dados.

Service Pattern

Encapsulamento de regras de negócio.

DTO Pattern

Transferência de dados desacoplada das entidades.

Dependency Injection

Inversão de controle para testabilidade e manutenção.

🏁 Como Executar o Projeto
✔️ Pré-requisitos

.NET SDK 8.0 ou superior

✔️ Passos para rodar
# Clone o repositório
git clone https://github.com/seu-usuario/api-usuarios-as-seu-nome.git

# Acesse a pasta do projeto
cd apiUser

# Crie o banco de dados
dotnet ef database update

# Execute a aplicação
dotnet run


A API estará disponível em:

👉 http://localhost:5108

A documentação Swagger pode ser acessada (em ambiente de desenvolvimento):

👉 http://localhost:5108/swagger

📬 Exemplos de Requisições
➕ Criar Usuário (POST /usuarios)
{
  "nome": "Carlos Silva",
  "email": "carlos@email.com",
  "senha": "senha123",
  "dataNascimento": "1990-01-01",
  "telefone": "(11) 99999-9999"
}

📄 Listar Usuários (GET /usuarios)
curl -X GET http://localhost:5108/usuarios

🗂️ Estrutura do Projeto
📁 ApiUser
 ├── 📁 API           -> Configuração da API e Minimal Endpoints
 ├── 📁 Application   -> Services, DTOs, Interfaces, Validadores
 ├── 📁 Domain        -> Entidades e Regras de Negócio
 ├── 📁 Infrastructure-> Repositórios e EF Core
 └── Program.cs       -> Configuração principal

👤 Autor

Nome: Eduardo Lopes Esfolha
Curso: Desenvolvimento Backend
Apresentação: (https://drive.google.com/drive/folders/1uQmqenEc6o4FZ2tj2LfPDjNizIIzmihO?usp=sharing)
