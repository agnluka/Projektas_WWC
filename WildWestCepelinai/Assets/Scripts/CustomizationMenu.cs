using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationMenu : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private List<GameObject> clothesP1;
    private List<GameObject> clothesP2;

    private bool isPlayer1;

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

    public void IsPlayer1()
    {
        isPlayer1 = true;
    }

    public void IsPlayer2()
    {
        isPlayer1 = false;
    }

    private void SetColor(string colorName, Color colorValue)
    {
        string playerKey = isPlayer1 ? "Player1Color" : "Player2Color";
        GameObject player = isPlayer1 ? player1 : player2;

        PlayerPrefs.SetString(playerKey, colorName);
        player.GetComponent<SpriteRenderer>().color = colorValue;
    }

    public void C1Red()
    {
        SetColor("Red", new Color(0.8867f, 0, 0));
    }

    public void C2Orange()
    {
        SetColor("Orange", new Color(0.8867f, 0.2685f, 0));
    }

    public void C3Yellow()
    {
        SetColor("Yellow", new Color(0.8867f, 0.703f, 0));
    }

    public void C4Green()
    {
        SetColor("Green", new Color(0.2483f, 0.5169f, 0));
    }

    public void C5Blue()
    {
        SetColor("Blue", new Color(0, 0, 0.8867f));
    }

    public void C6Purple()
    {
        SetColor("Purple", new Color(0.317f, 0, 0.8867f));
    }

    public void C7Black()
    {
        SetColor("Black", new Color(0, 0, 0.11f));
    }

    public void C8White()
    {
        SetColor("White", Color.white);
    }

    // --------------- needs to be hella optimized and no absolute values......

    public void ChangeClothes(int direction)
    {
        string playerKey = isPlayer1 ? "Player1Clothes" : "Player2Clothes";
        List<GameObject> clothesList = isPlayer1 ? clothesP1 : clothesP2;

        int key = PlayerPrefs.GetInt(playerKey);
        int max = clothesList.Count + 1;

        // Disable current clothes
        if (key - 2 >= 0)
            clothesList[key - 2].GetComponent<SpriteRenderer>().enabled = false;

        // Move left or right (with wrap-around)
        key += direction;
        if (key < 1)
            key = max;
        if (key > max)
            key = 1;

        PlayerPrefs.SetInt(playerKey, key);

        // Enable new clothes
        if (key - 2 >= 0)
            clothesList[key - 2].GetComponent<SpriteRenderer>().enabled = true;
    }

    public void LeftArrow() => ChangeClothes(-1);
    public void RightArrow() => ChangeClothes(1);
}
