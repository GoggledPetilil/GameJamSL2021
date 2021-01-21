using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject p = Instantiate(m_PlayerModel, pos, Quaternion.identity) as GameObject;
        m_Player = p;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadToLevel()
    {
        LoadScene("Level");
    }
}
