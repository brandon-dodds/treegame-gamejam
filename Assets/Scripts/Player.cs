using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int max_02 = 60;
    public int max_ice = 100;
    public int max_wood = 100;
    public int current_02;
    public int ice;
    public int carried_ice = 0;
    public int max_carried_ice = 20;
    public int wood;
    public int ice_value = 10;

    public bool full_of_carried_ice = false;



    public Ox_bar ox_Bar;
    public Wood_bar wood_Bar;
    public Ice_bar ice_Bar;
    public Ice_carried_bar ice_carried_bar;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("lose_02", 0f, 1f);
        // deplets 02 every second
        current_02 = max_02;
        ox_Bar.Set_max_02(max_02);
        wood_Bar.Set_max_wood(max_wood);
        ice_Bar.Set_max_ice(max_ice);
    }

    // Update is called once per frame
    void Update()
    {
       
        
        wood_Bar.Set_wood(wood);
        ice_Bar.Set_ice(ice);
        ice_carried_bar.Set_ice_carried(carried_ice);
        is_ice_full();

    }
    void lose_02()
    {
        if (transform.position.x < -19 || transform.position.x > 19)
            // loses 1 o2 every second while outside dome
        {
            current_02 -= 1;
            ox_Bar.Set_02(current_02);
        }
        else
        // sets 02 back to max while inside dome
        {
            current_02 = max_02;
            ox_Bar.Set_02(current_02);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ice") 
            // only picks up the ice while inv isnt full
        {
            if(full_of_carried_ice == false)
            {
                carried_ice += ice_value / 2 ;

                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.tag == "Bucket")
        {
            int temp = ice += carried_ice;
            if (temp > max_ice)
            {
                ice = max_ice;
                carried_ice = (temp - max_ice);
                //if the ammount being deposited is more than the max, onlky the ammount needed will be deposited
            }
            else
            {
                ice += (carried_ice / 2);
                carried_ice = 0;
            }

        }
    }
    public void Set_ice(int x)
    {
        ice = x; 
    }
    void is_ice_full()
    {
        if(carried_ice < max_carried_ice)
        {
            full_of_carried_ice = false;
        }
        else
        {
            full_of_carried_ice = true;
        }
    }


}
