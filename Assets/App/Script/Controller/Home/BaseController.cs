using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Linq;

namespace Presto.Controller.Home
{
    public class BaseController : Presto.Controller.BaseController
    {
        // 最大表示アイテム数
        public static readonly int ITEM_COUNT_MAX = 100;

        // 自画面の子パネル
        protected GameObject _PanelContent;     // メインパネル
        protected GameObject _PanelHeader;      // ヘッダー
        protected GameObject _PanelFooter;      // フッター

        // 全パネル一覧
        public static Dictionary<string, GameObject> Panels = new Dictionary<string ,GameObject>();

        // タグ名で任意パネルを取得
        public static GameObject GetPanelWithTag(string tag_name)
        {
            if (!BaseController.Panels.ContainsKey(tag_name) || !BaseController.Panels[tag_name])
            {
                BaseController.Panels[tag_name] = GameObject.FindWithTag(tag_name);
            }
            return BaseController.Panels[tag_name];
        }

        public virtual void Awake()
        {
            this._PanelHeader = gameObject.transform.Find("PanelHeader") ? gameObject.transform.Find("PanelHeader").gameObject : null;
            this._PanelFooter = gameObject.transform.Find("PanelFooter") ? gameObject.transform.Find("PanelFooter").gameObject : null;
            this._PanelContent = gameObject.transform.Find("PanelContent").gameObject;

            if(BaseController.Panels.Count == 0)
            {
                BaseController.Panels = new Dictionary<string, GameObject> {
                    { "PanelHome", GameObject.FindWithTag("PanelHome") },
                    { "PanelMainMenuList", GameObject.FindWithTag("PanelMainMenuList") },
                    { "PanelCategoryEditList", GameObject.FindWithTag("PanelCategoryEditList") },
                    { "PanelKeywordList", GameObject.FindWithTag("PanelKeywordList") },
                    { "PanelKeywordEditList", GameObject.FindWithTag("PanelKeywordEditList") },
                    { "PanelWebView", GameObject.FindWithTag("PanelWebView") },
                    { "PanelConfirm", GameObject.FindWithTag("PanelConfirm") },
                    { "PanelUserProfile", GameObject.FindWithTag("PanelUserProfile") },
                    { "PanelSetting", GameObject.FindWithTag("PanelSetting") },
                };
            }
        }
    }
}
