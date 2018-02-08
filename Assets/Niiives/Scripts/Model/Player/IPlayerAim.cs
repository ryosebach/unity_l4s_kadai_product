using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace Niiives {
	public interface IPlayerAim {
		IObservable<GameObject> OnAimedTargetObservable {
			get;

		}
	}
}