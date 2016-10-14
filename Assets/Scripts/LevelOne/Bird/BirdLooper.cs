using UnityEngine;

public class BirdLooper : MonoBehaviour
{
    private float delta;

    public void Start()
    {
        this.delta = 28.76f;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bird"))
        {
            var bird = collider.gameObject;
            var birdPosition = bird.transform.position;
            birdPosition.x += delta;
            bird.transform.position = birdPosition;
        }
    }
}
