using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationMenu : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private List<GameObject> clothesP1;
    private List<GameObject> clothesP2;

    private void Start()
    {
        clothesP1 = AllChilds(player1);
        clothesP2 = AllChilds(player2);
        PlayerPrefs.SetInt("Player1Clothes", 1);
        PlayerPrefs.SetInt("Player2Clothes", 1);
    }

    private List<GameObject> AllChilds(GameObject root)
    {
        List<GameObject> result = new List<GameObject>();
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(result, VARIABLE.gameObject);
            }
        }
        return result;
    }

    private void Searcher(List<GameObject> list, GameObject root)
    {
        list.Add(root);
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(list, VARIABLE.gameObject);
            }
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // --------------- needs to be hella optimized and no absolute values......

    public void LeftArrow1()
    {
        int key = PlayerPrefs.GetInt("Player1Clothes"); // im gonna kill my self if this doesnt work :D
        if(key == 1)
        {
            PlayerPrefs.SetInt("Player1Clothes", clothesP1.Count+1);
            clothesP1[clothesP1.Count - 1].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("Player1Clothes", key - 1);
            if(key-2 >= 0)
                clothesP1[key-2].GetComponent<SpriteRenderer>().enabled = false;
            if(key-3 >= 0)
                clothesP1[key-3].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void RightArrow1()
    {
        int key = PlayerPrefs.GetInt("Player1Clothes");
        if (key >= clothesP1.Count + 1)
        {
            PlayerPrefs.SetInt("Player1Clothes", 1);
            clothesP1[clothesP1.Count - 1].GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            PlayerPrefs.SetInt("Player1Clothes", key + 1);
            if (key - 2 >= 0)
                clothesP1[key - 2].GetComponent<SpriteRenderer>().enabled = false;
            if (key - 1 >= 0)
                clothesP1[key - 1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    public void LeftArrow2()
    {
        int key = PlayerPrefs.GetInt("Player2Clothes"); // im gonna kill my self if this doesnt work :D
        if (key == 1)
        {
            PlayerPrefs.SetInt("Player2Clothes", clothesP1.Count + 1);
            clothesP2[clothesP1.Count - 1].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("Player2Clothes", key - 1);
            if (key - 2 >= 0)
                clothesP2[key - 2].GetComponent<SpriteRenderer>().enabled = false;
            if (key - 3 >= 0)
                clothesP2[key - 3].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void RightArrow2()
    {
        int key = PlayerPrefs.GetInt("Player2Clothes");
        if (key >= clothesP1.Count + 1)
        {
            PlayerPrefs.SetInt("Player2Clothes", 1);
            clothesP2[clothesP1.Count - 1].GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            PlayerPrefs.SetInt("Player2Clothes", key + 1);
            if (key - 2 >= 0)
                clothesP2[key - 2].GetComponent<SpriteRenderer>().enabled = false;
            if (key - 1 >= 0)
                clothesP2[key - 1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
