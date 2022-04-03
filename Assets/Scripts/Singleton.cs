using UnityEngine;
using UnityEngine.SceneManagement;

// T - класс, в который мы хотим поступить, на который будем ссылаться в классе Singleton
// were T:Component - ограничение типа, выбор только Component, привязанные к GameObject 
// T - тип данных под названием Component, который будет передан в класс


//T - проходим все классы, производные от Component
// Иерархия базовых классов:  Object -> Component -> Behaviour -> MonoBehaviour
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


