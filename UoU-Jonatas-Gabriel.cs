using System;

namespace projetoOO
{
	public abstract class Heroi
	{
        //atributos
		protected string nome;
		protected float ptsVida;
        protected int UTHeroi;
        protected Magia MagiaHeroi;
        protected Arma  ArmaHeroi;

        //construtor
		public Heroi (string nome, float ptsVida)
		{
			this.nome = nome;
			this.ptsVida = ptsVida;
            this.UTHeroi = 7;
		}

        //metodos abstratos
		public abstract void LancarMagia (Heroi alvo);
		
		public abstract void AtacarComArma (Heroi alvo);
        //metodos gerais vida
		public virtual void ReduzirVida() 
		{
			this.ptsVida -= 10;
		}

        public virtual void ReduzirVida(float dano)
        {
            this.ptsVida -= dano;
        }

		public virtual void AumentarVida() 
		{
			this.ptsVida += 10;
		}
        //metodos gerais UT
        public void AumentarUT(int valor)
        {
            this.UTHeroi += valor;
        }

        public void ReduzirUT(int valor)
        {
            this.UTHeroi -= valor;
        }
        //metodos get
		public string GetNome() 
		{
			return this.nome;
		}

		public float GetPtsVida() 
		{
			return this.ptsVida;
		}

        public int GetUT()
        {
            return this.UTHeroi;
        }
	}

	public class HeroiAlianca : Heroi
	{
		public HeroiAlianca (string nome, float ptsVida) : base (nome, ptsVida)
		{
            MagiaHeroi = new Magia("Força Rutilante", 4, 20);
            ArmaHeroi = new Arma("Espada", 12, 10);
		}

		public override void LancarMagia(Heroi alvo)
        {
            if (UTHeroi >= MagiaHeroi.GetCustoUT())
            {
                ReduzirUT(MagiaHeroi.GetCustoUT());
                float dano = MagiaHeroi.Lancar();
                alvo.ReduzirVida(dano);
                Console.WriteLine(nome + " lançou " + MagiaHeroi.GetNome() + " em " + alvo.GetNome() + " causando " + dano + " pontos de dano!");
            }
            else
            {
                Console.WriteLine(nome + " não tem UT suficiente para lançar magia!");
            }
        }

		public override void AtacarComArma(Heroi alvo) 
		{
			if (UTHeroi >= ArmaHeroi.GetCustoUT())
            {
                ReduzirUT(ArmaHeroi.GetCustoUT());
                float dano = ArmaHeroi.Atacar();
                alvo.ReduzirVida(dano);
                Console.WriteLine(nome + " atacou " + alvo.GetNome() + " com " + ArmaHeroi.GetNome() + " causando " + dano + " pontos de dano!");
            }
            else
            {
                Console.WriteLine(nome + " não tem UT suficiente para atacar com " + ArmaHeroi.GetNome() + "!");
            }
		}

		public override void AumentarVida()
		{
			this.ptsVida += 15;
		}
	}

	public class HeroiHorda : Heroi
	{
		public HeroiHorda (string nome, float ptsVida) : base (nome, ptsVida)
		{
            MagiaHeroi = new Magia("Caminho de Chamas", 6, 30);
            ArmaHeroi = new Arma("Machado", 14, 20);
		}

		public override void LancarMagia(Heroi alvo)
        {
            if (UTHeroi >= MagiaHeroi.GetCustoUT())
            {
                ReduzirUT(MagiaHeroi.GetCustoUT());
                float dano = MagiaHeroi.Lancar();
                alvo.ReduzirVida(dano);
                Console.WriteLine(nome + " lançou " + MagiaHeroi.GetNome() + " em " + alvo.GetNome() + " causando " + dano + " pontos de dano!");
            }
            else
            {
                Console.WriteLine(nome + " não tem UT suficiente para lançar magia!");
            }
        }

		public override void AtacarComArma(Heroi alvo) 
		{
			if (UTHeroi >= ArmaHeroi.GetCustoUT())
            {
                ReduzirUT(ArmaHeroi.GetCustoUT());
                float dano = ArmaHeroi.Atacar();
                alvo.ReduzirVida(dano);
                Console.WriteLine(nome + " atacou " + alvo.GetNome() + " com " + ArmaHeroi.GetNome() + " causando " + dano + " pontos de dano!");
            }
            else
            {
                Console.WriteLine(nome + " não tem UT suficiente para atacar com " + ArmaHeroi.GetNome() + "!");
            }
		}

		public override void ReduzirVida()
        {
            this.ptsVida -= 15;
        }
	}

	public class Magia
	{
        //atributos
		protected string nome;
		protected int custoUT;
        protected float dano;

        //construtor
		public Magia (string nome, int custoUT, float dano)
		{
			this.nome = nome;
			this.custoUT = custoUT;
            this.dano = dano;
		}

        //metodos gerais
        public float Lancar()
        {
            return this.dano;
        }
         //metodos get
        public string GetNome()
        {
            return this.nome;
        }

        public int GetCustoUT()
        {
            return this.custoUT;
        }
	}

	public class Arma
	{
        //atributos
		protected string nome;
		protected int custoUT;
        protected float dano;

        //construtor
		public Arma (string nome, int custoUT, float dano)
		{
			this.nome = nome;
			this.custoUT = custoUT;
            this.dano = dano;
		}

        //metodos gerais
        public float Atacar()
        {
            return this.dano;
        }
         //metodos get
        public string GetNome()
        {
            return this.nome;
        }

        public int GetCustoUT()
        {
            return this.custoUT;
        }
	}


// Trabalho de Jonatas Gouveia e Gabriel Nascimento
// Jogos Digitais - Introdução a programação - 1 Semestre
//
	public class UoU
	{
		public static void Main ()
		{
			
            int running = 0;
            
            Heroi horda = new HeroiHorda("Gabriel", 80);
            Heroi alianca = new HeroiAlianca("Jonatas", 80);

            do {
                //Heroi da Alianca
                alianca.AumentarUT(10);
                    Console.WriteLine("\n--- Ataque da Aliança ---");
                    Console.WriteLine(alianca.GetNome() + " possui " + alianca.GetUT() + " UTs.");

                    Console.WriteLine("Digite M para Magia ou A para Arma...");
                    string ataque = Console.ReadLine();

                    if (ataque.Equals("M"))
                    {
                        alianca.LancarMagia(horda);
                    }
                    else if (ataque.Equals("A"))
                    {
                        alianca.AtacarComArma(horda);
                    }

                    Console.WriteLine(horda.GetNome() + " ficou com " + horda.GetPtsVida() + " pontos de vida.");

                    
                    if (horda.GetPtsVida() <= 0)
                    {
                        running = 1;
                        Console.WriteLine("\n" + alianca.GetNome() + " venceu com " + alianca.GetPtsVida() + " pontos de vida restantes!");
                        Console.WriteLine("Game Over!");
                        break;
                    }

                //Heroi da Horda
                horda.AumentarUT(10);
                Console.WriteLine("\n--- Ataque da Horda ---");
                Console.WriteLine(horda.GetNome() + " possui " + horda.GetUT() + " UTs.");

                Console.WriteLine("Digite M para Magia ou A para Arma...");
                ataque = Console.ReadLine();

                if (ataque.Equals("M"))
                {
                    horda.LancarMagia(alianca);
                }
                else if (ataque.Equals("A"))
                {
                    horda.AtacarComArma(alianca);
                }

                Console.WriteLine(alianca.GetNome() + " ficou com " + alianca.GetPtsVida() + " pontos de vida.");

                if (alianca.GetPtsVida() <= 0)
                {
                    running = 1;
                    Console.WriteLine("\n" + horda.GetNome() + " venceu com " + horda.GetPtsVida() + " pontos de vida restantes!");
                    Console.WriteLine("Game Over!");
                    break;
                }
            } while (running == 0);
		}
	}
}