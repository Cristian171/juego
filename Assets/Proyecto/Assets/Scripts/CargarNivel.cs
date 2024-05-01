using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarNivel : MonoBehaviour
{
    [SerializeField]
    private string escena;

    public void OnCambiarEscena()
    {
        if(escena != null)
        {
            MMSceneLoadingManager.LoadScene(escena);
        }
    }
}
