using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Niiives {
	public class Player : SingletonMonoBehaviour<Player> {
		public FloatReactiveProperty moveSpeed = new FloatReactiveProperty();
		public FloatReactiveProperty rollSpeed = new FloatReactiveProperty();
		public FloatReactiveProperty pitchSpeed = new FloatReactiveProperty();

		public float targetingDistance = 600;
	}
}