using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace Niiives {

	public interface IPlayerInput {
		IObservable<Const.PlayerInput> OnMoveInputObserbable { get; }
	}

}