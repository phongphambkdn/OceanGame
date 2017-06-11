using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    public GameObject _croco;
    public GameObject _shark;
    private GameObject[] obj;
    private float _speed;

    void Start()
    {
        StartCoroutine(spawer());
        GameObject[] g = { _croco, _shark };
        obj = g;
        _speed = 5;
    }
    IEnumerator spawer()
    {
        yield return new WaitForSeconds(Random.Range(1,4));
        _speed += 0.01f;
        GameObject g = obj[Random.Range(0, obj.Length)];
        Vector3 temp = g.transform.position;
       // int sl = Random.Range(1, 3);
        temp.y = Random.Range(-4f, 2.1f);
        g.GetComponent<Enemy>()._speed = _speed;
        Instantiate(g, temp, Quaternion.identity);
        StartCoroutine(spawer());
    }
}
