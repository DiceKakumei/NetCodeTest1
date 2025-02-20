using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class CoinManager : NetworkBehaviour
{
    //コインのプレファブ
    [SerializeField] private NetworkObject m_coinPrefab;
    //生成したコインのリスト
    private List<GameObject> m_coinObjects = new List<GameObject>();

    //スポーンされたとき
    public override void OnNetworkSpawn()
    {
        //ホストの場合
        if (IsHost)
        {
            GenerateCoin();
        }
    }

    public void GenerateCoin()
    {
        for(int x = 0; x < 10; x++)
        {
            NetworkObject coin = Instantiate(m_coinPrefab);
            int posX = UnityEngine.Random.Range(-40, 40) - 5;
            int posZ = UnityEngine.Random.Range(-40, 40) - 5;
            coin.transform.position = new Vector3(posX, 5, posZ);

            coin.Spawn();
            m_coinObjects.Add(coin.gameObject);
        }
    }

    private static CoinManager instance;
    public static CoinManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (CoinManager)FindObjectOfType(typeof(CoinManager));
            }
            return instance;
        }
    }

    public void DeleteCoin(GameObject coinObj)
    {
        var network = coinObj.GetComponent<NetworkObject>();
        network.Despawn();
        m_coinObjects.Remove(coinObj);
        //すべて消えたら再生成
        if (m_coinObjects.Count == 0)
        {
            GenerateCoin();
        }
    }
}
