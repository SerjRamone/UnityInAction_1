using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel; //объект сцены Reference Text, предназначенный для задания свойства text
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;

    public void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); //подписываем метод на событие
    }

    public void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); //при уничтожении врага отписывает слушателя событий
    }

    public void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingsPopup.Close(); //закрываем окно при старте
    }

    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
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
