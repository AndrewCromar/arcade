using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChildSpacer : MonoBehaviour {
    [Header ("Settigns")]
    [SerializeField] private float childMaxWidth = 200;

    [Header ("Debug")]
    [SerializeField] private RectTransform rectTransform;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update(){
        List<RectTransform> children = GetChildren();
        int numberOfChildren = children.Count;
        
        // scale them
        float newWidth = (rectTransform.sizeDelta.x - 200) / numberOfChildren;
        newWidth += newWidth / numberOfChildren; // this weird stuff it to align the last one correctly
        float clampedWidth = Mathf.Clamp(newWidth, 0, childMaxWidth);
        float childWidth = clampedWidth;

        foreach(RectTransform child in children){
            child.sizeDelta = new Vector2(childWidth, child.sizeDelta.y);
        }

        // move them
        float childYPosition = -1 * rectTransform.sizeDelta.y / 2;

        for(int i = 0; i < numberOfChildren; i++){
            RectTransform child = children[i];
            float childXPosition = (childWidth * i) + (childWidth / 2);
            child.anchoredPosition = new Vector2(childXPosition, childYPosition);
        }
        
        //fix last one
        RectTransform lastChild = children[children.Count - 1];
        lastChild.sizeDelta = new Vector2(200, 300);
        float lastChildXPosition = (childWidth * (children.Count - 1)) + (200 / 2);
        lastChild.anchoredPosition = new Vector2(lastChildXPosition, childYPosition);
    }

    private List<RectTransform> GetChildren(){ return transform.Cast<RectTransform>().ToList(); }
}