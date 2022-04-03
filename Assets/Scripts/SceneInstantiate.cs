using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// не забудь добавить Менеджер сцен в Настройки построения сцены
/// </summary>
public class SceneInstantiate : MonoBehaviour
{
    [SerializeField] private Object persistentScene;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(persistentScene.name, LoadSceneMode.Additive);  // загружает сцену параллельно на фоне
    }

    [ContextMenu("ChangeScene")]
    public void NextScene()
    {
        SceneManager.UnloadSceneAsync("Main");
        SceneManager.LoadSceneAsync("Second", LoadSceneMode.Additive);
    }
}
