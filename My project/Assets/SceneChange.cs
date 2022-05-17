using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float countTime = 0f;
    public string scene;

    // Update is called once per frame
    void Update()
    {
        CountTime();
        ToBreak();
    }

    void CountTime()
    {
        countTime += Time.deltaTime;
        if(countTime > 30.0f)
        {
            SceneManager.LoadScene(scene);
        }
    }

    void ToBreak()
    {
        if(Input.GetMouseButtonDown(0))
        {
            countTime = 0f;
        }
    }
}
