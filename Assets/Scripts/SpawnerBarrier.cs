using UnityEngine;
using System.Collections;

public class SpawnerBarrier : MonoBehaviour {

    [SerializeField]
    public GameObject _weed;
    public GameObject _stone;
    private GameObject[] obj;
    void Start()
    {
        StartCoroutine(spawer());
        GameObject[] g = { _weed, _stone};
        obj = g;
    }
    void Update()
    {

    }
    IEnumerator spawer()
    {        
        yield return new WaitForSeconds(1);
        GameObject g = obj[Random.Range(0, obj.Length)];
        Vector3 temp = g.transform.position;
        Instantiate(g, temp, Quaternion.identity);
        StartCoroutine(spawer());
    }
}
