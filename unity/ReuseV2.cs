using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class ReuseV : MonoBehaviour 
{
    public GameObject prefab;
    ScrollRect scroll;
    RectTransform rectContent;
    RectTransform rectViewport;
    float cellHeight = 100;
    float cellSpace = 20;
    int testCount = 2;
    int maxShowItemCount;
    List<Vector2> anchoredPositions = new List<Vector2>();
    List<GameObject> objs = new List<GameObject>();
    int startIndex = -1;

    void Awake()
    {
        scroll = GetComponent<ScrollRect>();
        scroll.onValueChanged.AddListener(OnValueChanged);
        rectViewport = transform.FindChild("Viewport") as RectTransform;
        rectContent = transform.FindChild("Viewport/Content") as RectTransform;
    }

    void Start()
    {
        maxShowItemCount = Mathf.RoundToInt(rectViewport.sizeDelta.y / (cellHeight + cellSpace)) + 2;

        InitContent();

        for (int i = 0; i < maxShowItemCount; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab) as GameObject;
            obj.transform.SetParent(rectContent.transform, false);
            if (i < testCount)
                obj.SetActive(true);
            objs.Add(obj);
        }
        if (testCount < maxShowItemCount)
        {
            OnValueChanged(Vector2.zero);
            scroll.verticalNormalizedPosition = 1;
        }
        else
        {
            scroll.verticalNormalizedPosition = 1;
        }
    }

    void InitContent()
    {
        anchoredPositions.Clear();
//        for (int i = 0; i < testCount; i++)
//        {
//            anchoredPositions.Add(new Vector2(0, -(cellHeight * i + cellSpace * i)));
//        }
        anchoredPositions.Add(new Vector2(0, -10));
        anchoredPositions.Add(new Vector2(0, -130));
        rectContent.sizeDelta = new Vector2(0, cellHeight * testCount + (testCount - 1) * cellSpace);
    }

    void OnValueChanged(Vector2 v)
    {
        int idx = GetStartIndex(scroll.verticalNormalizedPosition);
        if (idx != startIndex)
        {
            // first time
            if (startIndex == -1)
            {
                startIndex = idx;
                for (int i = 0; i < maxShowItemCount; i++)
                {
                    if (startIndex + i < testCount)
                    {
                        Debug.LogError(startIndex + i);
                        (objs[i].transform as RectTransform).anchoredPosition = anchoredPositions[startIndex + i];
                        ShowItem(objs[i].transform, (startIndex + i).ToString());
                    }
                }
            }
            else
            {
                int moveIndex = 0;
                int destIndex = 0;
                Transform tr = null;
                if (idx > startIndex)
                {
                    moveIndex = 0;
                    destIndex = idx + maxShowItemCount - 1;
                    tr = objs[moveIndex].transform;
                    MoveFirstToLast();
                }
                else
                {
                    moveIndex = maxShowItemCount - 1;
                    destIndex = idx;
                    tr = objs[moveIndex].transform;
                    MoveLastToFirst();
                }
                (tr as RectTransform).anchoredPosition = anchoredPositions[destIndex];
                ShowItem(tr, destIndex.ToString());
                startIndex = idx;
            }
        }
    }

    // 将第一个变为最后一个
    void MoveFirstToLast()
    {
        GameObject temp = objs[0];
        objs.RemoveAt(0);
        objs.Add(temp);
    }

    // 将最后一个变为第一个
    void MoveLastToFirst()
    {
        GameObject temp = objs[objs.Count - 1];
        objs.RemoveAt(objs.Count - 1);
        objs.Insert(0, temp);
    }

    void ShowItem(Transform item,  string msg)
    {
        Text text = item.FindChild("Text").GetComponent<Text>();
        text.text = msg;
        item.gameObject.SetActive(true);
    }

    int GetStartIndex(float verticalNormalizedPosition)
    {
        float val1 = rectContent.sizeDelta.y - rectViewport.sizeDelta.y;
        float cell = cellHeight / val1;
        float space = cellSpace / val1;
        int startIdx = 0;
        for (int i = 0; i < testCount; i++)
        {
            float itemTop = 1 - (i * cellHeight + i * cellSpace) / val1;
            float itemBottom = itemTop - cell;;
            if (itemTop >= verticalNormalizedPosition && itemBottom <= verticalNormalizedPosition)
            {
                startIdx = i;
                break;
            }
            float spaceBottom = itemBottom - space;
            if (itemBottom >= verticalNormalizedPosition && spaceBottom <= verticalNormalizedPosition)
            {
                startIdx = i + 1;
                break;
            }
        }
        return startIdx;
    }
}
