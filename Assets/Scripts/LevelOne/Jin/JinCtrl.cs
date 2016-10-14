using UnityEngine;
using UnityEngine.SceneManagement;

public class JinCtrl : MonoBehaviour
{
    private AudioSource audioSource;

    private Animator animator;
    private Rigidbody2D rb;
    private PolygonCollider2D polCol;
    private CircleCollider2D circCol;

    private System.Random rand;
    private int bonusTranslation;
    private bool upHit;
    private bool downHit;

    public AudioClip backgroundSound;
    public AudioClip flyDied;
    public GUIStyle style;
    public GUIStyle styleHighScore;

    public bool upHitting;
    public bool downHitting;

    public int score;

    public int lives;

    //==========================

    public void Start()
    {
        this.audioSource = this.gameObject.GetComponent<AudioSource>();
        this.audioSource.enabled = false;

        this.animator = this.gameObject.GetComponent<Animator>();

        this.rb = this.gameObject.GetComponent<Rigidbody2D>();

        this.polCol = this.gameObject.GetComponent<PolygonCollider2D>();
        this.polCol.enabled = false;

        this.circCol = this.gameObject.GetComponent<CircleCollider2D>();
        this.circCol.enabled = false;

        this.rand = new System.Random();

        this.score = 0;

        this.lives = 3;

        this.bonusTranslation = 99;
    }

    //==========================

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.audioSource.clip = this.flyDied;
            this.upHit = true;
            this.upHitting = true;
            this.downHitting = false;
            this.polCol.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            this.audioSource.clip = this.flyDied;
            this.downHit = true;
            this.downHitting = true;
            this.upHitting = false;
            this.circCol.enabled = true;
        }
    }

    //==========================

    public void FixedUpdate()
    {
        this.JinStateChecking();

        this.SetVelocity();
    }

    private void JinStateChecking()
    {
        if (upHit)
        {
            this.circCol.enabled = false;
            this.upHit = false;
            this.animator.SetInteger("JinState", 1);
        }
        else
        {
            this.polCol.enabled = false;
            if (downHit)
            {
                this.downHit = false;
                this.animator.SetInteger("JinState", 2);
            }
            else
            {
                this.circCol.enabled = false;
                this.animator.SetInteger("JinState", 0);
            }
        }
    }

    private void SetVelocity()
    {
        var velocity = this.rb.velocity;
        velocity.x = 2;
        velocity.y = 0;
        this.rb.velocity = velocity;
    }

    //==========================

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bonus"))
        {
            this.Looper(collider, this.bonusTranslation);
            ++lives;
        }
        else if (collider.CompareTag("EnemyUp"))
        {
            this.Looper(collider, rand.Next(33, 77));
            if (upHitting)
            {
                this.audioSource.enabled = true;
                ++score;
                this.upHitting = false;
            }
            else
            {
                --lives;

                if (lives == 0)
                {
                    JinDie();
                }
            }
        }
        else if (collider.CompareTag("EnemyDown"))
        {
            this.Looper(collider, rand.Next(33, 77));
            if (downHitting)
            {
                this.audioSource.enabled = true;
                ++score;
                this.downHitting = false;
            }
            else
            {
                --lives;

                if (lives == 0)
                {
                    JinDie();
                }
            }
        }
    }

    //==========================

    private void JinDie()
    {
        SetHighScore(this.score);
        SceneManager.UnloadScene("LevelOne");
        SceneManager.LoadScene("Logo");
    }

    //==========================

    private void Looper(Collider2D collider, int distanceTranslate)
    {
        var looper = collider.gameObject;
        var looperPosition = looper.transform.position;
        looperPosition.x += distanceTranslate;
        looper.transform.position = looperPosition;
    }

    //==========================

    public void OnGUI()
    {
        this.DisplayScore();

        this.DisplayLives();

        this.DisplayHighScore();
    }

    private void DisplayScore()
    {
        var r = new Rect(1, 1, 60, 30);
        GUI.Label(r, "Score: ", this.style);

        var rec = new Rect(55, 5, 33, 20);
        GUI.TextField(rec, this.score.ToString());
    }

    private void DisplayLives()
    {
        const int MaxLives = 7;

        var l = this.lives;

        if (l > MaxLives)
        {
            l = MaxLives;
        }

        for (int i = 0; i < l; i++)
        {
            var rec = new Rect(Screen.width / 3 - 20 + (i * 20), 5, 20, 20);

            GUI.Button(rec, string.Empty);
        }
    }

    private static void SetHighScore(int score)
    {
        var currentHighScore = PlayerPrefs.GetInt("HighScore");

        if (currentHighScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void DisplayHighScore()
    {
        var score = PlayerPrefs.GetInt("HighScore");

        var r = new Rect(Screen.width - 120, 5, 100, 30);

        GUI.Label(r, "High score: " + score, this.styleHighScore);
    }
}