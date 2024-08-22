Para subir o projeto dentro do docker, execute o comando abaixo na raiz do projeto:

    docker compose up --build

Obs.: Existe na raiz do projeto um nuget.config que baixará o IET.Common que é um projeto privado, esse arquivo é necessário para pleno funcionamento do sistema (Tratamento de erros, logs, tratativa de retorno, acesso a dados, etc)
