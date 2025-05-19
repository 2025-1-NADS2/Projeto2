# Instituto Criativo - Dashboard ONG

## Requisitos

- Node.js (v16 ou superior recomendado)
- npm (geralmente instalado junto com o Node.js)
- MySQL Server

## Instalação

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
cd front03
```

### 2. Instale as dependências do backend

```bash
cd backend
npm install
```

### 3. Instale as dependências do frontend

```bash
cd ../
npm install
```

### 4. Configure o banco de dados

- Crie o banco de dados MySQL usando o script `criar_banco.sql`:

```bash
# No MySQL CLI ou ferramenta gráfica, execute:
source criar_banco.sql
```

- Ajuste o usuário e senha do banco em:
  - `backend/db.js`
  - `backend/models/index.js`

### 5. Inicie o backend

```bash
cd backend
node index.js
```

O backend rodará em `http://localhost:3001`.

### 6. Inicie o frontend

```bash
cd ..
npm run dev
```

O frontend rodará em `http://localhost:5173` (ou porta informada pelo Vite).

## Observações

- Para exportar doações para Excel, é necessário o pacote `exceljs` no backend (`npm install exceljs`).
- As imagens enviadas são salvas na pasta `backend/uploads`.
- O backend precisa estar rodando para o frontend funcionar corretamente.

---
