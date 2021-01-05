using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildColl : MonoBehaviour
{

    public delegate void OnCollision();
    public static event OnCollision onCollision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided");
        //transform.parent.gameObject.SetActive(false);
        //onCollision();

        if (other.transform.tag == "Mask")
        {
            transform.parent.GetChild(1).gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(SheildTimer());

        }
    }

    IEnumerator SheildTimer()
    {
        yield return new WaitForSeconds(5);
        transform.parent.GetChild(1).gameObject.SetActive(false);
    }


}