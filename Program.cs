using System;

Console.Clear();

const int umaHr = 60;    
const int tolerancia = 5;
const int valEstac = 20;
double addLavagem;
double addValet;

Console.WriteLine(@"🏎️  Estacionamento Relampago Marquinhos 💨
🏎️  Seja bem vindo 💨");
Console.WriteLine("Vamos emitir o valor total do seu serviço, por favor preencha a ficha: \n");

Console.Write("Tamanho do veículo [P] ou [G]__________: ");
string tamVeiculo = Console.ReadLine()!.ToUpper();

if (tamVeiculo == "P")
{
    Console.Write("Tempo de permanência (em minutos)______: ");
    string tempoString = Console.ReadLine()!;
    int.TryParse(tempoString, out int tempoValEstac);

    if (tempoValEstac <= 0) //se digitar uma letra a var int converte pra 0
    // então seria redundante add opção de erro se o tryparse n converter
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Digite números válidos no campo [Tempo de permanência]");
        Console.ResetColor();
        Environment.Exit(-1);
    }

    const int valAddEstacP = 10;
    const int valDiarEstacP = 50;
    const int lavagemP = 50;
    double totalValEstacP;
    int minutosExtras = tempoValEstac - umaHr; 

    double valTotalP;

    if (tempoValEstac >= 1 && tempoValEstac <= umaHr*12)
    {
        if (tempoValEstac < umaHr)
        {
            totalValEstacP = valEstac;
        }
        else if (tempoValEstac >= 5 * umaHr) // 5 horas = diária, porém a equação faz cobrar $60 se passar de 246 min
        {
            totalValEstacP = valDiarEstacP;
        }
        else
        {
            if (minutosExtras > tolerancia) //se o valor digitado, menos uma hr, for maior q 5
            {
                int horasExtras = (int)Math.Ceiling((minutosExtras - tolerancia) / 60.0);
                totalValEstacP = valEstac + (valAddEstacP * horasExtras);

                /*Entendendo a equação
 
                                     arredonda         
                                      pra cima      (val digitado - umaHr - 5)
                                         |                      |
                int horasExtras = (int)Math.Ceiling((minutosExtras - tolerancia) / 60.0);
                 
                  Val final       prim hr         10         result a cima
                totalValEstacP = valEstacP + (valAddEstacP * horasExtras); */
                
            }

            else //se for menor q 60 min
            {
                totalValEstacP = valEstac;
            }
        }
        
        Console.Write("Serviço de valet [S] ou [N]____________: ");
        string valet = Console.ReadLine()!.ToUpper();

        if(valet == "S")
        {
            addValet = 0.2 * totalValEstacP;
        }

        else //se não for S, ou, se digitar qualquer coisa sem ser S
        {
            valet = "N";
            addValet = 0; //precisa dizer o q acontece cm a var se n modificar no if pra poder add no final
        }


        Console.Write("Serviço de lavagem [S] ou [N]__________: ");
        string lavagem = Console.ReadLine()!.ToUpper();

        if(lavagem == "S")
        {
            addLavagem = lavagemP;
        }

        else 
        {
            lavagem = "N";
            addLavagem = 0;
        }

        valTotalP = totalValEstacP + addLavagem + addValet;

        Console.Write("Aqui está o total do seu serviço: "); Thread.Sleep(400);
        Console.Write("."); Thread.Sleep(400);
        Console.Write("."); Thread.Sleep(400);
        Console.WriteLine("."); Thread.Sleep(400);
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(" 🏎️         Ficha Estacionamento         💨 ");
        Console.ResetColor();

        Console.WriteLine($@"
Tamanho do veículo________________: {tamVeiculo}
tempo de permanencia______________: {tempoString} min
serviço de valet__________________: {valet}
serviço de lavagem________________: {lavagem}

estacionamento_______: {totalValEstacP:C}
Valet________________: {addValet:C}
Lavagem______________: {addLavagem:C}

Valor total__________: {valTotalP:C}
"); 

    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Tempo inválido no campo [Tempo de permanência]");
        Console.ResetColor();
        Environment.Exit(-1);
    }
}

else if (tamVeiculo == "G")
{
    Console.Write("Tempo de permanência (em minutos)______: ");
    string tempoString = Console.ReadLine()!;
    int.TryParse(tempoString, out int tempoValEstac);

    if (tempoValEstac <= 0) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Digite números válidos no campo [Tempo de permanência]");
        Console.ResetColor();
        Environment.Exit(-1);
    }
    //precisa declarar td de novo, o q n for declarado fora do if
    const int valAddEstacG = 20;
    const int valDiarEstacG = 80;
    double totalValEstacG;
    int minutosExtras = tempoValEstac - umaHr; 
    double valTotalG;
    const int lavagemG = 100;

    if (tempoValEstac >= 1 && tempoValEstac <= umaHr*12)
    {
        if (tempoValEstac < umaHr)
        {
            totalValEstacG = valEstac;
        }
        else if (tempoValEstac >= 5 * umaHr)
        {
            totalValEstacG = valDiarEstacG;
        }
        else
        {
            if (minutosExtras > tolerancia)
            {
                int horasExtras = (int)Math.Ceiling((minutosExtras - tolerancia) / 60.0);
                totalValEstacG = valEstac + (valAddEstacG * horasExtras);
            }

            else
            {
                totalValEstacG = valEstac;
            }
        }
        
        Console.Write("Serviço de valet [S] ou [N]____________: ");
        string valet = Console.ReadLine()!.ToUpper();

        if(valet == "S")
        {
            addValet = 0.2 * totalValEstacG;
        }

        else 
        {
            valet = "N";
            addValet = 0;
        }


        Console.Write("Serviço de lavagem [S] ou [N]__________: ");
        string lavagem = Console.ReadLine()!.ToUpper();

        if(lavagem == "S")
        {
            addLavagem = lavagemG;
        }

        else
        {
            lavagem = "N";
            addLavagem = 0;
        }

        valTotalG = totalValEstacG + addLavagem + addValet;

        Console.Write("Aqui está o total do seu serviço: "); Thread.Sleep(400);
        Console.Write("."); Thread.Sleep(400);
        Console.Write("."); Thread.Sleep(400);
        Console.WriteLine("."); Thread.Sleep(400);
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(" 🏎️         Ficha Estacionamento         💨 ");
        Console.ResetColor();

        Console.WriteLine($@"
Tamanho do veículo________________: {tamVeiculo}
tempo de permanencia______________: {tempoString} min
serviço de valet__________________: {valet}
serviço de lavagem________________: {lavagem}

estacionamento_______: {totalValEstacG:C}
Valet________________: {addValet:C}
Lavagem______________: {addLavagem:C}

Valor total__________: {valTotalG:C}
"); 

    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Tempo inválido no campo [Tempo de permanência]");
        Console.ResetColor();
        Environment.Exit(-1);
    }

}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Opção inválida, digite somente [P] ou [G]");
    Console.ResetColor();
}