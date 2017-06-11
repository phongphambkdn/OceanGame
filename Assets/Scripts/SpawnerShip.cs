using UnityEngine;
using System.Collections;

public class SpawnerShip : MonoBehaviour {

    [SerializeField]
    public GameObject _ship;

    void Start()
    {
        StartCoroutine(spawer());
    }

    IEnumerator spawer()
    {
        yield return new WaitForSeconds(6);
        Vector3 temp = _ship.transform.position;
        Instantiate(_ship, temp, Quaternion.identity);
        StartCoroutine(spawer());
    }
}
