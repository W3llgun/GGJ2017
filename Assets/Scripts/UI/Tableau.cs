using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Controlle un tableau, une liste ou un inventaire.
/// </summary>
public class Tableau : MonoBehaviour
{
    public GameObject prefabTile;
    public GridLayoutGroup grid;       // le composant grille qui permet d'organiser les cases du tableau
    public Scrollbar verticalScroll;   // la barre de défilement verticale
    private Transform content;   // le contenu du tableau
    private GameObject Panel;    // panel contenant le tableau
    List<InventoryTile> tiles;
    float cellSizeX;

    public void Awake()
    {
           tiles = new List<InventoryTile>();
        content = transform.Find("Viewport").Find("Content");
        cellSizeX = grid.cellSize.x;
        if (transform.Find("Slider"))
            transform.Find("Slider").GetComponent<Slider>().value = 30;
        
        grid.cellSize = new Vector2(this.GetComponent<RectTransform>().rect.width, grid.cellSize.y);
    }

    // défile le tableau avec la roulette de la souris
    void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel != 0 && verticalScroll)
        {
            verticalScroll.value += mouseWheel;
        }
    }

    // Fermer le tableau
    public void closeTableau()
    {
        if (Panel)
        {
            Panel.SetActive(false);
        }
    }
    

    // Ajoute un élément
    public void addElement(string elemName, string elemCost, int index, bool active = true)
    {
        GameObject obj = (GameObject)Instantiate(prefabTile, transform.position, transform.rotation);
        obj.transform.SetParent(content.transform);
        InventoryTile tile = obj.GetComponent<InventoryTile>();
        tile.setTile(elemName, elemCost, index, active);
        tiles.Add(tile);
    }
}
