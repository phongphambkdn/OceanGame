using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

    public int _speed;
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "DestroyCoin")
            Destroy(gameObject);
    }
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= _speed * Time.deltaTime;
        transform.position = temp;
    }
}
