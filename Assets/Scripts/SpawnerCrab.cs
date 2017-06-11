using UnityEngine;
using System.Collections;

public class SpawnerCrab : MonoBehaviour {

    [SerializeField]
    public GameObject _crab;

    void Start()
    {
        StartCoroutine(spawer());
    }

    IEnumerator spawer()
    {
        yield return new WaitForSeconds(6);
        Vector3 temp = _crab.transform.position;       
        Instantiate(_crab, temp, Quaternion.identity);
        StartCoroutine(spawer());
    }
}
