using UnityEngine;
using UniRx;

namespace Niiives {
	public interface IPlayerSearcher {
		IObservable<GameObject> OnGetTargetObservable {
			get;
		}
	}
}