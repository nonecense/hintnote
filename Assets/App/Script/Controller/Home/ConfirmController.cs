using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;
using Presto.UI;
using Presto.Module.Utility;

namespace Presto.Controller.Home
{
    public class ConfirmController : Presto.Controller.Home.BaseController
    {
        public Text TextConfirmMsg;

        // カテゴリ系操作
        public const int OK_ACTION_CATEGORY_SAVE   = 10001;
        public const int OK_ACTION_CATEGORY_DELETE = 10002;
        public const int OK_ACTION_CATEGORY_MOVE   = 10003;

        // キーワード系操作
        public const int OK_ACTION_KEYWORD_SAVE    = 20001;
        public const int OK_ACTION_KEYWORD_DELETE  = 20002;
        public const int OK_ACTION_KEYWORD_MOVE    = 20003;

        public int action = 0;  // アクション情報
        public void SetAction(int _action = 0, string _msg="よろしいでしょうか？")
        {
            this.action = _action;
            this.TextConfirmMsg.text = _msg;
        }

        public void SetMessage(string _msg = "")
        {
            this.TextConfirmMsg.text = _msg;
        }

        // OKボタンが押下された場合
        public void OnClickOkButton()
        {
            Debug.Log("Action No:"+action);
            switch (this.action)
            {
                case ConfirmController.OK_ACTION_CATEGORY_SAVE:
                    // 修正内容を保存
                    BaseController.GetPanelWithTag("PanelCategoryEditList").GetComponent<CategoryEditListController>().SaveAllEditData();
                    break;
                case ConfirmController.OK_ACTION_CATEGORY_DELETE:
                    BaseController.GetPanelWithTag("PanelCategoryEditList").GetComponent<CategoryEditListController>().SaveAllEditData();
                    break;
                default:
                    break;
            }

            // Confirmパネルの表示を切り替える
            gameObject.GetComponent<TogglePanelPosition>().Handle();
        }

    }
}
