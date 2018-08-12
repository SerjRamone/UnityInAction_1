using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //сериализованная переменная для связи с объектом-шаблоном (префабом)
    [SerializeField] private GameObject enemyPrefab;
    
    public const float baseSpeed = 3.0f; //базовая скорость, меняемая в соответствии с положением ползунка
    public float speed = 3.0f; 

    //для слежения за экземпляром врага в сцене
    private GameObject _enemy;

    public void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    public void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    //листенер для события SPEED_CHANGED
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    void Update()
    {
        //порождаем нового врага только если враги в сцене отсутствуют
        if (_enemy == null)
        {
            //копируем префаб
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.GetComponent<WanderingAI>().speed = speed;
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
		
	}
}
