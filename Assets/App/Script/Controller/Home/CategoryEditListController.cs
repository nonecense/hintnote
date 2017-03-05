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
    public class CategoryEditListController : Presto.Controller.Home.BaseController
    {
        public Text TextCategoryName;
        public static GameObject[] menuObjs = new GameObject[100];
        public static JSONNode Data = null;

        public override void Awake()
        {
            base.Awake();
            this.RefreshPanel(CategoryEditListController.Data);
        }

        public void RefreshPanel(JSONNode json_node)
        {
            for (int i = 0; i < 100; i++)
            {
                Destroy(CategoryEditListController.menuObjs[i]);
            }

            CategoryEditListController.Data = json_node;
            if(CategoryEditListController.Data == null)
            {
                return;
            }

            foreach (var data in CategoryEditListController.Data.Children.Select((val,key)=>new { val, key}))
            {
                CategoryEditListController.menuObjs[data.key] = Instantiate(Resources.Load("Prefab/UI/Keyword/CategoryEditField") as GameObject);
                CategoryEditListController.menuObjs[data.key].transform.SetParent(this._PanelContent.transform, false);
                CategoryEditListController.menuObjs[data.key].GetComponent<CategoryEditField>().SetData(data.val);
            }
        }


        // 全部保存ボタンが押下された場合
        public void ClickSaveAllButton()
        {
            string msg = "編集したカテゴリデータを保存しますか？\n\n";
            BaseController.GetPanelWithTag("PanelConfirm").GetComponent<Presto.Module.Utility.TogglePanelPosition>().Handle();
            BaseController.GetPanelWithTag("PanelConfirm").GetComponent<ConfirmController>().SetAction(ConfirmController.OK_ACTION_CATEGORY_SAVE, msg);
        }

        // TODO 編集内容の保存
        public void SaveAllEditData()
        {

            // キャッシュの更新処理
            foreach(var data in CategoryEditListController.Data.Children.Select((val, key) => new { val, key }))
            {
                // TODO
                string edit_txt = CategoryEditListController.menuObjs[data.key].GetComponent<CategoryEditField>().InputfieldTitle.text;
                if ( ! Presto.Module.Utility.String.Equal(data.val["title"], edit_txt))
                {
                    // CategoryEditListController.menuObjs[i]
                    Debug.Log(data.key + ":::不一致。。。。。" + CategoryEditListController.menuObjs[data.key].GetComponent<CategoryEditField>().InputfieldTitle.text);
                }
            }

            Cache.SaveCategory(CategoryEditListController.Data);    // キャッシュデータの更新

            gameObject.GetComponent<TogglePanelPosition>().Handle();    // 編集パネルを閉じる
            BaseController.GetPanelWithTag("PanelHome").GetComponent<HomeController>().RefreshPanel(CategoryEditListController.Data);    // TODO カテゴリ一覧を更新
            // this.PanelConfirm.GetComponent<Presto.Module.Utility.TogglePanelPosition>().Handle();    // 確認画面を閉じる
        }


        // TODO カテゴリの削除
        public void DeleteCategory()
        {
            if(CategoryEditListController.Data.Count == 0)
            {
                // サブ目録がない場合は、削除
            }
            else
            {
                // サブ目録がある場合は、確認後削除
            }
        }

    }
}
