using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public enum CoinType { BRONZE, SILVER, GOLD};

    public CoinType Type;

    private CoinType _type;

    public Material[] CoinMaterials;

    public static int CoinCounter = 0;

    private int coinValue = 1;

    CoinType coinMaterial
    {

        get
        {
            return _type;
        }

        set
        {
            _type = value;

            int _typeValue = (int)_type;

            Material _mat = CoinMaterials[_typeValue];

            Renderer Rend = GetComponent<Renderer>();

            if (Rend != null)
            {
                Rend.material = _mat;
                coinValue = 1 + (int)Mathf.Pow(_typeValue, 2);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        coinMaterial = Type;
        CoinCounter += coinValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }


    private void OnDestroy()
    {
        CoinCounter -= coinValue;

        if (CoinCounter <= 0)
        {
            Debug.Log("All the coins were collected");
        }

    }


}
