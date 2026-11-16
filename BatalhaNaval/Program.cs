
char[,] meuCampo = new char[10, 10];
char[,] campoComputador = new char[10, 10];

Random aleatorio = new Random();

InicializarCampos(meuCampo, campoComputador);

Console.WriteLine("BATALHA NAVAL");

PosicionarNaviosJogador(meuCampo);
PosicionarNaviosComputador(campoComputador, aleatorio);

Console.WriteLine("\nNavios posicionados! Aperte ENTER para começar.");
Console.ReadLine();
Console.Clear();

bool fimDeJogo = false;

while (!fimDeJogo)
{
    Console.WriteLine("SUA VEZ");

    MostrarCampo(meuCampo);
    MostrarCampoComputador(campoComputador);

    JogadorAtacar(campoComputador);

    if (ContarNavios(campoComputador) == 0)
    {
        Console.WriteLine("\nParabéns, você venceu!");
        fimDeJogo = true;
    }
    else
    {
        Console.WriteLine("\nAperte ENTER para o computador jogar.");
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("VEZ DO COMPUTADOR");

        ComputadorAtacar(meuCampo, aleatorio);

        if (ContarNavios(meuCampo) == 0)
        {
            Console.WriteLine("\nO computador venceu!");
            fimDeJogo = true;
        }
        else
        {
            Console.WriteLine("\nAperte ENTER para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}


// MÉTODO PARA INICIALIZAR OS CAMPOS
void InicializarCampos(char[,] jogador, char[,] computador)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            jogador[i, j] = '~';
            computador[i, j] = '~';
        }
    }
}


// MÉTODO PARA MOSTRAR O CAMPO
void MostrarCampo(char[,] campo)
{
    Console.WriteLine("\nSeu campo:");
    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");

    for (int i = 0; i < 10; i++)
    {
        Console.Write(i + " ");

        for (int j = 0; j < 10; j++)
        {
            Console.Write(campo[i, j] + " ");
        }

        Console.WriteLine();
    }
}


// MÉTODO PARA MOSTRAR O CAMPO DO COMPUTADOR
void MostrarCampoComputador(char[,] campo)
{
    Console.WriteLine("\nCampo do computador:");
    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");

    for (int i = 0; i < 10; i++)
    {
        Console.Write(i + " ");

        for (int j = 0; j < 10; j++)
        {
            if (campo[i, j] == 'N')
            {
                Console.Write("~ ");
            }
            else
            {
                Console.Write(campo[i, j] + " ");
            }
        }

        Console.WriteLine();
    }
}


// MÉTODO PARA POSICIONAR NAVIOS DO JOGADOR
void PosicionarNaviosJogador(char[,] campo)
{
    for (int tamanho = 2; tamanho <= 4; tamanho++)
    {
        bool navioPosicionado = false;

        while (!navioPosicionado)
        {
            MostrarCampo(campo);

            Console.WriteLine("\nNavio de tamanho " + tamanho);

            Console.Write("Horizontal (H) ou Vertical (V)? ");
            string direcao = Console.ReadLine().ToUpper();

            Console.Write("Linha onde o navio começa: ");
            int linha = int.Parse(Console.ReadLine());

            Console.Write("Coluna onde o navio começa: ");
            int coluna = int.Parse(Console.ReadLine());

            if (VerificarPosicao(campo, linha, coluna, tamanho, direcao))
            {
                PosicionarNavio(campo, linha, coluna, tamanho, direcao);
                navioPosicionado = true;
            }
            else
            {
                Console.WriteLine("Posição inválida, tente outra!");
            }
        }
    }
}


// MÉTODO PARA POSICIONAR NAVIOS DO COMPUTADOR
void PosicionarNaviosComputador(char[,] campo, Random aleatorio)
{
    for (int tamanho = 2; tamanho <= 4; tamanho++)
    {
        bool navioPosicionado = false;

        while (!navioPosicionado)
        {
            int linha = aleatorio.Next(0, 10);
            int coluna = aleatorio.Next(0, 10);
            int sorteio = aleatorio.Next(0, 2);

            string direcao;

            if (sorteio == 0)
            {
                direcao = "H";
            }
            else
            {
                direcao = "V";
            }

            if (VerificarPosicao(campo, linha, coluna, tamanho, direcao))
            {
                PosicionarNavio(campo, linha, coluna, tamanho, direcao);
                navioPosicionado = true;
            }
        }
    }
}


// MÉTODO PARA VERIFICAR SE A POSIÇÃO É VÁLIDA
bool VerificarPosicao(char[,] campo, int linha, int coluna, int tamanho, string direcao)
{
    if (linha < 0 || linha > 9 || coluna < 0 || coluna > 9)
    {
        return false;
    }

    if (direcao == "H")
    {
        if (coluna + tamanho > 10)
        {
            return false;
        }

        for (int k = 0; k < tamanho; k++)
        {
            if (campo[linha, coluna + k] != '~')
            {
                return false;
            }
        }
    }
    else if (direcao == "V")
    {
        if (linha + tamanho > 10)
        {
            return false;
        }

        for (int k = 0; k < tamanho; k++)
        {
            if (campo[linha + k, coluna] != '~')
            {
                return false;
            }
        }
    }
    else
    {
        return false;
    }

    return true;
}


// MÉTODO PARA POSICIONAR UM NAVIO
void PosicionarNavio(char[,] campo, int linha, int coluna, int tamanho, string direcao)
{
    for (int k = 0; k < tamanho; k++)
    {
        if (direcao == "H")
        {
            campo[linha, coluna + k] = 'N';
        }
        else
        {
            campo[linha + k, coluna] = 'N';
        }
    }
}


// MÉTODO PARA O JOGADOR ATACAR
void JogadorAtacar(char[,] campo)
{
    bool jogadorAtacou = false;

    while (!jogadorAtacou)
    {
        Console.Write("\nLinha do ataque: ");
        int linha = int.Parse(Console.ReadLine());

        Console.Write("Coluna do ataque: ");
        int coluna = int.Parse(Console.ReadLine());

        if (linha < 0 || linha > 9 || coluna < 0 || coluna > 9)
        {
            Console.WriteLine("Essa posição não existe!");
        }
        else if (campo[linha, coluna] == 'X' || campo[linha, coluna] == 'O')
        {
            Console.WriteLine("Você já atacou essa posição!");
        }
        else if (campo[linha, coluna] == 'N')
        {
            campo[linha, coluna] = 'X';
            Console.WriteLine("Acertou um navio!");
            jogadorAtacou = true;
        }
        else
        {
            campo[linha, coluna] = 'O';
            Console.WriteLine("Água!");
            jogadorAtacou = true;
        }
    }
}


// MÉTODO PARA O COMPUTADOR ATACAR
void ComputadorAtacar(char[,] campo, Random aleatorio)
{
    bool computadorAtacou = false;

    while (!computadorAtacou)
    {
        int linha = aleatorio.Next(0, 10);
        int coluna = aleatorio.Next(0, 10);

        if (campo[linha, coluna] != 'X' && campo[linha, coluna] != 'O')
        {
            Console.WriteLine("O computador atacou a linha " + linha + " e a coluna " + coluna);

            if (campo[linha, coluna] == 'N')
            {
                campo[linha, coluna] = 'X';
                Console.WriteLine("Ele acertou um navio seu!");
            }
            else
            {
                campo[linha, coluna] = 'O';
                Console.WriteLine("Ele errou!");
            }

            computadorAtacou = true;
        }
    }
}


// MÉTODO PARA CONTAR OS NAVIOS RESTANTES
int ContarNavios(char[,] campo)
{
    int navios = 0;

    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (campo[i, j] == 'N')
            {
                navios++;
            }
        }
    }

    return navios;
}
