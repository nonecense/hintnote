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
    public class KeywordEditListController : Presto.Controller.Home.BaseController
    {
        public Text TextCategoryName;
        public static GameObject[] MenuObjArr = new GameObject[100];
        public static IEnumerable<JSONNode> currentMenuData;

        public void RefreshPanel(JSONNode json_node)
        {
            // 初期化
            foreach (var obj in KeywordEditListController.MenuObjArr.Select((val, i) => new { val, i }))
            {
                Destroy(KeywordEditListController.MenuObjArr[obj.i]);
            }

            this.TextCategoryName.text = json_node["title"];

            // 一覧を表示
            KeywordEditListController.currentMenuData = json_node.Children;
            foreach (var data in KeywordEditListController.currentMenuData.Select((val,i) => new { val, i}))
            {
                KeywordEditListController.MenuObjArr[data.i] = Instantiate(Resources.Load("Prefab/UI/Keyword/KeywordEditField") as GameObject);
                KeywordEditListController.MenuObjArr[data.i].transform.SetParent(this._PanelContent.transform, false);
                KeywordEditListController.MenuObjArr[data.i].GetComponent<KeywordEditField>().SetData(data.val);
            }
        }

    }
}
