using UnityEngine;
using UnityEngine.UI;

public class ItemMenuController : MonoBehaviour
{
    public Image itemDisplayImage;
    public FurnitureItem[] allFurniture;

    private int currentIndex = 0;
    public PlacementManager placementManager;

    void Start()
    {
        if (allFurniture.Length > 0)
        {
            UpdateItemDisplay();
        }
    }

    public void ScrollLeft()
    {
        currentIndex = (currentIndex - 1 + allFurniture.Length) % allFurniture.Length;
        UpdateItemDisplay();
    }

    public void ScrollRight()
    {
        currentIndex = (currentIndex + 1) % allFurniture.Length;
        UpdateItemDisplay();
    }

    void UpdateItemDisplay()
    {
        itemDisplayImage.sprite = allFurniture[currentIndex].thumbnail;
    }

    public void SelectItem()
    {
        placementManager.SetItemToPlace(allFurniture[currentIndex].prefab);
        gameObject.SetActive(false); // hide menu after selection
    }
}

