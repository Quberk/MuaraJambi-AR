using UnityEngine;
using UnityEngine.UI;
 
public class VerticalList : VerticalLayoutGroup
{

    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputVertical();
        rectTransform.sizeDelta = new Vector2( rectTransform.sizeDelta.y, minWidth);
    }
    
}
