using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;

namespace Niiives {
	public class PlayerSearcher : MonoBehaviour, IPlayerSearcher {

		private List<Enemy> targetList = new List<Enemy>();
		private Subject<GameObject> onGetTargetSubject = new Subject<GameObject>();
		private GameObject prevTarget = null;

		public IObservable<GameObject> OnGetTargetObservable {
			get { return onGetTargetSubject.AsObservable(); }
		}


		void Start() {
			var spereCol = gameObject.GetComponentInChildren<SphereCollider>();
			var player = GetComponent<Player>();
			spereCol.radius = player.targetingDistance;

			//初期値を流し込む
			onGetTargetSubject.OnNext(prevTarget);

			this.UpdateAsObservable()
				.Subscribe(_ => {
					var target = targetList.Where(x => Vector3.Angle(transform.forward, x.transform.position - transform.position) < 15f)
											   .OrderBy(x => Vector3.Distance(x.transform.position, transform.position))
											   .FirstOrDefault();

					if (target) {
						if (target.transform.gameObject != prevTarget) {
							prevTarget = target.transform.gameObject;
							onGetTargetSubject.OnNext(prevTarget);
						}
					} else if (prevTarget != null) {
						prevTarget = null;
						onGetTargetSubject.OnNext(prevTarget);
					}
				});

			EnemyManager.Instance.OnDestroyedEnemyObservable
						.Select(x => x.GetComponent<Enemy>())
						.Where(x => x != null)
						.Subscribe(x => targetList.Remove(x));

			this.OnTriggerEnterAsObservable()
				.Select(x => x.transform.parent.gameObject.GetComponent<Enemy>())
				.Where(x => x != null)
				.Subscribe(x => targetList.Add(x));

			this.OnTriggerExitAsObservable()
				.Select(x => x.transform.parent.gameObject.GetComponent<Enemy>())
				.Where(x => x != null)
				.Subscribe(x => targetList.Remove(x));
		}

	}
}
