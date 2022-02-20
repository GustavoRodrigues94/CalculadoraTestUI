Funcionalidade: Calculadora
	Testar a calculadora do windows como exemplo

Cenario: Calculadora
Dado Que a calculadora esteja aberta
Quando Informar um numero <Numero1>
E Escolher o operador <Operador>
E Informar o segundo numero <Numero2>
E Concluir o calculo
Então O resultado deve ser <Resultado>
Então Fechar calcular

Exemplos:
| Numero1 | Numero2 | Operador | Resultado |
| 2       | 2       | *        | 4         |
| 3       | 2       | -        | 1         |
| 2       | 3       | +        | 5         |
| 5       | 2       | *        | 10        |
| 4       | 2       | /        | 2         |

