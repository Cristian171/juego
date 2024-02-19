using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Switch : MonoBehaviour
{
   public void scene_changer(string Scene_name)
   {
    SceneManager.LoadScene(Scene_name);

   }

}
