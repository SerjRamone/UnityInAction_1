using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //структура данных enum будет сопостовлять имена с параметрами
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    };

    public RotationAxes axes = RotationAxes.MouseXAndY;

    //скорость вращения
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    //предельные углы поворота по вертикали
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    //угол поворота по вертикали
    private float _rotationX = 0;
    	
	void Update()
    {
		if (axes == RotationAxes.MouseX) //поворот в горизонтальной плоскости
        {
            //getAxis получает данные от мыши
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        } else if (axes == RotationAxes.MouseY) //поворот в вертикальной плоскости
        {
            //увеличиваем угол поворота в соответствии с перемещениями указателя мыши
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

            //фиксируем угол поворота в диапазоне, заданным мин и макс значениями
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            //сохраняем одинаковый угол поворота вокруг оси Y (т.е. вращение по горизонтальной плоскости отсутствует)
            float rotationY = transform.localEulerAngles.y;

            //создаём новый вектор из сохраненных значений поворота
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        } else //комбинированный поворот
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityHor;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            //приращение угла поворта через значение delta
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;

            //значение delta - это величина изменения угла поворта
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
	}

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) //проверяем, существует ли этот компонент
        {
            body.freezeRotation = true;
        }
    }
}
