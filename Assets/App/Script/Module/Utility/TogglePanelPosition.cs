using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Presto.Controller.Home;

namespace Presto.Module.Utility
{
    public class TogglePanelPosition : MonoBehaviour
    {
        public float x = 0;     // 本来の位置
        public float y = 0;     // 本来の位置

        void Awake()
        {
            // 本来の表示位置を記録する
            this.x = gameObject.GetComponent<RectTransform>().localPosition.x;
            this.y = gameObject.GetComponent<RectTransform>().localPosition.y;
            Debug.Log(string.Format("[x:{0}][y:{1}]", x, y));
        }

        // 表示/非表示
        public void Handle(Toggle t=null)
        {
            // PanelMainMenuListを戻す
            if (gameObject.name != "PanelMainMenuList")
            {
                float menu_x = BaseController.GetPanelWithTag("PanelMainMenuList").GetComponent<TogglePanelPosition>().x;
                float menu_y = BaseController.GetPanelWithTag("PanelMainMenuList").GetComponent<TogglePanelPosition>().y;
                BaseController.GetPanelWithTag("PanelMainMenuList").GetComponent<RectTransform>().localPosition = new Vector3(menu_x, menu_y, 0);
                BaseController.GetPanelWithTag("PanelMainMenuList").gameObject.SetActive(false);
            }

            // positionをint型に変更(float型だと小数点以下が不一致したりする)
            int current_x = (int)gameObject.GetComponent<RectTransform>().localPosition.x;
            int current_y = (int)gameObject.GetComponent<RectTransform>().localPosition.y;
            if ( (int)this.x == current_x && (int)this.y == current_y)
            {
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);  // 表示する(カメラの位置に戻す)
                gameObject.SetActive(true);  // 表示する
            }
            else
            {
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(this.x, this.y, 0);    //　非表示(元の位置に戻す)
                gameObject.SetActive(false);    // 非表示
            }
        }
    }
}
