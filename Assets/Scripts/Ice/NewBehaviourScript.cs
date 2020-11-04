using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Player player;

    private void OnCollisionEnter(Collision collision)
    {
        if (player.full_of_carried_ice == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                player.carried_ice += 10;
                Destroy(gameObject);
            }


        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
