using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int key = PlayerPrefs.GetInt("Level");
        GameObject level = KeyGameObject(key, levels);
        level.SetActive(true);
        switch (key)
        {
            case 1: AudioManager.instance?.SwitchMusic(AudioManager.instance.cepelinuBGM); break;
            case 2: AudioManager.instance?.SwitchMusic(AudioManager.instance.menulioBGM); break;
            case 3: AudioManager.instance?.SwitchMusic(AudioManager.instance.platformuBGM); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject KeyGameObject(int key, GameObject root)
    {
        if (root.transform.childCount > 0)
        {
            int count = 1;
            foreach (Transform VARIABLE in root.transform)
            {
                if (count == key)
                    return VARIABLE.gameObject;
                count++;
            }
        }
        return null;
    }

}
