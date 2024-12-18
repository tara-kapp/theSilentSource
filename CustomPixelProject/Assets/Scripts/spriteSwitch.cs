using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class spriteSwitch : MonoBehaviour
{
    public Texture[] spriteArray;
    public int spriteNum;
    public RawImage sprite;

    public RawImage buttonSprite;

    public TMP_Text headingText;
    public TMP_Text messageText;

    private string spriteName;

    public List<Sprite> manMadeItems;

    public Texture[] textureArray;

    public PigManager pigManager;

    private string[] headings = {
        "Bullets",
        "Shampoo",
        "Upholstery",
        "Chalk",
        "Crayons",
        "Pet Food",
        "Fabrics",
        "Fertilizers",
        "Football",
        "Candles",
        "Glue",
        "Heart Valves",
        "Insulin",
        "Jello",
        "Leather",
        "Matches",
        "Medicine",
        "Paintbrushes",
        "Cork",
        "Luggage",
        "Bone China"
    };
    private string[] descriptions = {
        "Bone gelatine from pigs is used to help transport the gunpowder or cordite of the bullet into its casing", 
        "Fatty acids from bone fat in pigs are used to give shampoo a pearl-like appearance.", 
        "Pig hair is commonly used in upholstery as a soft, work-friendly material for stuffing. A blend of 80% pig hair and 20% horse mane is often used as a second layer of stuffing.", 
        "For chalk, pig bones are processed into 'bone char' - a material used as a filler and sometimes as a whitening agent.", 
        "Fatty acids from pigs are used as a hardening agent in crayons", 
        "Liver, tripe, pig's trotters, udders and chicken feet are commonly used in pet food. These ingredients provide an excellent source of protein, amino acids and other nutrients.", 
        "Coating fabrics with processed pig fats, which are positively charged and cling to fabric surfaces, result in a soft and slippery feeling.", 
        "Pig manure is used to improve soil quality and promote healthy plant growth. Pig hair is also a common ingredient in fertilizer.", 
        "The first footballs were made from inflated pig bladders, which is where the term 'pigskin' comes from. Pig bladders were a good choice because they were cheap and durable.",  
        "Fatty acids from bone fat are used to stiffen the wax and raise the candle's melting point.",
        "Animal glue is a water-based adhesive that's non-toxic and biodegradable. It's used in traditional woodworking and painting techniques.", 
        "Under sterile conditions, a pigs heart valves can be removed from their body to be transplanted into humans.", 
        "Insulin is extracted from pig pancreases. It is then purified and processed for medical use.", 
        "Pigs are used to make gelatin (the main ingredient in many confectionaries, such as Jell-O) by boiling their skin, bones, tendons, and ligaments to extract collagen", 
        "Pigs are used to make leather through a process that involves harvesting, processing, and tanning their skin",
        "Proteins found in pig bones are used to make an adhesive called 'Bone Glue'. When combined with flammable chemicals like phosphorus it can be used to make matches.", 
        "Pigs are a source of many medicines, including insulin, heparin, ACTH, and thyroid medications. Additionally, gelatine is used in the shell of medicine tablets to give it hardness.", 
        "Pigs coarse hairs, known as hog bristles, are strong, springy, and flexible, making them ideal for holding paint. These bristles also have natural split ends.", 
        "Bone gelatin in pigs is used as a binder in the process of making cork.", 
        "Pig leather has been used to make suitcases for a long time because of its durability, flexibility, and water resistance.", 
        "Dried and powdered bones from pigs are used to create 'Bone Glass', known as Porcelain or Ceramic pottery."
        };

    public GameObject gameobject;

    public void OnClick()
    {
        UpdateSprite();
        gameobject.SetActive(true);
    }

    public void PassingList(List<Sprite> items)
    {
        manMadeItems = items;
    }

    public void CheckSprite(Sprite sprite)
    {
        spriteName = sprite.name;
        
        if( spriteName == "bullets"){
            spriteNum = 0;
        }
        else if( spriteName == "shampoo"){
            spriteNum = 1;
        }
        else if( spriteName == "chair"){
            spriteNum = 2;
        }
        else if( spriteName == "chalk"){
            spriteNum = 3;
        }
        else if( spriteName == "crayons"){
            spriteNum = 4;
        }
        else if( spriteName == "dogfood"){
            spriteNum = 5;
        }
        else if( spriteName == "fabric"){
            spriteNum = 6;
        }
        else if( spriteName == "fertilizer"){
            spriteNum = 7;
        }
        else if( spriteName == "football"){
            spriteNum = 8;
        }
        else if( spriteName == "candle"){
            spriteNum = 9;
        }
        else if( spriteName == "glue"){
            spriteNum = 10;
        }
        else if( spriteName == "heart"){
            spriteNum = 11;
        }
        else if( spriteName == "insulin"){
            spriteNum = 12;
        }
        else if( spriteName == "jello"){
            spriteNum = 13;
        }
        else if( spriteName == "leather"){
            spriteNum = 14;
        }
        else if( spriteName == "matches"){
            spriteNum = 15;
        }
        else if( spriteName == "medicine"){
            spriteNum = 16;
        }
        else if( spriteName == "brushes"){
            spriteNum = 17;
        }
        else if( spriteName == "cork"){
            spriteNum = 18;
        }
        else if( spriteName == "suitcase"){
            spriteNum = 19;
        }
        else if( spriteName == "teacup"){
            spriteNum = 20;
        }
    }

    public void OnExit(){
        gameobject.SetActive(false);

        pigManager.MoveNextPig();
    }
    void UpdateSprite() {
        sprite.texture = spriteArray[spriteNum];
        messageText.SetText(descriptions[spriteNum]);
        headingText.SetText(headings[spriteNum]);
        messageText.fontSize = 16;
    }
}