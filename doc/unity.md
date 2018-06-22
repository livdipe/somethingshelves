设置Toggle的isOn值时，要先把Toggle的父对象disable掉，不然没有效果

UGUI里的ui元素的position值要通过RectTransform 的 `GetWorldCorners` 寻值设置
```
        Vector3[] array = new Vector3[4];
        (m_Map.transform as RectTransform).GetWorldCorners(array);
        float mX = array[0].x;
        (m_Player.transform as RectTransform).GetWorldCorners(array);
        float pX = (array[2].x + array[0].x) / 2;
        Vector3 pos = m_Map.transform.position;
        pos.x = mX - pX;
        m_Map.transform.position = pos;
```