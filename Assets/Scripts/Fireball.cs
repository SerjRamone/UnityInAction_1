using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1; 
    	
	void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}

    //вызывается когда с триггером сталкивается другой объект
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        //проверяем, является ли другой объект Игроком
        if (player != null)
        {
            Debug.Log("Player hit");
        }
        Destroy(this.gameObject);
    }
}
