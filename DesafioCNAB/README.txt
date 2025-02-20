1- Para executar o projeto completo, precisa executar o projeto CNAB.API e o CNAB.Frontend,
existe tbm a opção de compilar para executar no docker.

2- Na service encontra-se a regra de negocio, sendo nesse contexto o processamento do arquivo CNAB.

3- O banco de dados foi gerado como Code First to Database, 
executei o Migration para gerar meu banco de dados no SQL Server a partir
do que foi codificado no projeto dentro da CNAB.Model.

4- No front, temos duas telas simples, uma para realizar o upload 
e outra para listar as informações do CNAB.

5- Teste integrado chegou a ser criado para as duas chamadas da API, 
porém começou a ocorrer um erro de compilação para gerar o arquivo testhost.deps.json,
este arquivo é necessário para o teste integrado, então, 
por falta de tempo devido outros afazeres, optei por remover os dois testes.

6- Foi criado teste unitário para a camada do Service.