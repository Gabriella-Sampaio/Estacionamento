Console.Clear();

const int umaHr = 60,
tolerancia = 5,
valEstac = 20;

double addLavagem,
addValet;

int valAddEstac = 0, //definir um valor caso if / else if não atribua
valDiarEstac = 0,
lavagem = 0;

double totalValEstac = 0; //valor (do estac) a ser exibido

Console.WriteLine(@"🏎️   Estacionamento Relampago Marquinhos  💨
        🏎️   Seja bem vindo  💨
");
Console.WriteLine("Vamos emitir o valor total do seu serviço,\npor favor preencha a ficha: \n");

Console.Write("Tamanho do veículo [P] ou [G]__________: ");
string tamVeiculo = Console.ReadLine()!.ToUpper().Trim();

if (tamVeiculo != "P" && tamVeiculo != "G")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Opção inválida, digite somente [P] ou [G]");
    Console.ResetColor();
    Environment.Exit(-1);
}


Console.Write("Tempo de permanência (em minutos)______: ");
string tempoString = Console.ReadLine()!.Trim();
int.TryParse(tempoString, out int tempoValEstac);

if(tempoValEstac <= 0)//se digitar uma letra a var int converte pra 0
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Digite números válidos no campo [Tempo de permanência]");
    Console.ResetColor();
    Environment.Exit(-1);
}

else if (tempoValEstac >= umaHr*12)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Não é possivel permanecer mais de 12h");
    Console.ResetColor();
    Environment.Exit(-1);
}


if (tamVeiculo == "P")
{
    valAddEstac = 10;
    valDiarEstac = 50;
    lavagem = 50;
}

else if (tamVeiculo == "G")
{
    valAddEstac = 20;
    valDiarEstac = 80;
    lavagem = 100;
}


int minutosExtras = tempoValEstac - umaHr;

if (minutosExtras < tolerancia || tempoValEstac <= 5)//se o valor digitado, menos uma hr, for menor q 5
{
    totalValEstac = valEstac;
}

int horasExtras = (int)Math.Ceiling((minutosExtras - tolerancia) / 60.0);
totalValEstac = valEstac + (valAddEstac * horasExtras);

/*Entendendo a equação
 
                     arredonda        
                      pra cima      (val digitado - umaHr - 5)
                         |                      |
int horasExtras = (int)Math.Ceiling((minutosExtras - tolerancia) / 60.0);
                 
  Val final       prim hr         10         result a cima
totalValEstacP = valEstacP + (valAddEstacP * horasExtras); */


if (tempoValEstac <= 5) // 5 horas = diária, porém a equação faz cobrar $60 se passar de 246 min
//    se n tivesse    |      o result de total seria $10 pq vai pra equação de qualquer jeito    
{
    totalValEstac = valEstac;
}

else if (tempoValEstac >= 186)
{
    totalValEstac = valDiarEstac;
}

else if (tempoValEstac >= umaHr*12)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Não é possivel permanecer mais de 12h");
    Console.ResetColor();
    Environment.Exit(-1);
}


Console.Write("Serviço de valet [S] ou [N]____________: ");
string valetOpc = Console.ReadLine()!.ToUpper();

if(valetOpc == "S")
{
    addValet = 0.2 * totalValEstac;
}

else //se não for S, ou, se digitar qualquer coisa sem ser S
{
    valetOpc = "N";
    addValet = 0; //precisa dizer o q acontece cm a var se n modificar no if pra poder add no final
}


Console.Write("Serviço de lavagem [S] ou [N]__________: ");
string lavagemOpc = Console.ReadLine()!.ToUpper();

if(lavagemOpc == "S")
{
    addLavagem = lavagem;
}

else 
{
    lavagemOpc = "N";
    addLavagem = 0;
}

double valTotal = totalValEstac + addLavagem + addValet;

Console.Write("Aqui está o total do seu serviço: "); Thread.Sleep(400);
Console.Write("."); Thread.Sleep(300);
Console.Write("."); Thread.Sleep(300);
Console.WriteLine("."); Thread.Sleep(800);
Console.Clear();

Console.WriteLine(" 🏎️      Ficha Estacionamento      💨 ");

Console.WriteLine($@"
Tamanho do veículo_______: {tamVeiculo}
tempo de permanencia_____: {tempoString} min
serviço de valet_________: {valetOpc}
serviço de lavagem_______: {lavagemOpc}

estacionamento_______: {totalValEstac:C}
Valet________________: {addValet:C}
Lavagem______________: {addLavagem:C}

Valor total__________: {valTotal:C}
");