using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    //вызывается сценарием стрельбы RayShooter
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        //проверка нужна т.к. он может и отсутствовать
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    //Опракидываем врага, ждём 1.5 секунды и уничтожаем его
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        //можно уничтожить и самого себя
        Destroy(this.gameObject);
    }
}
