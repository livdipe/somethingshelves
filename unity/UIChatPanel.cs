using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using AssetBundleFramework;
public class UIChatPanel : TTUIPage
{
    private Button btnSend;
    private InputField inputMsg;
    private ScrollRect scrollRect;
    private float viewportMin;
    private float viewportMax;
    private float viewportWidth;
    GameObject[] prefabs = new GameObject[3];
    private RectTransform baseRectTextBg;
    private RectTransform baseRectText;
    struct SMessage
    {
        public int type;
        public GameObject obj;
        public string msg;
        public float top;
        public float bottom;
        public float contentY;
        public Vector3 anchoredPosition;
        public Vector2 textBgSize;
    }
    private List<SMessage> allMessages = new List<SMessage>();
    // 回收对象池
    Dictionary<int, List<GameObject>> inActives = new Dictionary<int, List<GameObject>>();
    // 可视范围内最顶部消息的索引
    int topIdx = -1;
    // 可视范围内最底部消息的索引
    int bottomIdx = -1;
    // 列表中消息数
    int itemCount = 0;
    // 起始条目空间
    const float contentStartSpace = 50;
    // 条目之间空间
    const float contentItemSpace = 30;
    // 用于记录下一条目开始位置
    Vector2 itemEndPosition = new Vector2(0, -contentStartSpace);

    public UIChatPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "ChatPanel";
        uiAssetPathDic.Add("ui/chatpanel", "ChatPanel");
    }

    public override void Awake(GameObject go)
    {
        btnSend = this.transform.FindChild("Panel_Bg/Panel_Chat/Button_Send").GetComponent<Button>();
        inputMsg = this.transform.FindChild("Panel_Bg/Panel_Chat/InputField_Content").GetComponent<InputField>();
        prefabs[0] = this.transform.FindChild("Panel_Bg/Panel_Chat/Scroll View/Viewport/Content/Item_Time").gameObject;
        prefabs[1] = this.transform.FindChild("Panel_Bg/Panel_Chat/Scroll View/Viewport/Content/Item_Right").gameObject;
        prefabs[2] = this.transform.FindChild("Panel_Bg/Panel_Chat/Scroll View/Viewport/Content/Item_Left").gameObject;
        baseRectTextBg = prefabs[1].transform.FindChild("Image_Content") as RectTransform;
        baseRectText = prefabs[1].transform.FindChild("Image_Content/Text") as RectTransform;
        scrollRect = this.transform.FindChild("Panel_Bg/Panel_Chat/Scroll View").GetComponent<ScrollRect>();
        InitViewportValue(scrollRect.transform);

        btnSend.onClick.AddListener(OnSend);
        scrollRect.onValueChanged.AddListener(OnChanged);
        TTUIRoot.Instance.StartCoroutine(SendRoutine());
    }

    void InitViewportValue(Transform trScrollRect)
    {
        viewportWidth = (trScrollRect.FindChild("Viewport") as RectTransform).rect.width;
        viewportMin = trScrollRect.FindChild("Viewport/Top").position.y;
        viewportMax = trScrollRect.FindChild("Viewport/Bottom").position.y;
    }

    IEnumerator SendRoutine()
    {
        for (int i = 0; i < 100; i++)
        {
//            AddChatItem(9.ToString("00") + ":" + 8.ToString("00"), true);
//            AddChatItem(testCount.ToString());
            AddChatItem(RandomString(Random.Range(1, 100)));
            yield return new WaitForSeconds(0.01f);
        }
    }

    void OnSend()
    {
        if (!string.IsNullOrEmpty(inputMsg.text))
        {
            AddChatItem(System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00"), true);
            AddChatItem(inputMsg.text);
        }
    }


    // 根据文字长度，改变文字背景大小加长或者加高（长度有限制）
    // 返回修改后的文字背景大小
    Vector2 Adapt(Text _text, RectTransform _rect)
    {
        float limitWidth = scrollRect.content.rect.width * 0.6f;
        float width = _text.preferredWidth + baseRectText.offsetMin.x * 2;
        float height = baseRectTextBg.sizeDelta.y;
        int lines = (int)(width / limitWidth) + 1;
        width = width > limitWidth ? limitWidth : width;
        _rect.sizeDelta = new Vector2(width, height * lines);

        return _rect.sizeDelta;
    }

    // 获取一个条目的顶部和底部位置（y值）
    // 用于判断条目是否在列表可视范围
    Vector2 GetItemTopAndBottom(Transform trItem)
    {
        float top = trItem.position.y;
        float bottom = trItem.position.y;
        for (int i = 0; i < trItem.childCount; i++)
        {
            Transform tr = trItem.GetChild(i).FindChild("Top");
            if (tr != null)
            {
                if (top < tr.position.y)
                {
                    top = tr.position.y;
                }
            }
            tr = trItem.GetChild(i).FindChild("Bottom");
            if (tr != null)
            {
                if (bottom > tr.position.y)
                {
                    bottom = tr.position.y;
                }
            }
        }
        return new Vector2(top, bottom);
    }

    // 添加向面板上添加一条消息
    void AddChatItem(string msg, bool isTime = false)
    {
        int type = 0;
        if (isTime)
        {
            itemEndPosition.x = 0;
            type = 0;
        }
        else if (itemCount % 2 == 0)
        {
            itemEndPosition.x = viewportWidth * 0.5f;
            type = 1;
        }
        else
        {
            itemEndPosition.x = -viewportWidth * 0.5f;
            type = 2;
        }

        GameObject item = Spawn(type);
        item.name = itemCount.ToString();
        item.transform.SetParent(scrollRect.content as Transform);
        item.transform.localScale = Vector3.one;
        item.SetActive(true);

        Transform trContent = item.transform.FindChild("Image_Content");
        Text text = trContent.FindChild("Text").GetComponent<Text>();
        text.text = msg;
        Vector2 textBgSize = Adapt(text, trContent as RectTransform);
        itemEndPosition += new Vector2(0, -contentItemSpace);
        (item.transform as RectTransform).anchoredPosition = itemEndPosition;
        // 条目末尾
        itemEndPosition += new Vector2(0, -textBgSize.y);
        // 改变滚动框大小
        scrollRect.content.sizeDelta = new Vector2(0, -itemEndPosition.y);
        // 到底部
        scrollRect.verticalNormalizedPosition = 0;

        // 添加之后缓存，不用再次计算
        SMessage message = new SMessage();
        message.type = type;
        message.obj = item;
        message.msg = msg;
        Vector2 top_bottom = GetItemTopAndBottom(item.transform);
        message.top = top_bottom.x;
        message.bottom = top_bottom.y;
        message.contentY = scrollRect.content.transform.position.y;
        message.anchoredPosition = (item.transform as RectTransform).anchoredPosition;
        message.textBgSize = textBgSize;
        allMessages.Add(message);

        if (allMessages.Count == 1)
        {
            topIdx = 0;
        }
        bottomIdx = allMessages.Count - 1;

        if (!isTime)
        {
            itemCount++;
        }
    }

    void ShowItem(GameObject obj, SMessage smessage)
    {
        Transform item = obj.transform;
        RectTransform rectTextBg = item.FindChild("Image_Content") as RectTransform;
        (item as RectTransform).anchoredPosition = smessage.anchoredPosition;
        rectTextBg.sizeDelta = smessage.textBgSize;
        Text text = item.FindChild("Image_Content/Text").GetComponent<Text>();
        text.text = smessage.msg;
        item.gameObject.SetActive(true);
    }

    void SetTopBottomIndex(int idx, bool show)
    {
        if (show)
        {
            if (topIdx > idx)
            {
                topIdx--;
            }
            if (bottomIdx < idx)
            {
                bottomIdx++;
            }
        }
        else
        {
            if (idx == topIdx)
            {
                topIdx++;
            }
            if (idx == bottomIdx)
            {
                bottomIdx--;
            }
        }
    }

    void OnChanged(Vector2 v)
    {
        int start = topIdx - 1 < 0 ? 0 : topIdx - 1;
        int end = bottomIdx + 1 >= allMessages.Count ? allMessages.Count - 1 : bottomIdx + 1;
//        int jumpCount = 0;
//        Debug.Log("  start:" + start + "  end:" + end);
        for (int i = start; i <= end; i++) 
        {
            if (i > topIdx && i < bottomIdx)
            {
//                jumpCount++;
                continue;
            }

            float offset = (scrollRect.content.transform.position.y - allMessages[i].contentY);
            float top = allMessages[i].top + offset;
            float bottom = allMessages[i].bottom + offset;
//            Debug.Log(top + "," + bottom + "  " + trViewportBottom.position + "  " + trViewportTop.position);
            if (top < viewportMax || bottom > viewportMin)
            {
                if (allMessages[i].obj != null)
                {
                    SetTopBottomIndex(i, false);
//                    Debug.Log("topIdx:" + topIdx + "  bottomIdx:" + bottomIdx + "  unShow index: " + i);
                    Despawn(allMessages[i].type, allMessages[i].obj);
                    SMessage temp = allMessages[i];
                    temp.obj = null;
                    allMessages[i] = temp;
                }
            }
            else if ((top > viewportMax && top < viewportMin) ||
                (bottom < viewportMin && bottom > viewportMax))
            {
                if (allMessages[i].obj == null)
                {
                    SetTopBottomIndex(i, true);
//                    Debug.Log("topIdx:" + topIdx + "  bottomIdx:" + bottomIdx + "  Show index: " + i);
                    GameObject obj = Spawn(allMessages[i].type);
                    SMessage temp = allMessages[i];
                    temp.obj = obj;
                    allMessages[i] = temp;
                    ShowItem(obj, allMessages[i]);
                }
            }
        }
//        Debug.Log("jumpCount:" + jumpCount);
    }

    // pool 
    GameObject Spawn(int type)
    {
        if (!inActives.ContainsKey(type) || inActives[type] == null || inActives[type].Count == 0)
        {
            return NewOne(type);
        }
        else
        {
            GameObject item = inActives[type][0];
            inActives[type].RemoveAt(0);
            return item;
        }
    }

    GameObject NewOne(int type)
    {
        GameObject item = GameObject.Instantiate(prefabs[type]) as GameObject;;
        return item;
    }

    void Despawn(int type, GameObject obj)
    {
        obj.SetActive(false);
        if (!inActives.ContainsKey(type))
        {
            List<GameObject> list = new List<GameObject>();
            list.Add(obj);
            inActives.Add(type, list);
        }
        else
        {
            inActives[type].Add(obj);
        }
    }

    // 随机len长度字符串
    string RandomString(int len)
    {
        char[] ret = new char[len];
        for (int i = 0; i < len; i++)
        {
            //大写
            ret[i] = (char)(Random.Range(65, 90));
            if (Random.value > 0.5f)
            {
                //小写
                ret[i] = (char)(Random.Range(97, 122));
            }
        }
        return new string(ret);
    }
}
