using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
//所有元素
{
    //线
    GoldThread,
    SilkThread,
    CottonThread,
    LinenThread,
    PolyesterThread,
    //布
    Silk,
    CottonCloth,
    Linen,
    PolyesterCloth,
    //额外材料
    PreseamedPlates,
    CopperWireInlay,
    //物品
    HouseholdItems1,
    HouseholdItems2,
    Smock,
    Jewelry,
    LinenBag,
    Doll,
    cheongsam,
    EmbroideredDecorations,
    ChineseWeddingDress
}

public struct Ingredient
{
   public int num;//数量
   public Object obj;//对应的物品，线啊啥的都叫物品
}
public class Object{
    public Element name;//这个物品的名字
    public float price;//购买的价钱
    public float value;//卖出的价钱
    //每个物品的合成配料,最多是三个不一样的
    public Ingredient[] ingredients = new Ingredient[3];
    //这个物品在货架上有多少
    public int number = 0;
    //这个物体所对应的图标（放在canvas）上
    public sprite sprite;
}

public class OrderClass : MonoBehaviour
{
    public Object[] objects = new Object[110];
    //存订单
    public List<Order> orders;
    public void GetCombineTabel()
    {
        //线
        objects[(int) Element.CottonThread].name = Element.CottonThread;
        objects[(int) Element.SilkThread].name = Element.SilkThread;
        objects[(int) Element.GoldThread].name = Element.GoldThread;
        objects[(int) Element.LinenThread].name = Element.LinenThread;
        objects[(int) Element.PolyesterThread].name = Element.PolyesterThread;
        //布
        objects[(int) Element.CottonCloth].name = Element.CottonCloth;
        objects[(int) Element.CottonCloth].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 3 };

        objects[(int)Element.Linen].name = Element.Linen;
        objects[(int)Element.Linen].ingredients[0] = new Ingredient() { obj = objects[(int)Element.LinenThread], num = 3 };


        objects[(int)Element.PolyesterCloth].name = Element.PolyesterCloth;
        objects[(int)Element.PolyesterCloth].ingredients[0] = new Ingredient() { obj = objects[(int)Element.PolyesterThread], num = 2 };
        objects[(int)Element.PolyesterCloth].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };


        objects[(int)Element.Silk].ingredients[0] = new Ingredient() { obj = objects[(int)Element.SilkThread], num = 3 };
        objects[(int)Element.Silk].name = Element.Silk;
        //
        objects[(int)Element.CopperWireInlay].name = Element.CopperWireInlay;
        objects[(int)Element.PreseamedPlates].name = Element.PreseamedPlates;
        //
        objects[(int)Element.HouseholdItems1].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 2 };
        objects[(int)Element.HouseholdItems1].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.HouseholdItems1].name = Element.HouseholdItems1;

        objects[(int)Element.HouseholdItems2].ingredients[0] = new Ingredient() { obj = objects[(int)Element.PolyesterCloth], num = 1 };
        objects[(int)Element.HouseholdItems2].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 1 };
        objects[(int)Element.HouseholdItems2].ingredients[2] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.HouseholdItems2].name = Element.HouseholdItems2;

        objects[(int)Element.Smock].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 1 };
        objects[(int)Element.Smock].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.Smock].ingredients[2] = new Ingredient() { obj = objects[(int)Element.Linen], num = 1 };
        objects[(int)Element.Smock].name = Element.Smock;


        objects[(int)Element.Jewelry].ingredients[0] = new Ingredient() { obj = objects[(int)Element.GoldThread], num = 2 };
        objects[(int)Element.Jewelry].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 1 };
        //objects[(int)Element.Jewelry].ingredients[2] = new Ingredient() { obj = objects[(int)Element.Linen], num = 1 };
        objects[(int)Element.Jewelry].name = Element.Jewelry;


        objects[(int)Element.LinenBag].ingredients[0] = new Ingredient() { obj = objects[(int)Element.Jewelry], num = 1 };
        objects[(int)Element.LinenBag].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.LinenBag].ingredients[2] = new Ingredient() { obj = objects[(int)Element.Linen], num = 1 };
        objects[(int)Element.LinenBag].name = Element.LinenBag;



        objects[(int)Element.Doll].ingredients[0] = new Ingredient() { obj = objects[(int)Element.Jewelry], num = 1 };
        objects[(int)Element.Doll].ingredients[1] = new Ingredient() { obj = objects[(int)Element.PreseamedPlates], num = 1 };
        objects[(int)Element.Doll].ingredients[2] = new Ingredient() { obj = objects[(int)Element.PolyesterCloth], num = 1 };
        objects[(int)Element.Doll].name = Element.Doll;



        objects[(int)Element.cheongsam].ingredients[0] = new Ingredient() { obj = objects[(int)Element.Silk], num = 1 };
        objects[(int)Element.cheongsam].ingredients[1] = new Ingredient() { obj = objects[(int)Element.PreseamedPlates], num = 1 };
        objects[(int)Element.cheongsam].ingredients[2] = new Ingredient() { obj = objects[(int)Element.GoldThread], num = 1 };
        objects[(int)Element.cheongsam].name = Element.cheongsam;


        objects[(int)Element.EmbroideredDecorations].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CopperWireInlay], num = 2 };
        objects[(int)Element.EmbroideredDecorations].ingredients[1] = new Ingredient() { obj = objects[(int)Element.SilkThread], num = 1 };
      //  objects[(int)Element.EmbroideredDecorations].ingredients[2] = new Ingredient() { obj = objects[(int)Element.EmbroideredDecorations], num = 1 };
        objects[(int)Element.EmbroideredDecorations].name = Element.EmbroideredDecorations;



        objects[(int)Element.ChineseWeddingDress].ingredients[0] = new Ingredient() { obj = objects[(int)Element.PreseamedPlates], num = 1 };
        objects[(int)Element.ChineseWeddingDress].ingredients[1] = new Ingredient() { obj = objects[(int)Element.Silk], num = 1 };
        objects[(int)Element.ChineseWeddingDress].ingredients[2] = new Ingredient() { obj = objects[(int)Element.EmbroideredDecorations], num = 1 };
        objects[(int)Element.ChineseWeddingDress].name = Element.ChineseWeddingDress;


    }
    
    void Start()
    {
        GetCombineTabel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
