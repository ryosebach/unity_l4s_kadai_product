﻿using System.Collections;
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
				.Where(_ => Input.GetKey(KeyCode.DownArrow))
				.Select(_ => Const.PlayerInput.Down)
				.Subscribe(onPlyaerInputSubject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.RightArrow))
				.Select(_ => Const.PlayerInput.Right)
				.Subscribe(onPlyaerInputSubject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.LeftArrow))
				.Select(_ => Const.PlayerInput.Left)
				.Subscribe(onPlyaerInputSubject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.UpArrow))
				.Select(_ => Const.PlayerInput.Up)
				.Subscribe(onPlyaerInputSubject);
			this.UpdateAsObservable()
				.Where(_ => Input.GetKey(KeyCode.Space))
				.Select(_ => Const.PlayerInput.Space)
				.Subscribe(onPlyaerInputSubject);
		}
	}
}
