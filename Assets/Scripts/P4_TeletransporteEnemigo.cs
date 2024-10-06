using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_TeletransporteEnemigo : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] GameObject enemigo;
    [SerializeField] Transform posicionSpawn;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            enemigo.transform.position = posicionSpawn.position;
        }
    }
}
