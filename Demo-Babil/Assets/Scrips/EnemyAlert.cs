using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    public Enemy _enemy;
    
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _enemy.FindTarget("Player");
            Destroy(this.gameObject);
        }
    }
}
