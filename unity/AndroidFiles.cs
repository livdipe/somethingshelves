using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class AndroidFiles : MonoBehaviour 
{   
    const string searchPattern = "*.mp3";
    int cnt = 0;
    public GameObject prefab;
//    StringBuilder builder = new StringBuilder();
    IEnumerator Start () 
    {
        yield return new WaitForSeconds(1);
        Debug.LogError("Start Search");

        #if UNITY_EDITOR
        string dirPath = Application.dataPath + "/";
        #elif UNITY_ANDROID
        string dirPath = "/storage/emulated/0/netease/cloudmusic/Music/";
        #endif

        DirFiles(dirPath);
        Debug.LogError("End Search");
	}

    void DirFiles(string dirPath)
    {
        string[] dirs = Directory.GetDirectories(dirPath);
        for (int i = 0; i < dirs.Length; i++)
        {
            DirFiles(dirs[i]);
        }
        string[] files = Directory.GetFiles(dirPath, searchPattern);
        for (int i = 0; i < files.Length; i++)
        {
//            builder.AppendLine(files[i].Replace("\\", "/"));
            cnt ++;
            Spawn(cnt.ToString() + "=>" + files[i].Replace("\\", "/"));
        }
    }

    void Spawn(string content)
    {
        GameObject obj = GameObject.Instantiate(prefab) as GameObject;
        obj.SetActive(true);
        obj.transform.SetParent(prefab.transform.parent);
        obj.transform.localScale = Vector3.one;
        Text text = obj.GetComponent<Text>();
        text.text = content;
    }
}
