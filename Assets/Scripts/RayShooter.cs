using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

	void Start()
    {
        //доступ к другим компонентам, присоединённым к этому же объекту
        _camera = GetComponent<Camera>();
	}
	
	void Update()
    {
		if (Input.GetMouseButtonDown(0)) //реакция на нажатие кнопки мыши
        {
            //середина экрана - это половина его высоты и ширины
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            //создание в этой точке луча
            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //загружаем координаты точки в которую попал луч
                Debug.Log("Hit " + hit.point);
            }
        }
	}
}
