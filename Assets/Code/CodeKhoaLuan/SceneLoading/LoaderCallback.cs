using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    //class này chỉ nằm trong scene loading
    //sử dụng để mỗi khi hiển thị trang loading, sẽ gọi hàm callback để 
    //chạy ngầm việc load scene mới ở bên dưới
    bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallBack();
        }
    }
}
