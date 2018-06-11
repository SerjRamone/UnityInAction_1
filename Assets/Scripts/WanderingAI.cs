using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    //скорость движения и расстояния, с которого начинается реакция на препятствие
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

	void Update()
    {
        //непрерывно движемся вперёд  в каждом кадре, несмотря на повороты
        transform.Translate(0, 0, speed * Time.deltaTime);

        //луч находится в том же положении и нацеливается в том же направлении, что и персонаж
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //бросаем луч с описанной вокруг него окружностью
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                //поворот с наполовину случайным выбором нового анправления
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }

	}
}
