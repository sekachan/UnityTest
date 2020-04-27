using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        EventSystem.current.SetSelectedGameObject(null);
    }
}
