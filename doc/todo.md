* 昵称随机规则
* local space 和 world space, 矩阵
* gradle 日志
* 签名文件
* 系统管理
* 关闭应用程序
* jekins
* Timer的使用
> 		Timer timer = new Timer((obj) =>
			{
				gateSocket.update();
			},null,0,33);

* 混淆
* 矩阵
* 头标加载
* ui/player_icon 变量
* 恢复摄像机 角度
* 随机宝箱位置
* 获取经纬度
* 摄像机背景
* http://www.360doc.com/content/16/0313/12/13726687_541802098.shtml
* http://api.map.baidu.com/lbsapi/getpoint/index.html
* 连接服务器卡死
* 签名文件
* 不Update模式
* 错误提示信息打印
* 手机wlan
* 选择性别区域放大
* 宝箱做成prefab资源加载
* Gyro动态挂载
* 底部按钮未选中
* 红点渐大
* 界面未关闭，在有时奇怪的回弹出来
* 编译时错误消息查看，cmd窗口不跳
* 昵称输入框不要太大
* 预先加载图标，prefab
* git 操作
* 宝箱CD重新设计

----
> 使用随游戏资源方式:
	1. StreamingAssets目录
		AssetsBundles
		files.txt

	2. NO LCL_LOCAL 宏

	3. GameUpdateManager 115 `WWW www = new WWW(resPath + infile)`

使用Web服务器更新方式:
	1. LCL_LOCAL 宏

	2. Utility.cs WebUrl地址

* 怎么把数量带进去 
* item 表中的 image 不带扩展名
* https://github.com/chiuan/TTUIFramework
* GameNetworkManager把接收到的宝箱数据广播  =>  GyroCameraManager把得到的数据重新组织(得到配置数据，和数量组合成object[] => object) =>
  UIManager加载需要的图标 => ARPanel显示

* 字典key to list
        List<int> keys = new List<int>(ConfigReader.ItemConfigDic.Keys);

       IEnumerator<Toggle> toggleEnum = myToggleGroup.ActiveToggles().GetEnumerator();
 toggleEnum.MoveNext();
 Toggle toggle = toggleEnum.Current;



 那怎么样才能建立一个.htaccess这样的无文件名，只有后缀的文件呢？洪哥这里有一个最简单的办法。

打开一个Windows Notepad（记事本工具），在记事本中输入好你打算放到.htaccess文件中的内容。然后点击“文件”->“另存为...”，这时会弹出的“另存为”对话框，在其“文件名”一栏中输入".htaccess"。注意，这里必须用一对英文模式下的双引号把.htaccess引起来。然后点击“确定”即可将记事本中的内容保存到一个名为.htaccess的文件中。


* vnc 
> 192.168.1.119
123456
paopao
nikugame


696bcd42-684a-11e6-87b0-69e4776155a6
696bcd42-684a-11e6-87b0-69e4776155a6
50d4e652-6849-11e6-87b0-69e4776155a6

* 逗号的处理，csv是用,分隔的，字符串如果有逗号
* 冒号的征处理如, 昵称:
* 区分不需要中英文的情况， 比如输入框
* SerializeField


ui 摄像机没有显示出来原因：
	Near
	Far


* xls2csv:
http://www.unity.5helpyou.com/2946.html

* 事件广播, not active 优化处理

1st gen, 3g & 3gs

portrait: 320x480

4 & 4s

portrait: 640x960

5, 5c & 5s

portrait: 640x1136

6

portrait: 750x1334

6 plus

portrait: 1242x2208

6 plus down-sampled

portrait: 1080x1920



    static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }


二维码：

            options = new QrCodeEncodingOptions  
            {  
                DisableECI = true,  
                CharacterSet = "UTF-8",  
                Width = pictureBoxQr.Width,  
                Height = pictureBoxQr.Height  
            };  


            下面用文本输入框作为二维码的信息来源，再添加一个按钮作为触发。发明一个MultiFormatWriter用于二维码写入用，用其encode方法生成一个ByteMatrix类。再用ByteMatrix的方法ToBitmap成生bitmap对象，最后得到bitmap的数组再赋值于texture2d。在这里我定义了一个ImageToByte提取bitmap的数组。因为是UI事件，所以我们把代码写到OnGUI中。

voidOnGUI()
{
    input = GUI.TextField(newRect(100, 50, 100, 40), input);
    if(GUI.Button(newRect(100, 100, 100, 40), "生成"))
    {
            byteMatrix = newMultiFormatWriter().encode(input, BarcodeFormat.QR_CODE, _width, _height);
            _texure2d.LoadImage(ImageToByte(byteMatrix.ToBitmap()));
            _success = true;
    }
    //画图
    if(_success) GUI.DrawTexture(newRect(100, 300, 300, 300), _texure2d);
}
staticbyte[] ImageToByte(Image img)
{
    ImageConverter converter = newImageConverter();
    return(byte[])converter.ConvertTo(img, typeof(byte[]));
}

http://gubbl.com/2015/12/17/continuous_qr/

https://github.com/DHMechatronicAG/ZXing.Net/blob/master/Clients/UnityDemo/Assets/BarcodeCam.cs

ReadPixels was called to read pixels from system frame buffer, while not inside drawing frame.


ReadPixels 是从左下角开始的。
而其所在的坐标系也是左下角为原点的！

IOSSDKLogin
Clip
Automatic


- ( void ) imageSaved: ( UIImage *) image didFinishSavingWithError:( NSError *)error   
    contextInfo: ( void *) contextInfo; 


sdk把异常情况加入

个人升级

脚本Additive to Mobile Additive

升级特效少liuguang


Can't create handler inside thread that has not called Looper.prepare()

解决方法 :
http://forum.unity3d.com/threads/plugin-exception-cant-create-handler-inside-that-has-not-called-looper-prepare.227491/


public void CopyTextToClipboard(final String text)
{
	UnityPlayer.currentActivity.runOnUiThread(new Runnable() 
	{
		public void run()
		{
			ClipboardManager clipboardManager = (ClipboardManager)getSystemService( Context.CLIPBOARD_SERVICE);  
			clipboardManager.setPrimaryClip(ClipData.newPlainText(null, text));  
		}
	});
}

打包流程:
    资源打包会有问题经常会出现在ios上无法加载的问题，应该是某些缓存的缘故

先打一个带Reporter的包
ios修改   Framework Search Path 


皮肤购买成功不显示为已经购买！！！
商店界面第一次加载

 iphone上镜像，不会抖动， 会出现多次相同的角度，所以感觉有多个
 android上抖动，表现为飘走到镜头外


 https://developer.vuforia.com/user
 dufang695@163.com
 4字母6数字 1大


 1433.815


 ;;(setq url-proxy-services
;;  ("http"."proxy.seso.me:63028")
;;  ("https"."proxy.seso.me:63028"))



;;(setq url-using-proxy t)
;;(setq url-proxy-services '(("http" . "proxy.seso.me:63028")))

~~打开宝箱特效加入~~
商店第一次加载过慢解决
宝箱显示在摄像机前面， 在一开始
连续购买卡顿
随机名字库替换
弹出框数量限制
资源解压显示进度
添加 Tick 句柄
iphone 镜像
~~添加名字数量和进度~~
~~Fixed layer关系~~

* 需要中英转换:
    服务器发来的网络消息提示



noproc -> 没有在supervisor中声明
gen_tcp:controlling_process -> 函数名字写错

升级成功文字替换、
升级动画进度条位置调整

优化:
> https://forums.tigsource.com/index.php?topic=52471.0


Mathf.Lerp(a, b, eltime / alltime)

粒子前面无法旋转文字可能是某张背景图影响

华为
//            Debug.logger.logEnabled = false;
打开宝箱动画大小适配
检查无用 本地化脚本

ShareSDK:
    http://blog.csdn.net/qq15233635728/article/details/43226621
    微信好友  
    威信朋友圈  
    QQ空间 
    sina微博

    需要到新浪开放平台注册、申请成为开发者、创建应用、填写应用详情、初步审核（审核中有张截图必须含有新浪分享标志，否则不通过）、下载地址填写上面的预判地址。注册得到appkey等，如果你的应用还没有上线，那就意味着下载地址是不可用的。你申请的appkey可以暂用，分享时会出现界面，但是分享不成功，报错大约就是没有审核成功云云。这个不用担心，等到真正应用上架，就可以正常分享。就是说，代码事先可以写好，只要ios审核过了，并且发布。我们就能马上在新浪进行二次审核，上架广场。分享也随之正常，不再报错。

App Key:
    16c10d92c6529
App Secret:
    1376b18139a5aab919bc4a0a65156c83

微信:
    APP ID：
        wx45fe25962c2b07a8    
    APP SECRET：
        870117c275472dfebb7e61354e8ddfb1
    
新浪：
    App Key：1094180289
    App Secret：0645b26e4c222714d78634066cfb2c1f
    
腾讯：
   APP ID：1105701334
   APP KEY：vITTFATrvONvND7f

ShareSDK:
    IOS
        App Key: 17cf0a6b69b26
        App Secret: 8d61d34c6811315fafcff13943ec03fe
    Android
        App Key: 17cf266c4b154
        App Secret: 0c675c11e61dbb669e67b249a1647f3c


https://github.com/dcariola/XCodeEditor-for-Unity

分行：

    shareTexts = text.text.Split(new char[]{ '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

Spacemacs 技巧搜集:
    http://spacemacs.brianthicks.com/

HOME:
    C:\Users\Administrator\spacemacs

    cd C:\Users\Administrator\spacemacs

    git clone https://github.com/syl20bnr/spacemacs .emacs.d

    HOME里不要有.emacs文件
    
##帧同步：
---------
- http://jjyy.guru/unity3d-lock-step-part-1
- http://jjyy.guru/unity3d-lock-step-part-2
- http://gad.qq.com/article/detail/7169916

切换账号


显示行号，修改配置文件中的：

`dotspacemacs-line-numbers t`

DOTween.To(() => myVector, x => myVector = x, new Vector3(3, 4, 8), 1);

## 滑动:
----
http://answers.unity3d.com/questions/776667/can-a-scroll-rect-snap-to-elements.html

https://github.com/ludidilu/FinalWar_client/blob/bad59c8458d4eec66dcf4cca344a1e2136c4240e/Assets/Scripts/lib/superList/SuperPageScrollRect.cs

https://github.com/zahirenno/Assets/blob/5bdc7d13c053865a8556ea104f890b063c3f122a/UICode/PagedScrollView.cs

安卓手机相册路径
    `String path = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DCIM).getPath();`

Webcam.ProcessImage

WaitingForJob

Static Collider.Move -> rotate child without collider

关闭Log:

    Debug.logger.logEnabled = false;

图片需要在 `Advanced` 模式下设置可读写
需要勾选 `Alpha Is Transpart` 不然后AssetBundle打包之后无法识别
    => 不用如此也可以
    => 如此之后，图片后面的会模糊地显示出来

MainScrollManager 动态添加

引用图片的组件要设置为空,这样图片资源才能被释放
```
imgProgress = this.transform.FindChild("Image_Progress").GetComponent<Image>();
imgProgress = null
```


AssetBundle管理：
    https://unity3d.com/cn/learn/tutorials/topics/best-practices/assetbundle-usage-patterns


确认框背景屏蔽点击

1. 更新不透明贴图的压缩格式为ETC 4bit，因为android市场的手机中的GPU有多种，每家的GPU支持不同的压缩格式，但他们都兼容ETC格式，
2. 对于透明贴图，我们只能选择RGBA 16bit 或者RGBA 32bit。
3. 减少FPS，在ProjectSetting-> Quality中的VSync Count 参数会影响你的FPS，EveryVBlank相当于FPS=60，EverySecondVBlank = 30；
这两种情况都不符合游戏的FPS的话，我们需要手动调整FPS，首先关闭垂直同步这个功能，然后在代码的Awake方法里手动设置FPS（Application.targetFrameRate = 45;）
   降低FPS的好处：
 1）省电，减少手机发热的情况；
 2）能都稳定游戏FPS，减少出现卡顿的情况。
4. 当我们设置了FPS后，再调整下Fixed timestep这个参数，这个参数在ProjectSetting->Time中，目的是减少物理计算的次数，来提高游戏性能。
5. 尽量少使用Update LateUpdate FixedUpdate，这样也可以提升性能和节省电量。多使用事件（不是SendMessage，使用自己写的，或者C#中的事件委托）。
6. 待机时，调整游戏的FPS为1，节省电量。

```
ResourceManager.Instance.UnloadAssetBundle("ui/shoppanel.unity3d");
ResourceManager.Instance.UnloadAssetBundle("ui/mainpanel.unity3d");
ResourceManager.Instance.UnloadAssetBundle("ui/player_icon.unity3d");
ResourceManager.Instance.UnloadAssetBundle("ui/skin_icon.unity3d");
ResourceManager.Instance.PrintLoaded();
```

手机UI卡，发热

ScrollRect LateUpdate:

    Instantiate prefabs in a loading screen reduced the time to open the Scroll View.
    
牛皮

many different work

find fit me

spacemacs 切换主题：`SPC T h`

LockStep:

    https://github.com/InkhornGames/lockstep.io
    
    
Make Game

    Hit And Run
    
把做的东西做成工具集，写文档，教新手

PreLoad 1 -> 2 -> 3 -> 4

分享不同 custom
分享重启

点击战斗后，滑动取消

Invalid AABB inAABB
    ScrollRect 下面有 Slider的Interactable属性为 True
    
公告超时处理
Tick 移除

`tasklist | findstr something`
`netstat -ano | findstr PID`

加装备 加号
商店，AR图标 
商城定位到具体的物品
资源统一管理
适配
商店UI替换
ItemConfig Utf-8
商城不显示进度
代理导致无法访问本机文件服务器

//download = WWW.LoadFromCacheOrDownload(url, m_AssetBundleManifest.GetAssetBundleHash(abName), 0);
download = new WWW(url);

主界面图标
精灵界面预览，粒子会在前面
未获取，出战按钮不显示
购买成功后，精灵数据未刷新，
界面进入，界面退出事件
粒子移除
outline 

继续搜索 -》 回主界面
创建角色头像框， 框不拉伸
AR分享内容配置

下载后无法进入游戏
AR红点
shop isGot

战斗UI替换
创建角色UI替换
皮肤，商城界面加载慢

描边:
    8349c0
    5034c7
    ff6a2d  -> 快速开始

ugui Deactive Active 会很产生委多GC, 通过改变localScale会好些，不知有没有其他的问题

drawcall:
    mask
    
CPU:
    Debug
    static collider move
    
图片分类

查看内存中相同的纹理

AR界面卡
font 打包

Code
----

 ScreenLocate.cs
 ```
using UnityEngine;
using System.Collections;
using TinyTeam.UI;

public class ScreenLocate : MonoBehaviour 
{
//    public float percentFromBottom = 0.125f;
	void Start() 
    {
//        Vector3 pos1 = TTUIRoot.Instance.uiCamera.ScreenToWorldPoint(new Vector3(0, Screen.height * percentFromBottom, 0));
//        Vector3 pos2 = transform.position;
//        pos2.y = pos1.y;
//        transform.position = pos2;
	}
}
 ```


优化
----

 * http://www.theappguruz.com/blog/unity-optimization-initiative

 * Graphic Raycaster
 * 内存查看重复纹理打包一次，UI前加载
 * 图片大小4的倍数，可以压缩
 * CanvasRenderer.OnTransformChanged
   * Camera -> Overlay
   * ScrollRect 
 * 
 
TODO
----

 * UITool SetActive
 * 服务器关闭时没有显示提示
 * 把界面退出之后再销毁测试
 * UI ScreenToWorldPoint
 * 加快编译速度方法
 * NKSDK XCode 对接文档
 * 提示信息
 
DONE
----

 * 皮肤商城记住滑动前坐标
 * Little Title
 
GOT
----
 
`AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/UI/1.png")` LoadAssetAtPath
路径参数要以`Assets`开头

http://blog.uwa4d.com/archives/TechSharing_25.html


测试
----

 * 不把UI层放在摄像机下面，效果会好些，
 
 
备注
----

 * 玩家图标，皮肤图片要设置为 Read/Write Enabled， 分享
 * 764a870fb0f48bb7bbde5508e59ebd87
 * keytool -list -v  -keystore signature_mantapps.store
 
个推
----
 * a67126d905f8b596df4aead1a6df7e74

 * Utility:
    `return "file:///" + Application.dataPath.Replace("Assets", "");`

预览 关闭特效

特效和ui层次

进入大厅时机修改

个推ios接入

stackoverflow 快速

等级动画加入

商店优化

IPAD ShareSDK 微信不显示

 * 生成ipa:

    `zip -qr ppjl.ipa Payload/`


 * 查看apk MD5

    解压apk
    `keytool -printcert -file META-INF/CERT.RSA`

 * xcode 本地化

    创建Localizable.strings

#if !UNITY_EDITOR
//            Debug.logger.logEnabled = false;
#endif
      

结算：
    已关注 点击 无反应

Mac 下Editor目录下SDKPorter文件夹包含一键打包功能的东西

目录下的ShareSDK.zip文件中包含必要的相应平台的库文件，不需要的解压删除后重新压缩

它解压后的目录没有删除，在XCProject.cs文件加入代码


优化Tip:

    https://developer.microsoft.com/en-us/windows/holographic/performance_recommendations_for_unity#use_the_fastest_quality_settings
    
    http://blog.csdn.net/game_jqd/article/details/46928747


    Graphics.PresentAndSync:
        http://blog.uwa4d.com/archives/presentandsync.html


CDN 关闭情况

图片只接受 Raycast 换成Empty4Raycast
Mask 用 RectMask2D 代替

Canvas.SendWillRenderCanvases()
    

Camera上挂的Effect 动态

Outline多了会有问题

社交换皮

不关闭其他应用的声音

 A. Device.Present: 
      1.GPU的presentdevice确实非常耗时，一般出现在使用了非常复杂的shader.
      2.GPU运行的非常快，而由于Vsync的原因，使得它需要等待较长的时间.
      3.同样是Vsync的原因，但其他线程非常耗时，所以导致该等待时间很长，比如：过量AssetBundle加载时容易出现该问题.
      4.Shader.CreateGPUProgram:Shader在runtime阶段（非预加载）会出现卡顿(华为K3V2芯片).

个推 ios 版本接入


腾讯CDN
https://console.qcloud.com/cos
64630577
Xianren+789+

找到
第一次登录或者创建角色慢
原因
创建角色随机
宝箱移动到底部后晚一点消失
effect 500


核心购买限制数量

商城购买刷新机制变动， 不Active , 数量不变
OnTransformParentChanged()
OnBeforeTransformParentChanged()

特效Unload

the dependency is not available, run "mix deps.get"

审核Android包 LCL_LOCAL

http://news.qq.com/a/20161023/007438.htm?pgv_ref=aio2015&ptlang=2052


升级界面弹出两次

推送

公告？ ipad

分享游戏朋友 重启


图片的引用查看


if (AllEntitys_Client.Count == 0)
    return;

List<int> keys = new List<int>(AllEntitys_Client.Keys);
for (int i = 0; i < keys.Count; i++)
{
    int key = keys[i];
//          foreach(Int32 key in new List<Int32>(AllEntitys_Client.Keys))
//          {



其他玩家信息名字信息， 位置居中 

中文

SDK

不足重复

ios 推送 角

Android SDK 问题
    1. classes.jar 和 unity-classes.jar 文件冲突
    2. 微信登录文件和设置
        如果微信登录返回uuid为空，查看 LoginHost=new.login.nikugame.com 设置
        config/assets/config.properties `Wechat_APPID=wx45fe25962c2b07a8` 申请的APPID
        微信登录crash:
        src/com/nikugame/ppjl/wxapi/WXEntryActivity.java 包名

    3. 


const config

en cn size 


1.最上层的UI加一个Canvas 设置Layer 
    如果这个UI是滚动栏的一部分

C:\ProgramData\Oracle\Java\javapath


1094180289
0645b26e4c222714d78634066cfb2c1f
http://www.sharesdk.cn

wx45fe25962c2b07a8


115.159.213.208
uftp
Nikugam@20161107

两个向量点积返回的是一个值，为正, >0 , 角度为(0, PI/2), 为负, <0,角度为(PI/2, PI)

箱子贴图
先聚会场景后mingame


第一，对于每一个人都要有深刻的理念，就是这个世界一定是由技术所驱动的；

第二，遇到一个问题，要考虑下是不是有人已经解决了？我是不是可以把更好的时间去做更好的创新上？

第三，做一件事情，就一定要做到最优，做到行业最好；

第四，我会把自己当成一个软件，今天的版本一定要比昨天好，明天的一定要比今天好；

第五，发现一个明显的bug，不要问别人，马上去解决它。我觉得这是对技术追求最好的总结，对于一个工程师来说，无论在工作还是生活中都具有指导意义，它要求我们追求卓越，自律与高效。

id integer
question string （题目）
category integer (分类，数学，经济)
type tinyint (单选，多选，判断，填空，问答)
level tinyint (简单，困难，地狱)
option string json (选择题选项)
answer string 答案
date :datetime 日期

mix phx.gen.html Questions Question questions name:string option:array:string answer:string date:datetime 