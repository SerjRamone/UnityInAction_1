using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel; //объект сцены Reference Text, предназначенный для задания свойства text
    
	void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

    public void OnOpenSettings() //метод, вызываемый кнопкой настроек
    {
        Debug.Log("open settings");
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
