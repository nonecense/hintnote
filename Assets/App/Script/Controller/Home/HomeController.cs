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
    public class HomeController : Presto.Controller.Home.BaseController
    {
        public GameObject FooterUpperButton;
        public GameObject FooterReloadButton;

        public static int currentLevel = 0;
        public static JSONNode MenuNode = null;
        public static JSONNode[] treeData = new JSONNode[10];
        public static GameObject[] MenuObjArr = new GameObject[BaseController.ITEM_COUNT_MAX];


        public override void Awake()
        {
            base.Awake();
            this.LoadMasterData();
        }

        // 
        void CallbackAPI(JSONNode json_node)
        {
            this.RefreshPanel(json_node.Children.First().Children.First());
        }

        // 
        public void LoadMasterData(string parametors="")
        {
            //StartCoroutine(Presto.Module.Server.CallAPI.Get("http://presto:8080/app/dict/top/category/", CallbackAPI));
            this.RefreshPanel(Cache.LoadCategory());
        }

        // 画面再表示
        public void RefreshPanel(JSONNode json_node)
        {
            // 初期化
            foreach (var data in HomeController.MenuObjArr.Select((val, i) => new { val, i }))
            {
                Destroy(HomeController.MenuObjArr[data.i]);
            }

            if(json_node == null)
            {
                return;
            }

            HomeController.currentLevel = json_node.Children.First()["level"].AsInt;
            HomeController.MenuNode = json_node;
            HomeController.treeData[HomeController.currentLevel] = HomeController.MenuNode;

            // 戻るボタンの表示
            if (HomeController.currentLevel > 0)
            {
                this.FooterUpperButton.GetComponent<ToggleDisplay>().Show();
            }else
            {
                this.FooterUpperButton.GetComponent<ToggleDisplay>().Hide();
            }
                

            // メニュー一覧の作成
            foreach (var data in HomeController.MenuNode.Children.Select((val, i)=> new { val, i }))
            {
                HomeController.MenuObjArr[data.i] = Instantiate(Resources.Load("Prefab/UI/Home/Menu") as GameObject);
                HomeController.MenuObjArr[data.i].transform.SetParent(this._PanelContent.transform, false);
                HomeController.MenuObjArr[data.i].GetComponent<Menu>().SetData(data.val);
            }
        }

        // Homeボタン
        public void OnClickHomeButton(Toggle t)
        {
            this.RefreshPanel(Cache.LoadCategory());

            foreach (var i in BaseController.Panels.Keys)
            {
                if (BaseController.Panels[i])
                {
                    float __x = BaseController.Panels[i].GetComponent<TogglePanelPosition>().x;
                    float __y = BaseController.Panels[i].GetComponent<TogglePanelPosition>().y;
                    BaseController.Panels[i].GetComponent<RectTransform>().localPosition = new Vector3(__x, __y, 0);
                    if (BaseController.Panels[i].name != "PanelHome")
                    {
                        BaseController.Panels[i].SetActive(false);
                    }
                }
            }
        }

        // リロードボタン
        public void OnClickReload(Toggle t)
        {
            this.RefreshPanel(Cache.LoadCategory());
        }

        // 親フォルダの表示
        public static JSONNode _parentData = null;
        public void OnClickUpperButton()
        {
            if (HomeController.currentLevel == 0)
            {
                return;
            }

            this.RefreshPanel(HomeController.treeData[HomeController.currentLevel - 1]);
        }

        // 編集ボタン
        public void ShowListEdit()
        {
            BaseController.GetPanelWithTag("PanelCategoryEditList").GetComponent<CategoryEditListController>().RefreshPanel(HomeController.MenuNode);
        }

    }
}
