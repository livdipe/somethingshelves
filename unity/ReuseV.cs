using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class ReuseV : MonoBehaviour 
{
    public Camera uiCamera;
    public ScrollRect scroll;
    public RectTransform rectContent;
    public RectTransform rectViewport;
    public Transform trContent;
    public float cellHeight;
//    public RectTransform rectBottom;
//    public RectTransform rectTop;
    List<string> allMessages = new List<string>{"1", "2", "3", "4", "5", "6"};
    int topIdx;
    int bottomIdx;
    float viewportMin;
    float viewportMax;

    void Awake()
    {
        scroll = GetComponent<ScrollRect>();
        scroll.onValueChanged.AddListener(OnChanged);
        SetContentSize();
    }

    void Start()
    {
        Debug.LogError(trContent.position);
        Debug.LogError( uiCamera.WorldToScreenPoint(trContent.position) );
    }

    void ViewportInfo()
    {
    }

    void SetContentSize()
    {
        Vector2 orgSize = rectContent.sizeDelta;
        float height = allMessages.Count* cellHeight;
        rectContent.sizeDelta = new Vector2(orgSize.x, height);
    }

    void OnChanged(Vector2 v)
    {
//        int start = topIdx - 1 < 0 ? 0 : topIdx - 1;
//        int end = bottomIdx + 1 >= allMessages.Count ? allMessages.Count - 1 : bottomIdx + 1;
//        //        int jumpCount = 0;
//        //        Debug.Log("  start:" + start + "  end:" + end);
//        for (int i = start; i <= end; i++) 
//        {
//            if (i > topIdx && i < bottomIdx)
//            {
//                //                jumpCount++;
//                continue;
//            }
//
//            float offset = (scroll.content.transform.position.y - allMessages[i].contentY);
//            float top = allMessages[i].top + offset;
//            float bottom = allMessages[i].bottom + offset;
//            //            Debug.Log(top + "," + bottom + "  " + trViewportBottom.position + "  " + trViewportTop.position);
//            if (top < viewportMax || bottom > viewportMin)
//            {
//                if (allMessages[i].obj != null)
//                {
//                    SetTopBottomIndex(i, false);
//                    //                    Debug.Log("topIdx:" + topIdx + "  bottomIdx:" + bottomIdx + "  unShow index: " + i);
//                    Despawn(allMessages[i].type, allMessages[i].obj);
//                    SMessage temp = allMessages[i];
//                    temp.obj = null;
//                    allMessages[i] = temp;
//                }
//            }
//            else if ((top > viewportMax && top < viewportMin) ||
//                (bottom < viewportMin && bottom > viewportMax))
//            {
//                if (allMessages[i].obj == null)
//                {
//                    SetTopBottomIndex(i, true);
//                    //                    Debug.Log("topIdx:" + topIdx + "  bottomIdx:" + bottomIdx + "  Show index: " + i);
//                    GameObject obj = Spawn(allMessages[i].type);
//                    SMessage temp = allMessages[i];
//                    temp.obj = obj;
//                    allMessages[i] = temp;
//                    ShowItem(obj, allMessages[i]);
//                }
//            }
//        }
    }
}
