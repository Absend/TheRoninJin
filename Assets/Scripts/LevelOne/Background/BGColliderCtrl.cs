using UnityEngine;

public class BGColliderCtrl : MonoBehaviour
{
    private float distanceBetweenBG;

    public void Start()
    {
        this.distanceBetweenBG = 14.38f;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Background") || collider.CompareTag("Fire"))
        {
            var background = collider.gameObject;
            var bgPosition = background.transform.position;
            bgPosition.x += 3 * this.distanceBetweenBG;
            background.transform.position = bgPosition;
        }
    }
}
