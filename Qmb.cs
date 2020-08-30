using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qmb : MonoBehaviour
{
    public Transform prefab;
    public bool Coin;
    public bool coinBurst;
    public int coinAmount;
    public bool Item;
    public bool Badge;
    private int coinCountqmb;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        coinCountqmb = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if (Coin == true && coinAmount > 0)
        {
            if (coinBurst == false)
            {
                coinCountqmb += 1;
                GameObject.Find("Data").GetComponent<Data>().coinCount += coinCountqmb;
                coinCountqmb = 0;
                coinAmount--;
            } else
            {
                StartCoroutine(coinBurstC());
            }
           
        }

        Debug.Log(Coin);

        FindObjectOfType<QMBController>().qmbbump();

        Instantiate(prefab, new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y) + 1, gameObject.transform.position.z), Quaternion.identity);
    }

    IEnumerator coinBurstC()
    {
        for (; coinAmount > 0; coinAmount--)
        {
            coinCountqmb += 1;
            GameObject.Find("Data").GetComponent<Data>().coinCount += coinCountqmb;
            coinCountqmb = 0;
            yield return new WaitForSeconds(0.25f);
        }

        StopCoroutine(coinBurstC());
    }
}
