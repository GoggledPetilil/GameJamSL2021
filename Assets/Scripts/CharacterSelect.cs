using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] m_PlayerModels;
    public int m_ModelID;
    public GameObject m_ModelPivot;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeModel();
    }

    public void IncreaseModelID()
    {
        m_ModelID++;
        ChangeModelID();
    }

    public void DecreaseModelID()
    {
        m_ModelID--;
        ChangeModelID();
    }

    private void ChangeModelID()
    {
        if (m_ModelID < 0)
        {
            m_ModelID = m_PlayerModels.Length - 1;
        }
        else if (m_ModelID > m_PlayerModels.Length - 1)
        {
            m_ModelID = 0;
        }

        ChangeModel();
    }

    private void ChangeModel()
    {
        Destroy(m_ModelPivot.transform.GetChild(1).gameObject);
        
        Vector3 posMod = new Vector3(0f, 0.2f, 0f);
        Vector3 pos = m_ModelPivot.transform.position + posMod;
        
        Instantiate(m_PlayerModels[m_ModelID], pos, Quaternion.identity, m_ModelPivot.transform);
    }

    public void ModelToGameManager()
    {
        GameManager.instance.m_PlayerModel = m_PlayerModels[m_ModelID];
        GoToGameplay();
    }

    private void GoToGameplay()
    {
        GameManager.instance.LoadScene("Level");
    }
}
