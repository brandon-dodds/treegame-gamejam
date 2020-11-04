using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public Player player;
    public float rate_of_ice_loss = 3f;
    public int ammount_of_ice_loss = 1;
    public bool out_of_ice = false;
    public Growth_bar growth_bar;
    public changesprite Changesprite;

    public float growth_rate = 0.5f;
    // ammount of progress to the next tree level every second
    public int tree_level = 0;
    public float time_per_growth_tick = 2f;
    public float max_growth_rate = 50f;
    public float current_growth = 10f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decrease_ice", 0f, rate_of_ice_loss);
        // reduces stored ice by x every y seconds

        
        InvokeRepeating("increase_growth", 0f, time_per_growth_tick);
        // this increases the growth meter by (growth rate) ever x seconds
       

    }

    // Update is called once per frame
    void Update()
    {
        calculate_growth_rate();

        if (current_growth > max_growth_rate)
        //once the growth bar has capped out tree level is increased
        {
            tree_level += 1;

            //every value is increased by 100%
            rate_of_ice_loss *= 2;
            max_growth_rate *= 2;
            time_per_growth_tick *= 2;
            ammount_of_ice_loss *= 2;

            //growth bar updated
            growth_bar.Set_max_growth(max_growth_rate);


            //restart the ticking changes with new values
            change_tree_level();

        }
        if (current_growth < 0)
        //once the growth bar has bottomed out tree level is decreased
        {
            tree_level -= 1;

            //every value is reduced by 50%
            rate_of_ice_loss /= 2;
            max_growth_rate /= 2;
            time_per_growth_tick /= 2;
            ammount_of_ice_loss /= 2;

            //growth bar updated
            growth_bar.Set_max_growth(max_growth_rate);


            //restart the ticking changes with new values
            change_tree_level();
            transform.localScale += new Vector3(10f, 10f, 0f);


        }

        void calculate_growth_rate()
            // percentage of ice storage filled
        {
            float ice = player.ice;
            float max_ice = player.max_ice;

            growth_rate = (ice) / (max_ice);
            

        }
        void change_tree_level()
        // call after the (rate_of_ice) and (time_per_growth) have been changes
        {
            CancelInvoke();
            // stops the previus ice and growth functions

            InvokeRepeating("ice_loss", 0f, rate_of_ice_loss);
            // reduces stored ice by x every y seconds

            InvokeRepeating("increase_growth", 0f, time_per_growth_tick);
            // this increases the growth meter by (growth rate) ever x seconds

            Changesprite.ChangeSprite(tree_level);
            transform.localScale -= new Vector3(10f, 10f, 0f);
        }
    }
    void increase_growth()
    {
        growth_bar.Change_growth(current_growth += growth_rate);
    }
    void decrease_ice()
    {
        player.ice += -(ammount_of_ice_loss);
    }
}
