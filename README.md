📦 Laravel API com Docker
Este projeto é uma API construída em Laravel, configurada para rodar com Docker, MySQL e Nginx. Ele já vem com autenticação via Sanctum integrada.

🚀 Como rodar o projeto
1. Pré-requisitos
Antes de começar, certifique-se de ter instalado:

Docker

Docker Compose

2. Estrutura dos containers
app: container principal com Laravel e PHP 8.2.

web: servidor Nginx que expõe o Laravel na porta 8000.

db: MySQL 8.0 com volume persistente e configuração pronta para o Laravel.

3. Subir os containers
No terminal, execute:

bash
Copiar
Editar
docker-compose up -d --build
Isso irá buildar o PHP, subir o MySQL, e rodar o Nginx na porta 8000.

4. Instalar as dependências Laravel
Acesse o container app e instale os pacotes com o Composer:

bash
Copiar
Editar
docker exec -it laravel_app bash
composer install
5. Configuração do ambiente
Crie o arquivo .env com base no .env.example:

bash
Copiar
Editar
cp .env.example .env
Em seguida, gere a chave da aplicação:

bash
Copiar
Editar
php artisan key:generate
Atualize o .env com as credenciais do banco:

env
Copiar
Editar
DB_CONNECTION=mysql
DB_HOST=db
DB_PORT=3306
DB_DATABASE=music_db
DB_USERNAME=laravel
DB_PASSWORD=secret
6. Rodar as migrations
bash
Copiar
Editar
php artisan migrate
7. Acessar a aplicação
Abra seu navegador em:

arduino
Copiar
Editar
http://localhost:8000
🔐 Autenticação com Sanctum
Este projeto utiliza Laravel Sanctum para autenticação de usuários via API token.

Sanctum já está instalado e configurado. Você pode gerar tokens com:

php
Copiar
Editar
$user->createToken('token-name')->plainTextToken;
Dica: lembre de configurar corretamente os middlewares e CORS para chamadas com frontend.

📁 Volumes e persistência
O volume dbdata é usado para manter os dados do MySQL salvos mesmo que o container seja removido.

O código-fonte é montado diretamente com volumes para facilitar o desenvolvimento.

📎 Extras
Laravel está rodando com PHP 8.2.

O Nginx está configurado via ./docker/nginx/default.conf (edite conforme necessário).

A imagem do Composer mais recente é usada para instalar pacotes.