using UnityEngine;
using System.Collections;

public class BubbleMove : MonoBehaviour
{
    public float _speed;

    void Update()
    {
        if (transform.position.y >= 0) Destroy(gameObject);
        Vector3 temp = transform.position;
        temp.y += _speed * Time.deltaTime;
        transform.position = temp;
    }
}
