using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using SimpleJSON;


namespace Presto.Module.Utility
{
    public class CacheConfig
    {
        public const string ROOT                    = "/Datas/Cache/hintnote/";

        public const string PATH_MASTER             = CacheConfig.ROOT + "master/";
        public const string PATH_MASTER_CATEGORY    = CacheConfig.ROOT + "master/categories/";

        public const string PATH_USER               = CacheConfig.ROOT + "user/";
        public const string PATH_USER_CATEGORY      = CacheConfig.ROOT + "user/categories/";
        public const string PATH_USER_PROFILE       = CacheConfig.ROOT + "user/profile/";
        public const string PATH_USER_SETTING       = CacheConfig.ROOT + "user/setting/";

        public const string CATEGORY_FILE_NAME      = "category.txt";
        public const string KEYWORD_FILE_NAME       = "keyword.txt";


        public static string GetPath()
        {
            return Application.dataPath + CacheConfig.ROOT;
        }

        // master
        public static string GetMasterPath()
        {
            return Application.dataPath + CacheConfig.PATH_MASTER;
        }

        public static string GetMasterCategoryPaht()
        {
            return Application.dataPath + CacheConfig.PATH_MASTER_CATEGORY;
        }


        // user
        public static string GetUserPath()
        {
            return Application.dataPath + CacheConfig.PATH_USER;
        }


    }


    public class Cache
    {
        public static void SaveAllCategory(JSONNode __jsonnode=null)
        {
            System.IO.Directory.CreateDirectory(CacheConfig.GetMasterCategoryPaht());

            foreach (JSONNode nodeByLv in __jsonnode.Children)
            {
                foreach(JSONNode nodeByParent in nodeByLv.Children)
                {
                    // TODO 要注意!!!!!!!!!Children.First()をキャッシュする
                    string file_path = Cache.GetPath(nodeByParent.Children.First()) + CacheConfig.CATEGORY_FILE_NAME;
                    Debug.Log(nodeByParent);
                    nodeByParent.SaveToFile(file_path);
                }
            }
        }


        public static void SaveCategory(JSONNode node = null)
        {
            if(node == null)
            {
                return;
            }

            // TODO 要注意!!!!!!!!!Children.First()をキャッシュする
            string file_path = Cache.GetPath(node.Children.First()) + CacheConfig.CATEGORY_FILE_NAME;
            node.SaveToFile(file_path);
        }


        public static JSONNode LoadCategory()
        {
            string file_path = Cache.GetPath() + CacheConfig.CATEGORY_FILE_NAME;
            JSONNode cache = JSONNode.LoadFromFile(file_path);
            return cache;
        }


        public static JSONNode LoadSubCategory(JSONNode node)
        {
            try
            {
                string file_path = Cache.GetPathByParentNode(node) + CacheConfig.CATEGORY_FILE_NAME;
                JSONNode cache = JSONNode.LoadFromFile(file_path);
                return cache;

            }
            catch 
            {
                return null;
            }
        }


        // 自分のキャッシュファイルパースを取得
        public static string GetPath(JSONNode node=null)
        {
            if(node==null)
            {
                return CacheConfig.GetMasterCategoryPaht();
            }

            return Cache.__paramToString(node);
        }


        // 親の情報から下位情報を取得
        public static string GetPathByParentNode(JSONNode parentNode)
        {
            string path = Cache.__paramToString(parentNode, (parentNode["level"].AsInt + 1)) + parentNode["sno"] + "/";
            return path;
        }


        // 親情報まで
        private static string __paramToString(JSONNode node, int _lv=0)
        {
            Debug.Log(node);
            int lv = 0;
            if (_lv.Equals(0))
            {
                lv = node["level"].AsInt;
            }
            else
            {
                lv = _lv;
            }

            string path = "";
            for(int i=2; i<=lv+1; i++)
            {
                if (node["p" + i].AsInt == 0)
                {
                    break;
                }

                path += node["p" + i] + "/";
            }
            return CacheConfig.GetMasterCategoryPaht() + path;
        }
    }
}