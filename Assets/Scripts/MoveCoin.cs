using UnityEngine;
using System.Collections;

public class MoveCoin : MonoBehaviour
{
    public int _speed;
    IEnumerator OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "DestroyCoin")
            Destroy(gameObject);
        if (target.tag == "Human")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().color=new Color(255,255,255,0);
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
           
    }
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= _speed * Time.deltaTime;
        transform.position = temp;
    }

}
