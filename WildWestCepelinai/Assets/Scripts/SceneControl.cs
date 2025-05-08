using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField]
    private float _sceneFadeDuration;

    private SceneFade _sceneFade;

    private void Awake()
    {
        _sceneFade = GetComponentInChildren<SceneFade>();
    }

    private IEnumerator Start()
    {
        yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return _sceneFade.FadeOutCoroutine(_sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    //[SerializeField]
    //private float _sceneFadeDuration;

    //private static SceneControl _instance;
    //private SceneFade _sceneFade;

    //private void Awake()
    //{
    //    if (_instance != null && _instance != this)
    //    {
    //        Destroy(gameObject); // sunaikina dublikata
    //        return;
    //    }

    //    _instance = this;
    //    DontDestroyOnLoad(gameObject);

    //    _sceneFade = GetComponentInChildren<SceneFade>(true);
    //    if (_sceneFade == null)
    //    {
    //        Debug.LogError("SceneFade component not found!");
    //    }
    //}

    //private IEnumerator Start()
    //{
    //    yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration);
    //}

    //public void LoadScene(string sceneName)
    //{
    //    StartCoroutine(LoadSceneCoroutine(sceneName));
    //}

    //private IEnumerator LoadSceneCoroutine(string sceneName)
    //{
    //    yield return _sceneFade.FadeOutCoroutine(_sceneFadeDuration);
    //    yield return SceneManager.LoadSceneAsync(sceneName);
    //    yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration); // <- kad ir naujoj scenoj ifeidas veiktu
    //}
}