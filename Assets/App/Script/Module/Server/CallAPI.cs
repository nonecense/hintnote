using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

namespace Presto.Module.Server
{
    public class CallAPI : MonoBehaviour
    {
        /*
         * 先頭がhttp開始の場合はそのまま
         */
        public static string URL(string url)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(url, @"^http", System.Text.RegularExpressions.RegexOptions.ECMAScript))
            {
                Debug.Log("is http");
                return url;
            }
            else
            {
                Debug.Log("is not http");
                return Presto.Config.CONFIG.API_BASE_URL + url;
            }
        }

        public static IEnumerator GetString(string url, System.Action<System.String> callback)
        {
            Debug.Log("*********************** GET ************************");

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.Send();    // リクエスト送信

            Debug.Log("#######response:" + request.responseCode);
            Debug.Log("#######response data:" + request.downloadHandler.data);
            Debug.Log("#######response text:" + request.downloadHandler.text);

            // 通信エラーチェック
            if (request.isError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (request.responseCode == 200)
                {
                    byte[] results = request.downloadHandler.data;  // バイナリデータとして取得する
                    callback(request.downloadHandler.text);         // callbackを呼び出す
                }
            }

            Debug.Log("*********************** GET END");
        }

        public static IEnumerator Get(string url, System.Action<JSONNode> callback)
        {
            Debug.Log("*********************** GET ************************");

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.Send();    // リクエスト送信

            Debug.Log("#######response:" + request.responseCode);
            Debug.Log("#######response data:" + request.downloadHandler.data);
            Debug.Log("#######response text:" + request.downloadHandler.text);

            // 通信エラーチェック
            if (request.isError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (request.responseCode == 200)
                {
                    byte[] results = request.downloadHandler.data;  // バイナリデータとして取得する
                    Debug.Log(request.downloadHandler.text);
                    JSONNode responseJSONNode = JSON.Parse(request.downloadHandler.text);
                    Presto.Module.Utility.Cache.SaveAllCategory(responseJSONNode);   // TODO 全カテゴリデータをキャッシュ
                    callback(responseJSONNode);         // callbackを呼び出す
                }
            }

            Debug.Log("*********************** GET END");
        }
    }

}
