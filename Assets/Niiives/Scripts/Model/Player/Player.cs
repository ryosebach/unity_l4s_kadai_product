using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Niiives {
	public class Player : SingletonMonoBehaviour<Player> {
		public FloatReactiveProperty moveSpeed = new FloatReactiveProperty();
	}
}
