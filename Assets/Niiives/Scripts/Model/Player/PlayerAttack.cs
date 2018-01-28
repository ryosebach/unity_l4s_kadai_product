using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Niiives {
	public class PlayerAttack : MonoBehaviour {
		void Start() {
			var input = GetComponent<IPlayerInput>();
			var shot = GetComponent<IPlayerShot>();
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Space)
				 .Subscribe(_ => shot.Shot());
		}
	}
}