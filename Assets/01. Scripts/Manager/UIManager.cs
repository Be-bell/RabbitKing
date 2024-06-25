using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get { return instance; } }
    static UIManager instance;
    readonly string popupPath = "UI/";
    public UIInput input;

    Stack<UI_Base> _popupStack = new Stack<UI_Base>();

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(instance);
        SetEventSystem();
        input = GetComponent<UIInput>();
    }

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    private void SetEventSystem()
    {
        Object obj = FindObjectOfType<EventSystem>();
        if (obj == null) 
        {
            obj = Instantiate(Resources.Load<GameObject>(popupPath + "@EventSystem"));
        }

        DontDestroyOnLoad(obj);
    }

    public void Exit()
    {
        if(_popupStack.Count <= 0)
        {
            Debug.LogError("There is No popup UI in stack!");
            return;
        }

        GameObject go = _popupStack.Pop().gameObject;
        if (go != null)
        {
            go.SetActive(false);
            Destroy(go);
        }

        if (_popupStack.Count > 0)
        {
            go = _popupStack.Peek().gameObject;
            go.SetActive(true);
        }

        SoundManager.Instance.PlayButton();

    }

    public void PopUp<T>() where T : Popup_UI
    {
        GameObject prefab = Resources.Load<GameObject>(popupPath + $"Popup/{typeof(T).Name}");

        if (prefab == null)
        {
            Debug.LogError("There is no PopupUI in the path. Please check your UI name or UI class.");
            return;
        }
        GameObject go;

        if (_popupStack.Count > 0)
        {
            go = _popupStack.Peek().gameObject;
            go.SetActive(false);
        }

        go = Instantiate(prefab, Root.transform);
        go.SetActive(true);
        SoundManager.Instance.PlayButton();
        _popupStack.Push(go.GetComponent<T>());
    }

    public int stackLength()
    {
        return _popupStack.Count;
    }

}