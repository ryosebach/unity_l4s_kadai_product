using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Niiives {
	public class KeyBorardInput : MonoBehaviour, IPlayerInput {

		/// <summary>
		/// プレイヤーからの入力をObservableに流すためのSubject
		/// </summary>
		private Subject<Const.PlayerInput> onPlyaerInputSubject = new Subject<Const.PlayerInput>();

		/// <summary>
		/// 入力を流すためのObservable.
		/// IPlayerInputをGetComponentし，このObservableを監視することで動けるように
		/// </summary>
		/// <value>The on move input obserbable.</value>
		public IObservable<Const.PlayerInput> OnMoveInputObserbable {
			get { return onPlyaerInputSubject.AsObservable(); }
		}

		void Start() {
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
				.Select(_ => Const.PlayerInput.Down)
				.Subscribe(onPlyaerInputSubject)
				.AddTo(this.gameObject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
				.Select(_ => Const.PlayerInput.Right)
				.Subscribe(onPlyaerInputSubject)
				.AddTo(this.gameObject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
				.Select(_ => Const.PlayerInput.Left)
				.Subscribe(onPlyaerInputSubject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
				.Select(_ => Const.PlayerInput.Up)
				.Subscribe(onPlyaerInputSubject)
				.AddTo(this.gameObject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.Space))
				.Select(_ => Const.PlayerInput.Space)
				.Subscribe(onPlyaerInputSubject)
				.AddTo(this.gameObject);
		}
	}
}
