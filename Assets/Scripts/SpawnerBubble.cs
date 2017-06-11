using UnityEngine;
using System.Collections;

public class SpawnerBubble : MonoBehaviour
{

    [SerializeField]
    private GameObject _bubble;

    void Start()
    {
        StartCoroutine(spawer());
    }

    void Update()
    {

    }


    IEnumerator spawer()
    {
        yield return new WaitForSeconds(1);
        int num = Random.Range(2, 6);
        float r = Random.Range(0.3f, 1f);
        BubbleMove o = _bubble.GetComponent<BubbleMove>();
        o.transform.localScale = new Vector3(r,r,1);
        for (int i = 0; i < num; i++)
        {
            Vector3 temp = _bubble.transform.position;
            temp.x = Random.Range(-5f, 5f);
            Instantiate(_bubble, temp, Quaternion.identity);
        }
        StartCoroutine(spawer());
    }
}
