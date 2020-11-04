using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ice;
    public Transform spawner;
    public int max_nodes = 50;
    // Start is called before the first frame update
    void Start()
    {
        int pos_or_neg = 1;
        float[] array = new float[max_nodes + 1];
        for (int i = 0; i < (max_nodes + 1); i++)
        {
            array[i] = Random.Range(25, 400);
            pos_or_neg *= -1;
            // flips value so 5 nodes spaw on each side
            var pos = new Vector3((array[i] * pos_or_neg), spawner.position[1], -4.8f);
            Instantiate(ice, pos, spawner.rotation);
        }
 

    }
    // Update is called once per frame
    void Update()
    {
        var ice_nodes = GameObject.FindGameObjectsWithTag("Ice");
        
        {

        }
    }
}
