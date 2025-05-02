using UnityEngine;

public class PlayerOutfit : MonoBehaviour
{
    public GameObject outfits;
    public bool isPlayer1 = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetOutfit();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject KeyGameObject(int key, GameObject root)
    {
        if (root.transform.childCount > 0)
        {
            int count = 2;
            foreach (Transform VARIABLE in root.transform)
            {
                if (count == key)
                    return VARIABLE.gameObject;
                count++;
            }
        }
        return null;
    }

    private void SetOutfit()
    {
        string playerKey = isPlayer1 ? "Player1Clothes" : "Player2Clothes";
        int key = PlayerPrefs.GetInt(playerKey);
        GameObject outfit = KeyGameObject(key, outfits);
        outfit.SetActive(true);
    }

    private void SetColor()
    {
        string playerKey = isPlayer1 ? "Player1Color" : "Player2Color";
        string colorName = PlayerPrefs.GetString(playerKey);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        switch (colorName)
        {
            case "Red": sr.color = new Color(0.8867f, 0, 0); break;
            case "Orange": sr.color = new Color(0.8867f, 0.2685f, 0); break;
            case "Yellow": sr.color = new Color(0.8867f, 0.703f, 0); break;
            case "Green": sr.color = new Color(0.2483f, 0.5169f, 0); break;
            case "Blue": sr.color = new Color(0, 0, 0.8867f); break;
            case "Purple": sr.color = new Color(0.317f, 0, 0.8867f); break;
            case "Black": sr.color = new Color(0, 0, 0.11f); break;
            case "White": sr.color = Color.white; break;
        }
    }
}
