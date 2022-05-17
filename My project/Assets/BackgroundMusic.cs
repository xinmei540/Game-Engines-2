using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Updata()
    {

    }

    public static BackgroundMusic Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
