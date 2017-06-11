using UnityEngine;
using System.Collections;

public class SpawnerCoin : MonoBehaviour
{

    [SerializeField]
    private GameObject _money;

    void Start()
    {
        StartCoroutine(spawer());
    }

    void Update()
    {

    }


    IEnumerator spawer()
    {
        yield return new WaitForSeconds(5);
        Vector3 temp = _money.transform.position;
        temp.y = Random.Range(-4f, -0.7f);
        Instantiate(_money, temp, Quaternion.identity);
        StartCoroutine(spawer());
    }
}
