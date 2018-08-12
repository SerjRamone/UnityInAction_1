using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

	void Start()
    {
        //доступ к другим компонентам, присоединённым к этому же объекту
        _camera = GetComponent<Camera>();

        //скрываем указатель мыши в центре экрана
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
	}
	
	void Update()
    {
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) //реакция на нажатие кнопки мыши
        {
            //середина экрана - это половина его высоты и ширины
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            //создание в этой точке луча
            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //получаем объект в который попал луч
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) //проверяем наличие у этого объекта компонента ReactiveTarget
                {
                    //вызов метода для мишени
                    target.ReactToHit();

                    Messenger.Broadcast(GameEvent.ENEMY_HIT); //кроме реакции на попадание - рассылаем сообщение
                }
                else
                {
                    //запуск корутина в ответ на попадание
                    StartCoroutine(SphereIndicator(hit.point));
                }                
            }
        }
	}

    //корутины пользуются функциями IEnumerator
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        //ключевое слово yield показывает корутину когда надо остановиться
        yield return new WaitForSeconds(1);

        //удаляем GameObject и очищаем память
        Destroy(sphere);
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        //отображает на экране символ
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
