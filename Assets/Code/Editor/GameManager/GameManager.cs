using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

//Scriptable Objects
using Byte.Rpg;
using Byte.TileSystem;

namespace Byte.GameManager {
    public class GameManager : OdinMenuEditorWindow {
        /* Variables
        ============ */
        /* State Variables 
        -------------------- */
        private bool rebuildMenuTree = false;

        public enum ManagerState {
            //Rpg
            Classes,
            Abilities,
            //Inventory
            Items,
            //World F
            Tiles,
            Colors
        }

        [OnValueChanged("StateChange")]
        [LabelWidth(100f)]
        [EnumToggleButtons]
        [ShowInInspector]
        private ManagerState managerState;

        private int enumIndex;

        /* File Setup 
        --------------- */
        //Draw Selected Objects
        private DrawSelected<Byte.Rpg.Class> drawClass = new DrawSelected<Byte.Rpg.Class>();
        private DrawSelected<Byte.Rpg.Ability> drawAbility = new DrawSelected<Byte.Rpg.Ability>();
        private DrawSelected<Byte.TileSystem.TileScriptableObject> drawTile = new DrawSelected<Byte.TileSystem.TileScriptableObject>();

        //Files
        private string classPath = "Assets/Resources/Classes";
        private string abilityPath = "Assets/Resources/Abilities";
        private string tileTypepath = "Assets/Resources/Tiles";


        [MenuItem("Tools/Game Manager")]
        public static void OpenWindow(){
            GetWindow<GameManager>().Show();
        }


        /* Overrides 
        ============== */
        protected override void OnGUI(){
            if(rebuildMenuTree && Event.current.type == EventType.Layout){
                ForceMenuTreeRebuild();
                rebuildMenuTree = false;
            }

            SirenixEditorGUI.Title("Byte Game Manager", "Modular and Scalable", TextAlignment.Center, true);
            EditorGUILayout.Space();
            //Checks to see if 
            switch (managerState) {
                case ManagerState.Classes:
                case ManagerState.Abilities:
                case ManagerState.Items:
                case ManagerState.Tiles:
                case ManagerState.Colors:
                    DrawEditor(enumIndex);
                    break;
                default:
                    break;
            }
            EditorGUILayout.Space();

            base.OnGUI();
        }

        private void StateChange(){
            rebuildMenuTree = true;
        }

        protected override void Initialize(){
            drawClass.SetPath(classPath);
            drawAbility.SetPath(abilityPath);
            drawTile.SetPath(tileTypepath);
        }

        protected override void DrawEditors(){
            //Draw editors on a case by case basis
            switch (managerState) {
                case ManagerState.Classes:
                    drawClass.SetSelected(this.MenuTree.Selection.SelectedValue);
                    break;
                case ManagerState.Abilities:
                    drawAbility.SetSelected(this.MenuTree.Selection.SelectedValue);
                    break;
                case ManagerState.Items:
                    break;
                case ManagerState.Tiles:
                    drawTile.SetSelected(this.MenuTree.Selection.SelectedValue);
                    break;
                case ManagerState.Colors:
                    break;
                default:
                    break;
            }

            DrawEditor((int)managerState);
        }

        
        protected override IEnumerable<object> GetTargets(){
            //Create a list of targets to draw
            List<object> targets = new List<object>();
        
            //Add targets in relation to enums
            targets.Add(drawClass);
            targets.Add(drawAbility);
            targets.Add(null);
            targets.Add(drawTile);
            targets.Add(null);

            //Add base target and store its index
            targets.Add(base.GetTarget());
            enumIndex = targets.Count - 1;

            return targets;
        }

        //Controls when the editor is drawn
        protected override void DrawMenu(){
            switch (managerState) {
                //Checks if managerstate is on any state that is  shown, falls through if it is
                case ManagerState.Classes:
                case ManagerState.Abilities:
                case ManagerState.Items:
                case ManagerState.Tiles:
                case ManagerState.Colors:
                    base.DrawMenu();
                    break;
                default:
                    break;
            }
        }

        protected override OdinMenuTree BuildMenuTree() {
            OdinMenuTree tree = new OdinMenuTree();

             switch (managerState) {
                case ManagerState.Classes:
                    tree.AddAllAssetsAtPath("Classes", classPath, typeof(Byte.Rpg.Class));
                    break;
                case ManagerState.Abilities:
                    tree.AddAllAssetsAtPath("Abilities", abilityPath, typeof(Byte.Rpg.Ability));
                    break;
                case ManagerState.Items:
                    break;
                case ManagerState.Tiles:
                    tree.AddAllAssetsAtPath("Tiles", tileTypepath, typeof(Byte.TileSystem.TileType));
                    break;
                case ManagerState.Colors:
                    break;
                default:
                    break;
            }

            return tree;
        }
    }
}