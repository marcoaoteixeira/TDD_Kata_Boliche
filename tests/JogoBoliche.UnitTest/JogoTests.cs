using JogoBoliche.Core;
using NUnit.Framework;

namespace JogoBoliche.UnitTest {
	[TestFixture]
	public class JogoTests {
		private Jogo _jogo;

		[SetUp]
		public void SetUp() {
			_jogo = new Jogo();
		}

		[TearDown]
		public void TearDown() {
			_jogo = null;
		}

		private void ExecutarArremessos(int vezes, int pinos) {
			for (int arremesso = 0; arremesso < vezes; arremesso++) {
				_jogo.Arremessar(pinos);
			}
		}

		private void ArremessarSpare() {
			_jogo.Arremessar(5);
			_jogo.Arremessar(5);
		}

		[Test]
		public void Jogadas_Na_Canaleta() {
			// arrange
			// Feito pelo método SetUp

			// act
			ExecutarArremessos(20, 0);

			// assert
			Assert.AreEqual(0, _jogo.Pontuacao());
		}

		[Test]
		public void Todos_Arremessos_Apenas_Um_Pino() {
			// arrange
			// Feito pelo método SetUp

			// act
			ExecutarArremessos(20, 1);

			// assert
			Assert.AreEqual(20, _jogo.Pontuacao());
		}

		[Test]
		public void Alcancando_Um_Spare() {
			// arrange
			// Feito pelo método SetUp

			// act
			ArremessarSpare();
			_jogo.Arremessar(3);
			ExecutarArremessos(17, 0); // Todos os próximos arremessos foram na canaleta. =(

			// assert
			Assert.AreEqual(16, _jogo.Pontuacao());
		}

		[Test]
		public void Alcancando_Um_Strike() {
			// arrange
			// Feito pelo método SetUp

			// act
			_jogo.Arremessar(10);
			_jogo.Arremessar(3);
			_jogo.Arremessar(4);
			ExecutarArremessos(16, 0); // Todos os próximos arremessos foram na canaleta. =(

			// Frame 1 (Strike): 10 + 3 + 4 (17)
			// Frame 2:1 (3): 3
			// Frame 2:2 (4): 4
			// Total: 24

			// assert
			Assert.AreEqual(24, _jogo.Pontuacao());
		}

		[Test]
		public void Jogo_Perfeito() {
			// arrange
			// Feito pelo método SetUp

			// act
			ExecutarArremessos(21, 10); // Todos os pinos acertados em todos os arremessos! =DD

			// Frame 1 (Strike):  10 + Frame2 + Frame3 = 30
			// Frame 2 (Strike):  10 + Frame3 + Frame4 = 30
			// Frame 3 (Strike):  10 + Frame4 + Frame5 = 30
			// Frame 4 (Strike):  10 + Frame5 + Frame6 = 30
			// Frame 5 (Strike):  10 + Frame6 + Frame7 = 30
			// Frame 6 (Strike):  10 + Frame7 + Frame8 = 30
			// Frame 7 (Strike):  10 + Frame8 + Frame9 = 30
			// Frame 8 (Strike):  10 + Frame9 + Frame10:1 = 30
			// Frame 9 (Strike):  10 + Frame10:1 + Frame10:2 = 30
			// Frame 10 (Strike): Frame10:1 + Frame10:2 + Frame10:3 = 30
			// Total: 300 pontos!

			// assert
			Assert.AreEqual(300, _jogo.Pontuacao());
		}
	}
}