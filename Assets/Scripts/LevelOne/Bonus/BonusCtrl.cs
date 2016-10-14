using UnityEngine;

public class BonusCtrl : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = -1;
        velocity.y = 0;
        this.rb.velocity = velocity;
    }
}