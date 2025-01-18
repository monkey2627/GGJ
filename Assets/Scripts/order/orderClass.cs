using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    HouseholdItems1,//11
    HouseholdItems2,
    Smock,
    Jewelry,//14
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
    public float buyprice;//购买的价钱
    public float sellprice;//卖出的价钱
    //每个物品的合成配料,最多是三个不一样的
    public Ingredient[] ingredients = new Ingredient[3];
    //这个物品生产出来有多少
    public int number = 0;
    //在货架上有多少
    public int inShelves = 0;
    //在工作站有多少
    public int inWorkShop = 0;
    //在织布机上有多少
    public int inLoom = 0;
    //这个物体所对应的图标（放在canvas）上
    public Sprite sprite;
}

public class Order
{
    public int mark;//存订单位置
    //订单所需的物品
    public Object[] objects = new Object[3];
    //订单完成可以得到的钱
    public float money;
    //总时间
    public float allTime;
    //订单留给我们的时间
    public float remainTime;
    //完成度
    public float complete;
    //为订单创建一个进度条
    public Slider slider;
    //
    public Slider compleSlider;
}