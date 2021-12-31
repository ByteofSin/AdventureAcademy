/*
A json based save load system using Unity's json utilities
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Byte.Utilities.Persistence {
    public static class JsonUtility {
        public static string ToJson(object obj){
            return JsonUtility.ToJson(obj);
        }

        public static GenericType FromJson<GenericType>(string json){
            return JsonUtility.FromJson<GenericType>(json);
        }

    }
}
