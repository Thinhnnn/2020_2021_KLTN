using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    //dummy class - class bù nhìn: LoadingMonoBehaviour
    //class LoadingMonoBehavior được tạo ra để sử dụng hàm StartCoroutine() của MonoBehaviour
    //vì Loader là class static nên không kế thừa từ MonoBehaviour
    //cho nên muốn gọi hàm StartCoroutine(), cần sự hỗ trợ của class bù nhìn này
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene
    {
        Menu,
        LoadingScene,
        Level1_Mercury,
        Level2_Venus,
        Level3_Earth,
        Level4_Mars,
        Level5_Jupiter,
        Level6_Saturn,
        Level7_Uranus,
        Level8_Neptune
    }

    static Action onLoaderCallBack;                 //trigger loader call back
    static AsyncOperation loadingAsyncOperation;    //biến giám sát tiến trình chạy không đồng bộ

    public static void Load(Scene scene)
    {
        //setup lệnh callback này để gọi chạy ngầm hàm load scene muốn load
        onLoaderCallBack = () => 
        {
            //tạo ra class bù nhìn để gọi hàm StartCoroutine()
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
            //SceneManager.LoadScene(scene.ToString());
        };
        //trong khi load scene chạy ngầm, trên bề mặt sẽ hiển thị giao diện load scene
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    static IEnumerator LoadSceneAsync(Scene scene)  //async : không đồng bộ
    {
        yield return null;  // ngưng 1 nhịp

        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        //nếu quá trình chạy ngầm chưa xong:
        while (!loadingAsyncOperation.isDone)
        {
            yield return null;  //ngưng 1 nhịp
        }
    }

    public static float GetLoadingProgress()
    {
        //hàm trả về tiến trình chạy được bao nhiêu (từ 0f tới 1f)
        if (loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 0f;
        }
    }

    public static void LoaderCallBack()
    {
        //hàm này để làm mới việc chạy ngầm
        //nếu đang có chạy ngầm, chạy ngầm load scene xong thì cho nó bằng null để không chạy ngầm nữa
        if (onLoaderCallBack != null)
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }
}
