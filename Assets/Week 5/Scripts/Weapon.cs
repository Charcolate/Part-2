using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public float destroyTime = 5f;

    private Rigidbody2D rb;
    public GameObject axe;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -speed * Time.deltaTime;
        Destroy(axe, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
            collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
            Destroy(axe);
    }
}
