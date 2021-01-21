using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject m_Player;
    public GameObject m_PlayerModel;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SpawnPlayer(Vector3 pos)
    {
        GameObject p = Instantiate(m_Player, pos, Quaternion.identity) as GameObject;
        Instantiate(m_PlayerModel, p.transform);
    }
}
