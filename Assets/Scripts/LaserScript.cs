using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float projectileSpeed = 5;
    Rigidbody2D rb;
    Vector3 mousePosition;
    public GameObject arm;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        mousePosition.z = 0;
        rb = GetComponent<Rigidbody2D>();
        arm = GameObject.Find("Arm");
        Vector3 subtractedVector = new Vector3(mousePosition.x - arm.transform.position.x, mousePosition.y - arm.transform.position.y, mousePosition.z - arm.transform.position.z);
        subtractedVector.Normalize();
        rb.AddForce(subtractedVector * projectileSpeed);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            Debug.Log(collision.gameObject);
            enemy.loseHealth();
            Destroy(gameObject);

        }
        else {
            Destroy(gameObject);
        }
    }
}
