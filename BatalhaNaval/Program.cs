char[,] meuCampo = new char[10, 10];
char[,] campoComputador = new char[10, 10];
Random aleatorio = new Random();

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        meuCampo[i, j] = '~';
        campoComputador[i, j] = '~';
    }
}

Console.WriteLine("BATALHA NAVAL");
for (int tamanho = 2; tamanho <= 4; tamanho++)
{
    bool navioPosicionado = false;

    while (!navioPosicionado)
    {
        Console.WriteLine("\nSeu campo:");
        Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 10; j++)
            {
                Console.Write(meuCampo[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nNavio de tamanho " + tamanho);
        Console.Write("Horizontal (H) ou Vertical (V)? ");
        string direcao = Console.ReadLine().ToUpper();
        Console.Write("Linha onde o navio começa: ");
        int linha = int.Parse(Console.ReadLine());
        Console.Write("Coluna onde o navio começa: ");
        int coluna = int.Parse(Console.ReadLine());

        bool posicaoValida = true;

        if (linha < 0 || linha > 9 || coluna < 0 || coluna > 9)
        {
            posicaoValida = false;
        }
        else if (direcao == "H")
        {
            if (coluna + tamanho > 10)
            {
                posicaoValida = false;
            }
            else
            {
                for (int k = 0; k < tamanho; k++)
                {
                    if (meuCampo[linha, coluna + k] != '~')
                    {
                        posicaoValida = false;
                    }
                }
            }
        }
        else if (direcao == "V")
        {
            if (linha + tamanho > 10)
            {
                posicaoValida = false;
            }
            else
            {
                for (int k = 0; k < tamanho; k++)
                {
                    if (meuCampo[linha + k, coluna] != '~')
                    {
                        posicaoValida = false;
                    }
                }
            }
        }
        else
        {
            posicaoValida = false;
        }

        if (posicaoValida)
        {
            for (int k = 0; k < tamanho; k++)
            {
                if (direcao == "H")
                {
                    meuCampo[linha, coluna + k] = 'N';
                }
                else
                {
                    meuCampo[linha + k, coluna] = 'N';
                }
            }
            navioPosicionado = true;
        }
        else
        {
            Console.WriteLine("Posição inválida, tente outra!");
        }
    }
}
for (int tamanho = 2; tamanho <= 4; tamanho++)
{
    bool navioPosicionado = false;

    while (!navioPosicionado)
    {
        int linha = aleatorio.Next(0, 10);
        int coluna = aleatorio.Next(0, 10);
        int sorteio = aleatorio.Next(0, 2);
        bool posicaoValida = true;

        if (sorteio == 0)
        {
            if (coluna + tamanho > 10)
            {
                posicaoValida = false;
            }
            else
            {
                for (int k = 0; k < tamanho; k++)
                {
                    if (campoComputador[linha, coluna + k] != '~')
                    {
                        posicaoValida = false;
                    }
                }
            }
        }
        else
        {
            if (linha + tamanho > 10)
            {
                posicaoValida = false;
            }
            else
            {
                for (int k = 0; k < tamanho; k++)
                {
                    if (campoComputador[linha + k, coluna] != '~')
                    {
                        posicaoValida = false;
                    }
                }
            }
        }

        if (posicaoValida)
        {
            for (int k = 0; k < tamanho; k++)
            {
                if (sorteio == 0)
                {
                    campoComputador[linha, coluna + k] = 'N';
                }
                else
                {
                    campoComputador[linha + k, coluna] = 'N';
                }
            }
            navioPosicionado = true;
        }
    }
}

Console.WriteLine("\nNavios posicionados! Aperte ENTER para começar.");
Console.ReadLine();
Console.Clear();

bool fimDeJogo = false;

while (!fimDeJogo)
{
    Console.WriteLine("SUA VEZ");

    Console.WriteLine("\nSeu campo:");
    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
    for (int i = 0; i < 10; i++)
    {
        Console.Write(i + " ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write(meuCampo[i, j] + " ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("\nCampo do computador:");
    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
    for (int i = 0; i < 10; i++)
    {
        Console.Write(i + " ");
        for (int j = 0; j < 10; j++)
        {
            if (campoComputador[i, j] == 'N')
            {
                Console.Write("~ ");
            }
            else
            {
                Console.Write(campoComputador[i, j] + " ");
            }
        }
        Console.WriteLine();
    }
    bool jogadorAtacou = false;

    while (!jogadorAtacou)
    {
        Console.Write("\nLinha do ataque: ");
        int linhaAtaque = int.Parse(Console.ReadLine());
        Console.Write("Coluna do ataque: ");
        int colunaAtaque = int.Parse(Console.ReadLine());

        if (linhaAtaque < 0 || linhaAtaque > 9 || colunaAtaque < 0 || colunaAtaque > 9)
        {
            Console.WriteLine("Essa posição não existe!");
        }
        else if (campoComputador[linhaAtaque, colunaAtaque] == 'X' || campoComputador[linhaAtaque, colunaAtaque] == 'O')
        {
            Console.WriteLine("Você já atacou essa posição!");
        }
        else if (campoComputador[linhaAtaque, colunaAtaque] == 'N')
        {
            campoComputador[linhaAtaque, colunaAtaque] = 'X';
            Console.WriteLine("Acertou um navio!");
            jogadorAtacou = true;
        }
        else
        {
            campoComputador[linhaAtaque, colunaAtaque] = 'O';
            Console.WriteLine("Água!");
            jogadorAtacou = true;
        }
    }
    int naviosDoComputador = 0;
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (campoComputador[i, j] == 'N')
            {
                naviosDoComputador++;
            }
        }
    }

    if (naviosDoComputador == 0)
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

        bool computadorAtacou = false;

        while (!computadorAtacou)
        {
            int linhaAtaque = aleatorio.Next(0, 10);
            int colunaAtaque = aleatorio.Next(0, 10);

            if (meuCampo[linhaAtaque, colunaAtaque] != 'X' && meuCampo[linhaAtaque, colunaAtaque] != 'O')
            {
                Console.WriteLine("O computador atacou a linha " + linhaAtaque + " e a coluna " + colunaAtaque);

                if (meuCampo[linhaAtaque, colunaAtaque] == 'N')
                {
                    meuCampo[linhaAtaque, colunaAtaque] = 'X';
                    Console.WriteLine("Ele acertou um navio seu!");
                }
                else
                {
                    meuCampo[linhaAtaque, colunaAtaque] = 'O';
                    Console.WriteLine("Ele errou!");
                }
                computadorAtacou = true;
            }
        }
        int meusNavios = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (meuCampo[i, j] == 'N')
                {
                    meusNavios++;
                }
            }
        }

        if (meusNavios == 0)
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