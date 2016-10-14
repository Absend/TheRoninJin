using UnityEngine;

public class LevelOneCameraCtrl : MonoBehaviour
{
    public GameObject player;
    private float offsetX;

    void Start()
    {
        this.offsetX = this.transform.position.x - this.player.transform.position.x;
    }

    void Update()
    {
        var position = this.transform.position;
        position.x = this.player.transform.position.x + offsetX;
        this.transform.position = position;
    }
}
