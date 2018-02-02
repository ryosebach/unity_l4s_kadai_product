using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityStandardAssets.Vehicles.Aeroplane;

namespace Niiives {
	public class PlayerMove : MonoBehaviour {

		void Start() {
			var input = GetComponent<IPlayerInput>();
			var controller = GetComponent<AeroplaneController>();
			print(controller);

			this.UpdateAsObservable()
				.Subscribe(_ => controller.Move(0, 0, 0, Player.Instance.moveSpeed.Value, false));
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Up)
				 .Subscribe(_ => {
					 controller.Move(0, Player.Instance.pitchSpeed.Value, 0, 0, false);
					 //transform.position += Vector3.up * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Right)
				 .Subscribe(_ => {
					 controller.Move(Player.Instance.rollSpeed.Value, 0, 0, 0, false);
					 //transform.position += Vector3.right * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Down)
				 .Subscribe(_ => {
					 controller.Move(0, -Player.Instance.pitchSpeed.Value, 0, 0, false);
					 //transform.position += Vector3.down * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
			input.OnMoveInputObserbable
				 .Where(_ => !GameManager.Instance.isPause)
				 .Where(x => x == Const.PlayerInput.Left)
				 .Subscribe(_ => {
					 controller.Move(-Player.Instance.rollSpeed.Value, 0, 0, 0, false);
					 //transform.position += Vector3.left * Time.deltaTime * Player.Instance.moveSpeed.Value;
				 });
		}
	}
}