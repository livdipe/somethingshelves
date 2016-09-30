```
<?xml version="1.0" encoding="utf-8"?>
<resources>
<style name="UnityThemeSelector">
</style>
</resources>
```

http://forum.unity3d.com/threads/keyboard-text-white.391322/

使用以上会有输入法白色的问题（华为）,改为:

```
<?xml version="1.0" encoding="utf-8"?>
<resources>
<style parent="android:Theme.Material.Light.NoActionBar.Fullscreen" name="UnityThemeSelector">
</style>
</resources>
```

求位置delta
```
 #pragma strict
 
 public var delta : Vector3 = Vector3.zero;
 private var lastPos : Vector3 = Vector3.zero;
 
 function Update()
 {
     if ( Input.GetMouseButtonDown(0) )
     {
         lastPos = Input.mousePosition;
     }
     else if ( Input.GetMouseButton(0) )
     {
         delta = Input.mousePosition - lastPos;
 
         // Do Stuff here
         
         Debug.Log( "delta X : " + delta.x );
         Debug.Log( "delta Y : " + delta.y );
 
         // End do stuff
 
         lastPos = Input.mousePosition;
     }
 }
```

通过Resource.Load加载的资源卸载方式，
注意 `obj = null` 没有这个会卸载不成功
```
IEnumerator Start () 
{
    GameObject obj = Instantiate(Resources.Load("LoadingPanel", typeof(GameObject))) as GameObject;

    yield return new WaitForSeconds(1);

    Destroy(obj);

    obj = null;

    yield return new WaitForSeconds(0.5f);

    Resources.UnloadUnusedAssets();
}
```

编辑器中停止
```
UnityEditor.EditorApplication.isPlaying = false;
```
