using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaTomaObjetos : MonoBehaviour


{
    public GameObject tomado;
    public bool isTaken;
    public bool estaElObjetoCerca;
    public Vector3 original_scale;

    Transform padre;
    private void Awake(){
        padre = GameObject.Find("Capsule").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
        estaElObjetoCerca = false;
    }

    // Update is called once per frame
    void Update()
    {
        
         //tomado = temporal;
            if(Input.GetKeyDown(KeyCode.P)) {
                if(!isTaken) {
                    isTaken = true;
                } else {
                    isTaken = false;
                }
            }
    }

    private void OnTriggerEnter(Collider other){
        GameObject temporal = other.gameObject;
        if(temporal.CompareTag("ObjetoTomable")) {
        estaElObjetoCerca = true; 
        }
        
    }


      private void OnTriggerStay(Collider other) {
        GameObject temporal = other.gameObject;
        if(estaElObjetoCerca) {
           
            
            if(Input.GetKeyDown(KeyCode.P)) {//si el obj tomable cerca del personaje
                if(isTaken) {//y presoono la tecla de tomar
                     tomado = temporal; //guardo la referencia
                    isTaken = true;//indico que se tomo
                    temporal.transform.SetParent(padre);
                    temporal.transform.position = transform.position;
                    temporal.transform.rotation = transform.rotation; //asocio el ojbjeto al personaje
                    original_scale = temporal.transform.localScale;
                    temporal.transform.localScale = transform.localScale;
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.isKinematic = true; //objeto se vuelve kinematico
                    rb.useGravity = false;
                 
                } else {
                    tomado = null;
                    temporal.transform.SetParent(null);

                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    temporal.transform.localScale = original_scale;
                    temporal.transform.localScale = original_scale;
//porque si guarde el original scale porque no se guardo, pregunta para mañana //se pasa por diferencia <-- respuesta
//pero como lo solucionas-
                }
            }
        }
       
        Debug.Log(other.gameObject.name);
    }

    
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("ObjetoTomable")) {
            tomado = null;
        }
        Debug.Log(other.gameObject.name);
    }
}

