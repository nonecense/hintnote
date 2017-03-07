using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;
using Presto.Controller.Home;
using Presto.Module.Utility;

namespace Presto.UI
{
    public class Keyword : Presto.UI.UIBase
    {
        public Text TextIcon;
        public Text TextTitle;
        public Text TextDesc;
        public int id = 1;
        public JSONNode Data;

        public void SetData(JSONNode json_node)
        {
            this.Data = json_node;
            this.id = this.Data["id"].AsInt;
            this.TextTitle.text = this.Data["title"];
            this.TextDesc.text = this.Data["desc"];
        }


        // TODO
        public void OnClickAction()
        {
            // WEBから検索結果を取得する
            StartCoroutine(Presto.Module.Server.CallAPI.GetString("http://ejje.weblio.jp/content/" + this.Data["title"], CallbackAPI));
        }

        void CallbackAPI(string html)
        {
            // this.ShowKeywordDetail(html);    // TODO 使わない
            this.ShowWebview(html);
        }

        public void ShowWebview(string html)
        {
            html = html.Substring(0,5000);
            BaseController.GetPanelWithTag("PanelWebView").GetComponent<TogglePanelPosition>().Show();
            BaseController.GetPanelWithTag("PanelWebView").GetComponent<WebViewController>().RefreshPanel(html);
        }

        // TODO 使わない
        public void ShowKeywordDetail(string html)
        {
            int displayIndex = gameObject.transform.GetSiblingIndex();
            BaseController.GetPanelWithTag("PanelKeywordList").GetComponent<KeywordListController>().RefreshPanel(displayIndex, html);
        }
    }
}
