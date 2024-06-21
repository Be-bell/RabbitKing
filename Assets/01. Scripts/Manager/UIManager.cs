using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    Stack<Popup_UI> _popupStack = new Stack<Popup_UI>();

    static UIManager instance;
    readonly string path = "Assets/03. Prefabs/UI/";
    public static UIManager Instance {  get { return instance; } }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
        SetEventSystem();
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
            obj = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(path + "@EventSystem.prefab"));
        }

        DontDestroyOnLoad(obj);
    }

    public void Exit()
    {
        Debug.Log("Exit");

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

    }

    public void PopUp<T>() where T : Popup_UI
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path + $"Popup/{typeof(T).Name}.prefab");

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
        _popupStack.Push(go.GetComponent<T>());
    }

    public void MenuUI(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (_popupStack.Count == 0)
            {
                Time.timeScale = 0f;
                PopUp<MenuUI>();
            }
            else
            {
                while (_popupStack.Count > 0)
                {
                    Exit();
                }
                Time.timeScale = 1.0f;
            }
        }
    }
}