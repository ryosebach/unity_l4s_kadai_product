using UniRx;

namespace Niiives {

	public interface IPlayerInput {
		IObservable<Const.PlayerInput> OnMoveInputObserbable { get; }
	}
}