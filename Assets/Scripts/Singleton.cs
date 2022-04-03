using UnityEngine;
using UnityEngine.SceneManagement;

// T - �����, � ������� �� ����� ���������, �� ������� ����� ��������� � ������ Singleton
// were T:Component - ����������� ����, ����� ������ Component, ����������� � GameObject 
// T - ��� ������ ��� ��������� Component, ������� ����� ������� � �����


//T - �������� ��� ������, ����������� �� Component
// �������� ������� �������:  Object -> Component -> Behaviour -> MonoBehaviour
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                print(typeof(T));
                GameObject obj = new GameObject();
                obj.name = ($"SINGLENOT {typeof(T).Name}");
                //obj.hideFlags = HideFlags.HideAndDontSave;
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}

public class SingletonPersistent<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Scene activeScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Managers"));

                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                obj.hideFlags = HideFlags.HideAndDontSave;
                _instance = obj.AddComponent<T>();

                SceneManager.SetActiveScene(activeScene);
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance != this)
            _instance = null;
    }
}


