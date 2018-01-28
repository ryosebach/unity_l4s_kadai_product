using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Niiives {
	public class PlayerMove : MonoBehaviour {

		void Start() {
			var input = GetComponent<IPlayerInput>();

			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Up)
				 .Subscribe(_ => {
					 transform.position += Vector3.up * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Right)
				 .Subscribe(_ => {
					 transform.position += Vector3.right * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Down)
				 .Subscribe(_ => {
					 transform.position += Vector3.down * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Left)
				 .Subscribe(_ => {
					 transform.position += Vector3.left * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
		}
	}
}