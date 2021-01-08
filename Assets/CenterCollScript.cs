using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollScript : MonoBehaviour
{
    public GameManager gm;
    private Transform previousPlatform;
    public string tag;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tag)
        {
            gm.ResetLevel();
        }
    }


}
