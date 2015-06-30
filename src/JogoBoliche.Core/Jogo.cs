namespace JogoBoliche.Core {
	public class Jogo {
		private const int PontuacaoSpare = 10;
		private const int PontuacaoStrike = 10;

		private int[] _arremessos = new int[21]; // Todos os arremessos, e um possível 3º arremesso no 10º frame
		private int _arremessoAtual = 0;

		public void Arremesso(int pinos) {
			_arremessos[_arremessoAtual++] = pinos;
		}

		public int Pontuacao() {
			const int totalFrames = 10;
			var pontuacao = 0;
			var frameIndex = 0;

			for (var frame = 0; frame < totalFrames; frame++) {
				if (Strike(frameIndex)) {
					pontuacao += PontuacaoStrike + PontuacaoBonusStrike(frameIndex);
					frameIndex++;
				} else if (Spare(frameIndex)) {
					pontuacao += PontuacaoSpare + PontuacaoBonusSpare(frameIndex);
					frameIndex += 2;
				} else {
					pontuacao += SomarTotalPontuacaoFrame(frameIndex);
					frameIndex += 2;
				}
			}

			return pontuacao;
		}

		private bool Strike(int frameIndex) {
			return _arremessos[frameIndex] == 10;
		}

		private int PontuacaoBonusStrike(int frameIndex) {
			return _arremessos[frameIndex + 1] + _arremessos[frameIndex + 2];
		}

		private bool Spare(int frameIndex) {
			return ((_arremessos[frameIndex] + _arremessos[frameIndex + 1]) == 10);
		}

		private int PontuacaoBonusSpare(int frameIndex) {
			return _arremessos[frameIndex + 2];
		}

		private int SomarTotalPontuacaoFrame(int frameIndex) {
			return _arremessos[frameIndex] + _arremessos[frameIndex + 1];
		}


	}
}