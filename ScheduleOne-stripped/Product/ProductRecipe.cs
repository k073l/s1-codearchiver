using ScheduleOne.UI.Tooltips;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.Product;
public class ProductRecipe : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Image _productIcon;
    [SerializeField]
    private Tooltip _productTooltip;
    [SerializeField]
    private Image _mixerIcon;
    [SerializeField]
    private Tooltip _mixerTooltip;
    [SerializeField]
    private Image _outputIcon;
    [SerializeField]
    private Tooltip _outputTooltip;
    public void SetProduct(Sprite sprite, string tooltip);
    public void SetMixer(Sprite sprite, string tooltip);
    public void SetOutput(Sprite sprite, string tooltip);
}