using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

    public GameObject ventanaActivar;

    /*private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que hizo contacto tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Activar la ventana
            ventanaActivar.SetActive(true);
        }

    }*/

    public void AbrirVentana(){
        if(ventanaActivar!=null){
            ventanaActivar.SetActive(true);
        }
    }

    }
