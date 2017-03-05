using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;
using Presto.UI;
using Presto.Module.Utility;
using System.Linq;

namespace Presto.Controller.Home
{
    public class KeywordListController : Presto.Controller.Home.BaseController
    {
        public static GameObject[] KeywordObjArr = new GameObject[BaseController.ITEM_COUNT_MAX];
        public static JSONNode KeywordData;
        public static IEnumerable<JSONNode> currentMenuData;

        public Text TextWordDetail;
        public Image ImageWordDetail;

        public void RefreshKeywords(JSONNode json_node)
        {
            KeywordListController.KeywordData = json_node;

            // 初期化
            foreach(var data in KeywordListController.KeywordObjArr.Select((val, i) => new { val, i }))
            {
                Destroy(KeywordListController.KeywordObjArr[data.i]);
            }

            this.ImageWordDetail.enabled = false;
            this.TextWordDetail.text = "";

            // メニュー一覧の作成
            KeywordListController.currentMenuData = json_node.Children;
            foreach (var data in KeywordListController.currentMenuData.Select((val, key) => new { val, key }))
            {
                // TODO なんでループに入るか不明!!!!!!!!!多分snoが0からでないからかも
                if (data.val.Count <= 0)
                {
                    continue;
                }

                KeywordListController.KeywordObjArr[data.key] = Instantiate(Resources.Load("Prefab/UI/Keyword/Keyword") as GameObject);
                KeywordListController.KeywordObjArr[data.key].transform.SetParent(this._PanelContent.transform, false);
                 KeywordListController.KeywordObjArr[data.key].GetComponent<Keyword>().SetData(data.val);
            }
        }

        void CallbackAPI(JSONNode _jsonnode)
        {
            this.RefreshKeywords(_jsonnode);
        }

        public void RefreshPanel(int displayIndex=0, string str="")
        {
            this.ImageWordDetail.GetComponent<ToggleDisplay>().Show(null);    // 詳細内容表示にする
            this.TextWordDetail.text = str.Substring(0, 300 + 100*(displayIndex));
            // this.TextWordDetail.text = str.Substring(5000);
            if (this.ImageWordDetail.transform.GetSiblingIndex() < displayIndex)
            {
                this.ImageWordDetail.transform.SetSiblingIndex(displayIndex);  // ボタンの後に表示する
            }
            else
            {
                this.ImageWordDetail.transform.SetSiblingIndex(displayIndex + 1);  // ボタンの後に表示する
            }
        }

        // キーワード一覧の表示
        public void ShowListEdit()
        {
            BaseController.GetPanelWithTag("PanelKeywordEditList").GetComponent<KeywordEditListController>().RefreshPanel(KeywordListController.KeywordData);
        }

    }
}
