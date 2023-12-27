using UnityEngine;
using UnityEditor;
using MuaraJambi.Markerless;
using MuaraJambi.QrCodeObjectTracking;
using UnityEngine.UI;

[CustomEditor(typeof(ContentDefenition))]
public class HideOrShowVariablesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Call normal GUI (displaying "a" and any other variables you might have)
        base.OnInspectorGUI();

        // Reference the variables in the script
        ContentDefenition script = (ContentDefenition)target;

        if (script.objectTypes == ObjectTypes.Candi)
        {
            // Ensure the label and the value are on the same line

            ///---------------------------------IMAGE----------------------------------
            EditorGUILayout.BeginHorizontal();

            // A label that says "b" (change b to B if you want it uppercase like default) and restricts its length.
            EditorGUILayout.LabelField("SpesifikasiCandi image", GUILayout.MaxWidth(150));
            // Show and save the value of b
            script.spesifikasiCandi_image = (Sprite)EditorGUILayout.ObjectField(script.spesifikasiCandi_image, typeof(Sprite));
            // You can change 50 to any other value
            // If you would like to restrict the length of the int field, replace the above line with this one:

            EditorGUILayout.EndHorizontal();

            ///---------------------------------TITLE----------------------------------
            EditorGUILayout.BeginHorizontal();

            // A label that says "b" (change b to B if you want it uppercase like default) and restricts its length.
            EditorGUILayout.LabelField("SpesifikasiCandi title", GUILayout.MaxWidth(150));
            // Show and save the value of b
            script.spesifikasiCandi_title = EditorGUILayout.TextArea(script.spesifikasiCandi_title);
            // You can change 50 to any other value
            // If you would like to restrict the length of the int field, replace the above line with this one:

            EditorGUILayout.EndHorizontal();

            ///---------------------------------CONTENT----------------------------------
            EditorGUILayout.BeginHorizontal();

            // A label that says "b" (change b to B if you want it uppercase like default) and restricts its length.
            EditorGUILayout.LabelField("SpesifikasiCandi Content", GUILayout.MaxWidth(150));
            // Show and save the value of b
            script.spesifikasiCandi_content = EditorGUILayout.TextArea(script.spesifikasiCandi_content);
            // You can change 50 to any other value
            // If you would like to restrict the length of the int field, replace the above line with this one:

            EditorGUILayout.EndHorizontal();

        }
    }
}

[CustomEditor(typeof(QrCodeObjectTrackingController))]
public class HideOrShowVariablesQrCodeObjectTracking : Editor
{
    public override void OnInspectorGUI()
    {
        // Call normal GUI (displaying "a" and any other variables you might have)
        base.OnInspectorGUI();

        // Reference the variables in the script
        QrCodeObjectTrackingController script = (QrCodeObjectTrackingController)target;

        if (script.objectTypes == ObjectTypes.Candi)
        {
            // Ensure the label and the value are on the same line

            ///---------------------------------IMAGE----------------------------------
            EditorGUILayout.BeginHorizontal();

            // A label that says "b" (change b to B if you want it uppercase like default) and restricts its length.
            //EditorGUILayout.LabelField("SpesifikasiCandi image", GUILayout.MaxWidth(150));
            // Show and save the value of b
            //script.spesifikasiCandi_Image = (Sprite)EditorGUILayout.ObjectField(script.spesifikasiCandi_Image, typeof(Sprite));
            // You can change 50 to any other value
            // If you would like to restrict the length of the int field, replace the above line with this one:

            EditorGUILayout.EndHorizontal();

            ///---------------------------------TITLE----------------------------------
            EditorGUILayout.BeginHorizontal();

            // A label that says "b" (change b to B if you want it uppercase like default) and restricts its length.
            EditorGUILayout.LabelField("SpesifikasiCandi title", GUILayout.MaxWidth(150));
            // Show and save the value of b
            script.spesifikasiCandi_Tittle = EditorGUILayout.TextArea(script.spesifikasiCandi_Tittle);
            // You can change 50 to any other value
            // If you would like to restrict the length of the int field, replace the above line with this one:

            EditorGUILayout.EndHorizontal();

            ///---------------------------------CONTENT----------------------------------
            EditorGUILayout.BeginHorizontal();

            // A label that says "b" (change b to B if you want it uppercase like default) and restricts its length.
            EditorGUILayout.LabelField("SpesifikasiCandi Content", GUILayout.MaxWidth(150));
            // Show and save the value of b
            script.spesifikasiCandi_Content = EditorGUILayout.TextArea(script.spesifikasiCandi_Content);
            // You can change 50 to any other value
            // If you would like to restrict the length of the int field, replace the above line with this one:

            EditorGUILayout.EndHorizontal();

        }
    }
}

