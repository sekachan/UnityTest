using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCount : MonoBehaviour
{
    public int Count { get; set; } = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Count++;
        this.GetComponent<TextMeshProUGUI>().SetText("<size=60%>value</size> {0}", Count);
    }
}
