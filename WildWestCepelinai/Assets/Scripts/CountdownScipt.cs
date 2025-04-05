using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScipt : MonoBehaviour
{
    public TextMesh textMesh;
    public Image controls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        textMesh.text = "3!";
        yield return new WaitForSeconds(1);
        textMesh.text = "2!";
        yield return new WaitForSeconds(1);
        textMesh.text = "1!";
        yield return new WaitForSeconds(1);
        textMesh.text = "GO!!!!!!!!!!";
        controls.enabled = false;
        yield return new WaitForSeconds(1);
        textMesh.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
