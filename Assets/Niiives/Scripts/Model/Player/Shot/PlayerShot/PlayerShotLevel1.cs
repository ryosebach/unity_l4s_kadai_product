using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Niiives {
	public class PlayerShotLevel1 : MonoBehaviour, IPlayerShot {

		private GameObject bullet1;
		private const float shotInterval = 0.08f;
		private float shotTimer;
		private IPlayerAim iplayerAim;
		[SerializeField] private Transform muzzleTrans;

		public void Shot() {
			shotTimer += Time.deltaTime;
			if (shotTimer > shotInterval) {
				iplayerAim.OnAimedTargetObservable
						  .Subscribe(x => {
							  shotTimer = 0;
							  var bulletObj = Instantiate(bullet1, muzzleTrans.position, Quaternion.identity) as GameObject;
							  var bullet = bulletObj.GetComponent<Bullet>();
							  bullet.bulletType = Const.BulletType.PlayerBullet;
							  bullet.DamegeVal = 1.5f;
							  Vector3 shotPos = transform.position;
							  Vector3 shotDir;
							  if (x) {
								  shotDir = (x.transform.position - shotPos).normalized;
							  } else {
								  shotDir = transform.forward;
							  }
							  bullet.xMove = (timer) => { return shotPos.x + shotDir.x * timer * 300; };
							  bullet.yMove = (timer) => { return shotPos.y + shotDir.y * timer * 300; };
							  bullet.zMove = (timer) => { return shotPos.z + shotDir.z * timer * 300; };

						  });
			}
		}

		private void Awake() {
			bullet1 = Resources.Load("Bullets/Bullet1") as GameObject;
			iplayerAim = GetComponent<IPlayerAim>();
		}
	}


}