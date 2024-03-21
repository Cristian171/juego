using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emergente : MonoBehaviour
{


public GameObject popUp;

public void ClickEnBotonPulsar()
{
    Debug.Log("Se ha pulsado el boton.");
}

public void MostrarPopUp()
{
    popUp.SetActive(true);
}

public void OcultarPopUp()
{
    popUp.SetActive(false);
}
   

    }
