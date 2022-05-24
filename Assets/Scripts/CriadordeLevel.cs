using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadordeLevel : MonoBehaviour
{//cria o nivel

    //aceita o prefab do tile sem faselo publico
    [SerializeField]
    private GameObject maptile;
    //propriedade da classe tamanho do tile
    public float TileSize {
        //returna informa��o da posi��o dos tiles
        get {return maptile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;}
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {//instancia os maptiles

        //chama a camera para determinar as coordenadas de inicio
        Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
         //enconto aver espa�o no mapa em coordenadas y e contuniar criando tiles
        for (int y = 0; y < 10; y++)
        {
            //enconto aver espa�o no mapa em coordenadas x contuniar criando tiles
            for (int x = 0; x < 22; x++ )
            {
                //chama a fun��o placeTile
                PlaceTile(x,y, worldStartPosition);
            }
        }
    }
    //fun��o para criar e alterar a posi��o de novos tiles
    private void PlaceTile(int x, int y, Vector3 worldStartPosition)
    {
        //Cria tile e referencia eles na variavel newTile
        GameObject newTile = Instantiate(maptile);

        //usa a variavel newtile para modificar a posi��o enque novos tiles ser�o criados
        newTile.transform.position = new Vector3(worldStartPosition.x + (TileSize * x), worldStartPosition.y - (TileSize * y), 0);
    }
}