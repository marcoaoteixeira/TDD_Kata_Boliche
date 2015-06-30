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
				_jogo.Arremesso(pinos);
			}
		}

		private void ArremessarSpare() {
			_jogo.Arremesso(5);
			_jogo.Arremesso(5);
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
			_jogo.Arremesso(3);
			ExecutarArremessos(17, 0); // Todos os próximos arremessos foram na canaleta. =(

			// assert
			Assert.AreEqual(16, _jogo.Pontuacao());
		}

		[Test]
		public void Alcancando_Um_Strike() {
			// arrange
			// Feito pelo método SetUp

			// act
			_jogo.Arremesso(10);
			_jogo.Arremesso(3);
			_jogo.Arremesso(4);
			ExecutarArremessos(16, 0); // Todos os próximos arremessos foram na canaleta. =(

			// Frame 1 (Strike): 10 + 3 + 4 (17)
			// Frame 2:1 (3): 3
			// Frame 2:2 (4): 4
			// Total: 24

			// assert
			Assert.AreEqual(24, _jogo.Pontuacao());
		}
	}
}