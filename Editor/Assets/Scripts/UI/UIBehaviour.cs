using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
	private bool m_isVisible;
	
	public bool isVisible
	{
		get
		{
			return m_isVisible;
		}
		set
		{
            m_isVisible = value;
            gameObject.SetActive(m_isVisible);
        }
	}
	
    protected virtual void Start()
    {

    }

    protected virtual void Awake()
    {

    }

    public virtual void Show()
    {
        isVisible = true;
    }

    public virtual void Hide()
    {
		isVisible = false;
    }


    public GameObject Find(string name)
    {
        return Find(name, transform);
    }

    public GameObject Find(string name, Transform transform)
    {
        var t = transform.FindChild(name);
        if(t != null)
        {
            return t.gameObject;
        }
        return null;
    }

    public GameObject FindNested(string name)
    {
        return FindNested(name, transform);
    }

    public GameObject FindNested(string name, Transform transform)
    {
        GameObject result = null;

        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(i);
            if(child.name.Equals(name))
            {
                result =  child.gameObject;
            }
            else
            {
                result = FindNested(name, child);
            }
            if(result != null)
            {
                break;
            }
        }
        return result;
    }
}
