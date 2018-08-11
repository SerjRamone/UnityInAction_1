using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel; //объект сцены Reference Text, предназначенный для задания свойства text
    [SerializeField] private SettingsPopup settingsPopup;

    public void Start()
    {
        settingsPopup.Close(); //закрываем окно при старте
    }

    void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

    public void OnOpenSettings() //метод, вызываемый кнопкой настроек
    {
        settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
