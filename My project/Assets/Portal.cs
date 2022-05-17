using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
