using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private RectTransform rect;
    //要跟随的物体
    private Transform rootTrans;

    private void Update() {
        //将 position 从世界空间变换为屏幕空间
        Vector3 screenPos = Camera.main.WorldToScreenPoint(rootTrans.position);
        //此 RectTransform 的轴心相对于锚点参考点的位置
        rect.anchoredPosition = screenPos;
    }
    //初始化函数
    public void InitItemInfo(Transform trans) {
        rect = transform.GetComponent<RectTransform>();
        rootTrans = trans;
    }
}
