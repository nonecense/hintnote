//#define PRD
//#define STG
//#define TEST
#define LOCAL

//#define IOS
//#define ANDROID
#define LOCAL


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presto.Config
{
    /* *********************************************************************************
     * API定義
     **********************************************************************************/
    public class CONFIG
    {
        #if PRD
            public static readonly string API_BASE_URL = "https://api.prd.dict.navi-9.com/";
            public static readonly string RES_BASE_URL = "https://res.prd.dict.navi-9.com/";
        #elif STG
            public static readonly string API_BASE_URL = "https://api.stg.dict.navi-9.com/";
            public static readonly string RES_BASE_URL = "https://res.stg.dict.navi-9.com/";
        #elif TEST
            public static readonly string API_BASE_URL = "https://api.test.dict.navi-9.com/";
            public static readonly string RES_BASE_URL = "https://res.test.dict.navi-9.com/";
        #elif DEV
            public static readonly string API_BASE_URL = "http://api.dict.localhost:8080/";
            public static readonly string RES_BASE_URL = "http://res.dict.localhost:8080/";
        #else
            public static readonly string API_BASE_URL = "http://presto:8080/app/dict/";
            public static readonly string RES_BASE_URL = "http://presto:8080/res/app/dict/";
        #endif
    }
}
