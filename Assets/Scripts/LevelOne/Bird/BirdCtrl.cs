using UnityEngine;
using System.Collections;

public class BirdCtrl : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = -2;
        velocity.y = 0;
        this.rb.velocity = velocity;
    }
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("BirdLooper"))
        {
            var looper = collider.gameObject;
            var looperPosition = looper.transform.position;
            looperPosition.x += 14.38f;
            looper.transform.position = looperPosition;
        }
    }
}
