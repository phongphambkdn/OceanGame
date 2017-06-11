using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class Human : MonoBehaviour {

    private float _deltaJump;//do nhay
    private Rigidbody2D _rigidHuman;
    private const float MAX_BLOOD = 5;
    public int _score = 0;
    private float _blood;
    public GameObject boom;
    public GameObject fire;
    public GameObject boomNo;
    private bool _dead = false;
    void Awake()
    {
        _rigidHuman = GetComponent<Rigidbody2D>();
        _deltaJump = 4;
        _blood = MAX_BLOOD;
        boom.GetComponent<Image>().fillAmount =1;
    }

    // Update is called once per frame
    void Update()
    {
        
        move(_rigidHuman, _deltaJump);
        if(_dead == false)
        {
            boom.GetComponent<Image>().fillAmount -= 0.0003f;
            fire.transform.position -= new Vector3(3* 0.0003f, 0, 0);
            if (boom.GetComponent<Image>().fillAmount < 0.4)
            {
                Instantiate(boomNo);
                GameObject.Find("SoundBoom").GetComponent<AudioSource>().Play();
                if (PlayGameController.instance != null)
                {
                    _dead = true;
                    PlayGameController.instance._ShowPanelScore(_score);
                }
                Dead();
                Time.timeScale = 0;
            }
        }
        
    }
    public void move(Rigidbody2D _rigidHuman, float _deltaJump)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            _rigidHuman.velocity = new Vector2(_rigidHuman.velocity.x, _deltaJump);
        }
        if (_rigidHuman.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, _rigidHuman.velocity.y / 37);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        if (_rigidHuman.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (_rigidHuman.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -_rigidHuman.velocity.y / 37);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
             if (PlayGameController.instance != null)
             {
                 PlayGameController.instance._ShowPanelScore(_score);
             }
             Dead();
             Time.timeScale = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Money")
        {
            if(boom.GetComponent<Image>().fillAmount<1)
            boom.GetComponent<Image>().fillAmount += 0.1f;
            fire.transform.position += new Vector3(3 * 0.1f, 0, 0);
            _score++;
          //  heard.addblood();
            if (PlayGameController.instance != null)
            {
                PlayGameController.instance._SetScore(_score);
            }
        }
        if (target.gameObject.tag == "Enemy")
        {
            if (PlayGameController.instance != null)
            {
                PlayGameController.instance._ShowPanelScore(_score);
            }
            Dead();
            Time.timeScale = 0;
        }

    }
    void Dead()
    {
        //GetComponent<AudioSource>().Play();
        //heard.destroyblood();
        GetComponent<SpriteRenderer>().flipY = true; _deltaJump = 0;
       // _dead = true;
        _blood = 0;
        //Time.timeScale = 0;
    }
}
