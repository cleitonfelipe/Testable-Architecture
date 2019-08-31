#language:pt-br
Funcionalidade: CadastrarCarro
	Pedido de cadastro e busca de um carro 

@Servico
Cenario: Adicionar um novo carro
	Dado Que eu entrei no sistema de cadastro de autos
	E Digito marca "Volks"
	E Digito modelo "Gol"
	E Digito versão "1.6"
	Quando O sistema verifica se existe o carro já cadastrado
	Dado Que eu clico para gravar
	Então o resultado deve ser "verdadeiro"

Cenario: Buscar um carro cadastrado
	Dado Que eu entrei no sistema de cadastro de autos
	E busco os carro de marca "Carro 1", modelo "Modelo 1" e versão "Basico"
	Quando eu clico em buscar
	Então o resultado deve ser 1 item na lista
