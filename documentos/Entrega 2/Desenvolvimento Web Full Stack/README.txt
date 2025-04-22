Projeto Node.js com Banco de Dados
Este projeto é composto por um backend em Node.js conectado a um banco de dados e um frontend simples. Siga as instruções abaixo para rodar a aplicação em sua máquina local.

🚀 Pré-requisitos
Node.js

MySQL ou outro SGBD compatível

Git

Extensão Live Server instalada no seu editor (como o VS Code)

📦 Instalação
1. Clone o repositório:
bash
Copiar
Editar
git clone https://github.com/seu-usuario/seu-projeto.git
🗄️ Banco de Dados
Inicie o MySQL no seu computador.

Crie o banco de dados usando o arquivo db.sql:

No terminal, execute o comando abaixo (ajustando seu_usuario):

bash
Copiar
Editar
mysql -u seu_usuario -p < db.sql
🔧 Configuração do Backend
Acesse a pasta do backend:

bash
Copiar
Editar
cd backend
Instale as dependências:

bash
Copiar
Editar
npm install
Configure as variáveis de ambiente:

No arquivo .env, edite os campos DB_USER e DB_PASSWORD com os dados da sua instalação do MySQL:

ini
Copiar
Editar
DB_HOST=localhost
DB_USER=seu_usuario
DB_PASSWORD=sua_senha
DB_NAME=nome_do_banco
DB_PORT=3306
Inicie o servidor backend:

bash
Copiar
Editar
npm start
Isso executará o arquivo server.js e iniciará o servidor backend.

🌐 Rodando o Frontend
Acesse a pasta do frontend (caso esteja separado, por exemplo em frontend/).

Clique com o botão direito no arquivo index.html e selecione "Open with Live Server".

Certifique-se de ter a extensão Live Server instalada no VS Code.

✅ Pronto!
Agora sua aplicação deve estar funcionando com o backend ativo e o frontend servindo a interface no navegador.

