using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float currentVelocity;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.currentVelocity = -1;
    }

    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = currentVelocity;
        velocity.y = 0;
        this.rb.velocity = velocity;

        currentVelocity += -0.0005f;
    }
}
