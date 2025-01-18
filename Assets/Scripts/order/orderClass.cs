using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Element
//����Ԫ��
{
    //��
    GoldThread,
    SilkThread,
    CottonThread,
    LinenThread,
    PolyesterThread,
    //��
    Silk,
    CottonCloth,
    Linen,
    PolyesterCloth,
    //�������
    PreseamedPlates,
    CopperWireInlay,
    //��Ʒ
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
   public int num;//����
   public Object obj;//��Ӧ����Ʒ���߰�ɶ�Ķ�����Ʒ
}
public class Object{
    public Element name;//�����Ʒ������
    public float buyprice;//����ļ�Ǯ
    public float sellprice;//�����ļ�Ǯ
    //ÿ����Ʒ�ĺϳ�����,�����������һ����
    public Ingredient[] ingredients = new Ingredient[3];
    //�����Ʒ���������ж���
    public int number = 0;
    //�ڻ������ж���
    public int inShelves = 0;
    //�ڹ���վ�ж���
    public int inWorkShop = 0;
    //��֯�������ж���
    public int inLoom = 0;
    //�����������Ӧ��ͼ�꣨����canvas����
    public Sprite sprite;
}

public class Order
{
    public int mark;//�涩��λ��
    //�����������Ʒ
    public Object[] objects = new Object[3];
    //������ɿ��Եõ���Ǯ
    public float money;
    //��ʱ��
    public float allTime;
    //�����������ǵ�ʱ��
    public float remainTime;
    //��ɶ�
    public float complete;
    //Ϊ��������һ��������
    public Slider slider;
    //
    public Slider compleSlider;
}