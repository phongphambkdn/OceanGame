using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public float speed;
    private Renderer _rend;
    // Use this for initialization
    void Start()
    {
        float height = Camera.main.orthographicSize * 2f;
        //   float width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(transform.localScale.x, height, 0f);
        _rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        _rend.material.mainTextureOffset = offset;
    }
}
