using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

namespace Niiives {
	public class Bullet : MonoBehaviour, IBullet {
		public Const.BulletType bulletType;

		public Func<float, float> xMove { get; set; }
		public Func<float, float> yMove { get; set; }
		public Func<float, float> zMove { get; set; }

		float timer;
		void Start() {
			this.UpdateAsObservable()
				.Where(_ => !GameManager.Instance.isPause)
				.Subscribe(_ => {
					timer += Time.deltaTime;
					transform.position = new Vector3(xMove(timer), yMove(timer), zMove(timer));
					if (timer > 5f)
						Destroy(this.gameObject);
				}).AddTo(this.gameObject);
		}

		public Const.BulletType GetBulletType() {
			return bulletType;
		}
	}
}
