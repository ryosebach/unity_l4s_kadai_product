using System;
using UnityEngine;

namespace Niiives {
	public interface IBullet {
		Const.BulletType GetBulletType();
		float DamegeVal { get; set; }
		GameObject bulletObj { get; }
	}
}