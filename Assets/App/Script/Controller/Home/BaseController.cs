﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Linq;

namespace Presto.Controller.Home
{
    [RequireComponent(typeof(Canvas))]
    public class BaseController : MonoBehaviour
    {
        // 最大表示アイテム数
        public static readonly int ITEM_COUNT_MAX = 100;

        // 自画面の子パネル
        protected GameObject _PanelContent;     // メインパネル
        protected GameObject _PanelHeader;      // ヘッダー
        protected GameObject _PanelFooter;      // フッター

        // 全パネル一覧
        public static Dictionary<string, GameObject> Panels = new Dictionary<string ,GameObject>();

        public static GameObject GetPanelWithTag(string tag_name)
        {
            if (BaseController.Panels[tag_name])
            {
                return BaseController.Panels[tag_name];
            }
            else
            {
                GameObject obj = GameObject.FindWithTag(tag_name);
                BaseController.Panels[tag_name] = obj;
                return obj;
            }
        }

        public virtual void Awake()
        {
            this._PanelHeader = gameObject.transform.FindChild("PanelHeader") ? gameObject.transform.FindChild("PanelHeader").gameObject : null;
            this._PanelFooter = gameObject.transform.FindChild("PanelFooter") ? gameObject.transform.FindChild("PanelFooter").gameObject : null;
            this._PanelContent = gameObject.transform.FindChild("PanelContent").gameObject;

            if(BaseController.Panels.Count == 0)
            {
                BaseController.Panels = new Dictionary<string, GameObject> {
                    { "PanelHome", GameObject.FindWithTag("PanelHome") },
                    { "PanelMainMenuList", GameObject.FindWithTag("PanelMainMenuList") },
                    { "PanelCategoryEditList", GameObject.FindWithTag("PanelCategoryEditList") },
                    { "PanelKeywordList", GameObject.FindWithTag("PanelKeywordList") },
                    { "PanelKeywordEditList", GameObject.FindWithTag("PanelKeywordEditList") },
                    { "PanelConfirm", GameObject.FindWithTag("PanelConfirm") },
                    { "PanelUserProfile", GameObject.FindWithTag("PanelUserProfile") },
                    { "PanelSetting", GameObject.FindWithTag("PanelSetting") },
                };
            }
        }
    }
}
