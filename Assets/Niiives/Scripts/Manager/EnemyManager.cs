using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class EnemyManager : SingletonMonoBehaviour<EnemyManager> {
	List<GameObject> enemyObjList = new List<GameObject>();
	public IObservable<GameObject> OnDestroyedEnemyObservable {
		get { return destroyedEnemySubject.AsObservable(); }
	}
	private Subject<GameObject> destroyedEnemySubject = new Subject<GameObject>();

	private void Start() {
		enemyObjList = GameObject.FindGameObjectsWithTag("Enemy").ToList();
	}

	public void DestroyedEnemy(GameObject enemy) {
		enemyObjList.Remove(enemy);
		destroyedEnemySubject.OnNext(enemy);
	}

}
