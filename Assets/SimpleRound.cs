using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float round = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * round * Time.deltaTime, Space.World);

    }
}
