using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Niiives {
	public class Enemy : MonoBehaviour, IEnemy {
		private float hp = 10;
		public float HP {
			get { return hp; }
			set { hp = value; }
		}

		private void Start() {
			this.UpdateAsObservable()
				.Where(_ => HP <= 0)
				.Subscribe(_ => {
					Destroy(this.gameObject);
					EnemyManager.Instance.DestroyedEnemy(this.gameObject);
				}).AddTo(this.gameObject);
		}
	}
}
