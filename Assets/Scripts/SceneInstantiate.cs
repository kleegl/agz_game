using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �� ������ �������� �������� ���� � ��������� ���������� �����
/// </summary>
public class SceneInstantiate : MonoBehaviour
{
    [SerializeField] private Object persistentScene;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(persistentScene.name, LoadSceneMode.Additive);  // ��������� ����� ����������� �� ����
    }

    [ContextMenu("ChangeScene")]
    public void NextScene()
    {
        SceneManager.UnloadSceneAsync("Main");
        SceneManager.LoadSceneAsync("Second", LoadSceneMode.Additive);
    }
}
