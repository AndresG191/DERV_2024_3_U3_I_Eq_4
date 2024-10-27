using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorUI : MonoBehaviour
{
    // Start is called before the first frame update

    private ManejadorUI instancia;

    TextMeshProUGUI nombre_usuario;

    int escena_actual;
    bool usuario_cargado;

    private void Awake(){
        if(instancia !=null && instancia !=this){
            Destroy(gameObject);
        }
        else{
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        escena_actual = SceneManager.GetActiveScene().buildIndex;

        if(escena_actual ==3){// el indice 3 es la escena de inicio

        }else
        if(!usuario_cargado){
            string usuario = PlayerPrefs.GetString("usuario", "");
            Debug.Log(""+ usuario);
            usuario_cargado =!usuario_cargado;
        }
    }
    

    public void cambioEscena(int index){
        SceneManager.LoadScene(index);

       if(escena_actual == 3){
        nombre_usuario = GameObject.Find("Usu text").GetComponent<TextMeshProUGUI>();
        string usuario = nombre_usuario.text; // dato ingresado por el usuario
        PlayerPrefs.SetString("usuario,", usuario); //se guarda el valor del usuario
       }

    }
}
