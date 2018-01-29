using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niiives {
	public class PlayerShotLevel1 : MonoBehaviour, IPlayerShot {

		private GameObject bullet1;
		private const float shotInterval = 0.08f;
		private float shotTimer;

		public void Shot() {
			shotTimer += Time.deltaTime;
			if (shotTimer > shotInterval) {
				shotTimer = 0;
				var bulletObj = Instantiate(bullet1, transform.position, Quaternion.identity) as GameObject;
				var bullet = bulletObj.GetComponent<Bullet>();
				bullet.bulletType = Const.BulletType.PlayerBullet;
				Vector3 shotPos = transform.position;
				bullet.xMove = (timer) => { return shotPos.x + 3 * Mathf.Sin(timer * 4); };
				bullet.yMove = (timer) => { return shotPos.y + 3 * Mathf.Cos(timer * 4); };
				bullet.zMove = (timer) => { return shotPos.z + timer * 8; };
			}
		}

		private void Awake() {
			bullet1 = Resources.Load("Bullets/Bullet1") as GameObject;
		}
	}


}