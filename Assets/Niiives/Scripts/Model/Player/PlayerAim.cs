using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;
using DG.Tweening;

namespace Niiives {
	public class PlayerAim : MonoBehaviour, IPlayerAim {

		private BehaviorSubject<GameObject> onAimedTargetSubject = new BehaviorSubject<GameObject>(null);
		public IObservable<GameObject> OnAimedTargetObservable {
			get { return onAimedTargetSubject.AsObservable(); }
		}

		[SerializeField]
		private Image reticle;
		private RectTransform reticleRectTrans;

		private Transform targetTrans;
		private float lockOnTimer;
		private bool isAimed;

		void Start() {
			var iplayerSearcher = GetComponent<IPlayerSearcher>();
			reticleRectTrans = reticle.GetComponent<RectTransform>();
			iplayerSearcher.OnGetTargetObservable
						   .Subscribe(targetObj => {
							   if (targetObj) {
								   targetTrans = targetObj.transform;
								   lockOnTimer = 0;
								   isAimed = false;
							   } else {
								   targetTrans = null;
								   reticleRectTrans.offsetMax = new Vector2(0, 120);
								   reticleRectTrans.offsetMin = Vector2.zero;
								   onAimedTargetSubject.OnNext(targetObj);
							   }
						   });

			this.UpdateAsObservable()
				.Where(_ => targetTrans != null)
				.Subscribe(_ => {
					lockOnTimer += Time.deltaTime;
					var rate = lockOnTimer / 0.7f;
					if (rate > 1 && !isAimed) {
						isAimed = true;
						onAimedTargetSubject.OnNext(targetTrans.gameObject);
					}
					var pos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTrans.position);
					Vector3 targetPos = new Vector3(pos.x, pos.y, 0);
					reticleRectTrans.position = Vector3.Lerp(reticleRectTrans.position, targetPos, rate);
				});
		}

	}
}
