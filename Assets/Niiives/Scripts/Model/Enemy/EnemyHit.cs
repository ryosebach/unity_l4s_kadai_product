using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Niiives {
	public class EnemyHit : MonoBehaviour {
		private void Start() {
			this.OnTriggerEnterAsObservable()
				.Do(_ => Debug.Log("hoge"))
				.Select(x => x.gameObject.GetComponent<IBullet>())
				.Where(x => x != null)
				.Subscribe(iBullet => {
					Debug.Log("hit");
					var iEnemy = GetComponent<IEnemy>();
					iEnemy.HP -= iBullet.DamegeVal;
					Destroy(iBullet.bulletObj);
				});
		}
	}
}