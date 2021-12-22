using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

namespace Byte.GameManager {
    public class DrawSelected <ScriptableObjectType> where ScriptableObjectType : ScriptableObject {
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        public ScriptableObjectType selectedObject;

        [LabelText("New Name")]
        [LabelWidth(100)]
        [PropertyOrder(-1)]
        [BoxGroup("CreateNew")]
        [HorizontalGroup("CreateNew/HorizontalGroup")]
        public string nameForNewObject;

        private string filePath;

        [HorizontalGroup("CreateNew/HorizontalGroup")]
        [GUIColor(0.7f, 0.7f,1f)]
        [Button("Create")]
        public void CreateNew(){
            if(nameForNewObject == ""){
                return;
            } else {
                //Create an instance of a new object
                ScriptableObjectType newObject = ScriptableObject.CreateInstance<ScriptableObjectType>();
                newObject.name = "New " + typeof(ScriptableObjectType).ToString();

                //Create a filepath
                if(filePath == ""){
                    filePath = "Assets/Buffer";
                }

                //Create and save the asset data
                AssetDatabase.CreateAsset(newObject, filePath + "\\" + nameForNewObject + ".asset");
                AssetDatabase.SaveAssets();

                //Reset variables for next new object
                nameForNewObject = "";
            }
        } 

        [GUIColor(1f, 0.7f, 0.7f)]
        [Button("Delete")]
        public void DeleteSelected() {
            if(selectedObject != null){
                //Get the assets path
                string assetPath = AssetDatabase.GetAssetPath(selectedObject);

                //Remove asset from the database
                AssetDatabase.DeleteAsset(assetPath);
                AssetDatabase.SaveAssets();
            }
        }

        public void SetSelected(object item){
            var attempt = item as ScriptableObjectType;
            if(attempt != null){
                this.selectedObject = attempt;
            }
        }

        public void SetPath(string path){
            this.filePath = path;
        }
    }
}