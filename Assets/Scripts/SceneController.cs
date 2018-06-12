using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //сериализованная переменная для связи с объектом-шаблоном (префабом)
    [SerializeField] private GameObject enemyPrefab;

    //для слежения за экземпляром врага в сцене
    private GameObject _enemy;

	void Start()
    {
		
	}
	
	void Update()
    {
        //порождаем нового врага только если враги в сцене отсутствуют
        if (_enemy == null)
        {
            //копируем префаб
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
		
	}
}
