using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogroCondicion : MonoBehaviour
{

    void Start()
    {
        MMAchievementManager.UnlockAchievement("Portal");
    }
    /*private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisionamos tiene el tag deseado
        if (other.CompareTag("Portal"))
        {
            MMAchievementManager.UnlockAchievement("Portal");


        }
    }*/
}