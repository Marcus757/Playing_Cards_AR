using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneChildOnClick : MonoBehaviour {
    public Transform prefab;
    public float xOffset;
    private Transform child;

	// Use this for initialization
	void Start () {
        child = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void CloneOnClick()
    {
        int childCount = transform.childCount;
        Transform instance =
            Instantiate(prefab, child.localPosition, child.rotation);
        instance.transform.SetParent(transform);
        instance.localScale = child.localScale;
        instance.localPosition = new Vector3(childCount * xOffset, 0, 0);
    }
}
