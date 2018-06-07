using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    //переменная для ссылки на компонент CharacterController;
    private CharacterController _charController;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //hor и vert - дополнительные имена для сопоставления с клавиатурой
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //ограничим движение по диагонали той же скоростью, что и движение параллельно осям
        movement = Vector3.ClampMagnitude(movement, speed);
        //используем значение переменной gravity вместо нуля
        movement.y = gravity;

        movement *= Time.deltaTime;
        //преобразуем вектор движения от локальных к глобальным координатам
        movement = transform.TransformDirection(movement);
        //заставим этот вектор перемещать компонент CharacterController
        _charController.Move(movement);

        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
	}
}
