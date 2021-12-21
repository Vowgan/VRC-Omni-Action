using UdonSharpEditor;
using UnityEditor;

namespace Pokeyi.UdonSharp
{
    [CustomEditor(typeof(P_OmniAction))]
    public class P_OmniAction_Editor : Editor
    {
        
        // The script that this editor runs on.
        private P_OmniAction script;
        // A reference to the Function property that we want to be using for the dropdown.
        private SerializedProperty propTargetFunction;
        
        private void OnEnable()
        {
            // Reference our script when the object loads in the inspector.
            script = target as P_OmniAction;
            if (script == null) return;
            
            // Establish our reference based on the current object's value.
            propTargetFunction = serializedObject.FindProperty(nameof(script.targetFunction));
        }

        public override void OnInspectorGUI()
        {
            // If the C# script was added to the object and we need to turn it into an Udon Component, this draws that button.
            if (UdonSharpGUI.DrawConvertToUdonBehaviourButton(target)) return;
            
            // This is what draws the UdonSharp top thing.
            UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target);
            
            // This is our dropdown. Udon doesn't have "Enums," so we need to turn our Int into and Enum and then back into an Int.
            propTargetFunction.intValue = (int)(OmniActions)EditorGUILayout.EnumPopup("Target Function", (OmniActions)propTargetFunction.intValue);
            // If this value has changed, meaning they selected a different option, apply that setting to the actual Udon script.
            serializedObject.ApplyModifiedProperties();
            
            // This is a HelpBox used to explain the current Function we are trying to use.
            OmniActions action = (OmniActions)propTargetFunction.intValue;
            string helpBoxInfo = "";
            switch (action)
            {
                case OmniActions.EventsOnly:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.PickupReset:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.BinaryToggle:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.SequenceToggle:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.EnableAll:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.DisableAll:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.AnimToggle:
                    helpBoxInfo = "Animator Bool";
                    break;
                case OmniActions.AnimTrue:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.AnimFalse:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.TeleportPlayer:
                    helpBoxInfo = "Player to T-i++";
                    break;
                case OmniActions.TeleportObject:
                    helpBoxInfo = "T-0 to T-i++";
                    break;
                case OmniActions.Stopwatch:
                    helpBoxInfo = "T-0 Output Text Field";
                    break;
                case OmniActions.PoolSpawn:
                    helpBoxInfo = "Replace Me!";
                    break;
                case OmniActions.PoolReset:
                    helpBoxInfo = "Replace Me!";
                    break;
            }
            // Draw the actual HelpBox.
            EditorGUILayout.HelpBox(helpBoxInfo, MessageType.Info);
            
            // Finally, display the normal, original Inspector.
            base.OnInspectorGUI();
        }
    }

    /// <summary>
    /// The actions used by P_OmniAction. These MUST remain in the same order as P_OmniAction requests them in.
    /// </summary>
    public enum OmniActions
    {
        EventsOnly,
        PickupReset,
        BinaryToggle,
        SequenceToggle,
        EnableAll,
        DisableAll,
        AnimToggle,
        AnimTrue,
        AnimFalse,
        TeleportPlayer,
        TeleportObject,
        Stopwatch,
        PoolSpawn,
        PoolReset,
    }
}