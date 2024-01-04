using System;
using System.Runtime.InteropServices;


class Program
{
    class Item
    {
        public int Id;
        public string Name;
        public string Text;
        public string Effect;
        public string type;
        public int Price;
        public bool isEquip;
        public bool isBuy;

        public Item(int id, string name, string text, string effect, int price, bool equip, bool isbuy, string type)
        {
            Id = id;
            Name = name;
            Text = text;
            Effect = effect;
            Price = price;
            isEquip = equip;
            isBuy = isbuy;
            this.type = type;
        }

        public void showinInventory()
        {
            if (isEquip)
            {
                Console.WriteLine("[E]" + Name + "\t| " + Effect + "\t| " + Text);
            }
            else
            {
                Console.WriteLine(Name + "\t| " + Effect + "\t| " + Text);
            }
        }

        public void showinShop()
        {
            if (isBuy)
            {
                Console.WriteLine(Name + "\t| " + Effect + "\t| " + Text + "\t| 구매완료");
            }
            else
            {
                Console.WriteLine(Name + "\t| " + Effect + "\t| " + Text + "\t| " + Price + "G");
            }
        }
    }

    class Character
    {
        public int Level;
        public string Name;
        public string Class;
        public int AttackPoint;
        public int DeffensePoint;
        public int HealthPoint;
        public int Gold;

        public int equipAttackEffect;
        public int equipDeffenseEffect;

        public bool equipArmor;
        public bool equipWeapon;

        public Character(int level, string name, string @class, int attackPoint, int deffensePoint, int healthPoint, int gold, bool equipArmor, bool equipWeapon)
        {
            Level = level;
            Name = name;
            Class = @class;
            AttackPoint = attackPoint;
            DeffensePoint = deffensePoint;
            HealthPoint = healthPoint;
            Gold = gold;
            this.equipArmor = equipArmor;
            this.equipWeapon = equipWeapon;
        }

        public void EquipItem(Item A)
        {
            string[] Effect = A.Effect.Split(" +");

            if (Effect[0] == "공격력")
            {
                AttackPoint += Int32.Parse(Effect[1]);
                equipAttackEffect += Int32.Parse(Effect[1]);
            }
            else if (Effect[0] == "방어력")
            {
                DeffensePoint += Int32.Parse(Effect[1]);
                equipDeffenseEffect += Int32.Parse(Effect[1]);
            }
        }
        public void EquipExitItem(Item A)
        {
            string[] Effect = A.Effect.Split(" +");

            if (Effect[0] == "공격력")
            {
                AttackPoint -= Int32.Parse(Effect[1]);
                equipAttackEffect -= Int32.Parse(Effect[1]);
            }
            else if (Effect[0] == "방어력")
            {
                DeffensePoint -= Int32.Parse(Effect[1]);
                equipDeffenseEffect -= Int32.Parse(Effect[1]);
            }
        }
    }

    static void showMain()
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine("==============================================");
    }

    static void showState(Character A)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 캐릭터 정보 ]");
        Console.WriteLine("Lv. " + A.Level);
        Console.WriteLine(A.Name + " ( " + A.Class + " )");
        if (A.equipAttackEffect == 0)
            Console.WriteLine("공격력 : " + A.AttackPoint);
        else
            Console.WriteLine("공격력 : " + A.AttackPoint + "(+" + A.equipAttackEffect + ")");
        if (A.equipDeffenseEffect == 0)
            Console.WriteLine("방어력 : " + A.DeffensePoint);
        else
            Console.WriteLine("방어력 : " + A.DeffensePoint + "(+" + A.equipDeffenseEffect + ")");
        Console.WriteLine("체력 : " + A.HealthPoint);
        Console.WriteLine("골드 : " + A.Gold + "G");
        Console.WriteLine("==============================================");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }

    static void showInventory(Item[] A)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 아이템 목록 ]");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write("- ");
            A[i].showinInventory();
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("1. 아이템 장착");
        Console.WriteLine("2. 아이템 해제");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }

    static void showInventoryEM(Item[] A)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 아이템 장착 ]");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write(i + 1 + ". ");
            A[i].showinInventory();
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }

    static void showInventoryEQM(Item[] A)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 아이템 해제 ]");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write(i + 1 + ". ");
            A[i].showinInventory();
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }

    static void showShop(Item[] A, Character B)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 상점 ]  == 소지 골드 : " + B.Gold + "G ==");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write("- ");
            A[i].showinShop();
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("2. 아이템 판매");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }
    static void showShopBM(Item[] A, Character B)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 아이템 구매 ]  == 소지 골드 : " + B.Gold + "G ==");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write(i + 1 + ". ");
            A[i].showinShop();
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }

    static void showShopSM(Item[] A, Character B)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("[ 아이템 판매 ]  == 소지 골드 : " + B.Gold + "G ==");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write(i + 1 + ". ");
            A[i].showinShop();
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("==============================================");
    }

    static string inputText()
    {
        Console.WriteLine("원하시는 행동을 입력해주세요");
        Console.Write(">>>");
        string input = Console.ReadLine();
        return input;
    }

    static string exit()
    {
        Console.Clear();
        Console.WriteLine("잘못된 입력입니다.");
        Console.WriteLine("==============================================");
        Console.WriteLine("아무키나 입력하여 나가기");
        string input = Console.ReadLine();
        return input;
    }

    static void Main(string[] args)
    {
        Character Chad = new Character(1, "Chad", "전사", 10, 5, 100, 5000, false, false);

        Item noviceArmor = new Item(0, "수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", "방어력 +5", 1000, false, false,"Armor");
        Item MetalArmor = new Item(1, "무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", "방어력 +9", 2000, false, true, "Armor");
        Item SpartaArmor = new Item(2, "영웅의 갑옷", "영웅들이 사용했던 전설의 갑옷입니다.", "방어력 +15", 3500, false, false, "Armor");
        Item OldSword = new Item(3, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", "공격력 +2", 600, false, true, "Weapon");
        Item BlonzeAxe = new Item(4, "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", "공격력 +5", 1500, false, false, "Weapon");
        Item SpartaSpear = new Item(5, "영웅의 창", "영웅들이 사용했던 전설의 창입니다.", "공격력 +7", 3000, false, true, "Weapon");

        Item[] ShopItem = { noviceArmor, MetalArmor, SpartaArmor, OldSword, BlonzeAxe, SpartaSpear };
        Item[] myItem = { MetalArmor, SpartaSpear, OldSword };


        do
        {
            showMain();

            string input = inputText();

            if (input == "1")
            {
                showState(Chad);
                input = inputText();
                if (input != "0")
                { input = exit(); }
            }
            else if (input == "2")
            {
                Console.Clear();
                showInventory(myItem);
                input = inputText();
                if (input == "1")
                {
                    showInventoryEM(myItem);
                    input = inputText();
                    for (int i = 0; i < myItem.Length + 1; i++)
                    {
                        if (input == i.ToString())
                        {
                            if (myItem[i - 1].isEquip == true)
                            {
                                Console.Clear();
                                Console.WriteLine("이미 장착된 아이템입니다.");
                                Console.WriteLine("==============================================");
                                input = inputText();
                            }
                            else
                            {
                                if (myItem[i-1].type == "Armor")
                                {
                                    if(Chad.equipArmor)
                                    {
                                        for (int i2 = 0; i2 < myItem.Length; i2++)
                                        {
                                            if (myItem[i2].isEquip == true && myItem[i2].type == "Armor")
                                            {
                                                myItem[i2].isEquip = false;
                                                Chad.EquipExitItem(myItem[i2]);
                                            }
                                        }
                                        myItem[i - 1].isEquip = true;
                                        Chad.equipArmor = true;
                                        Chad.EquipItem(myItem[i - 1]);
                                    }
                                    else
                                    {
                                        myItem[i - 1].isEquip = true;
                                        Chad.equipArmor = true;
                                        Chad.EquipItem(myItem[i - 1]);
                                    }
                                }
                                else if (myItem[i - 1].type == "Weapon")
                                {
                                    if (Chad.equipWeapon)
                                    {
                                        for (int i2 = 0; i2 < myItem.Length; i2++)
                                        {
                                            if (myItem[i2].isEquip == true && myItem[i2].type == "Weapon")
                                            {
                                                myItem[i2].isEquip = false;
                                                Chad.EquipExitItem(myItem[i2]);
                                            }
                                        }
                                        myItem[i - 1].isEquip = true;
                                        Chad.equipWeapon = true;
                                        Chad.EquipItem(myItem[i - 1]);
                                    }
                                    else
                                    {
                                        myItem[i - 1].isEquip = true;
                                        Chad.equipWeapon = true;
                                        Chad.EquipItem(myItem[i - 1]);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (input == "2")
                {
                    showInventoryEQM(myItem);
                    input = inputText();
                    for (int i = 0; i < myItem.Length + 1; i++)
                    {
                        if (input == i.ToString())
                        {
                            if (myItem[i - 1].isEquip == false)
                            {
                                Console.Clear();
                                Console.WriteLine("장착하지 않은 아이템입니다.");
                                Console.WriteLine("==============================================");
                                input = inputText();
                            }
                            else
                            {
                                if (myItem[i - 1].type == "Weapon")
                                {
                                    myItem[i - 1].isEquip = false;
                                    Chad.equipWeapon = true;
                                    Chad.EquipExitItem(myItem[i - 1]);
                                }
                                else if (myItem[i - 1].type == "Armor")
                                {
                                    myItem[i - 1].isEquip = false;
                                    Chad.equipArmor = true;
                                    Chad.EquipExitItem(myItem[i - 1]);
                                }
                            }
                        }
                    }
                }
                else if (input != "0")
                { input = exit(); }
            }
            else if (input == "3")
            {
                Console.Clear();
                showShop(ShopItem, Chad);
                input = inputText();
                if (input == "1")
                {
                    showShopBM(ShopItem, Chad);
                    input = inputText();
                    if (input != "0")
                    {
                        for (int i = 0; i < ShopItem.Length + 1; i++)
                        {
                            if (input == i.ToString())
                            {
                                if (ShopItem[i - 1].isBuy == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("재고가 다 떨어졌습니다.");
                                    Console.WriteLine("==============================================");
                                    input = inputText();
                                }
                                else if (Chad.Gold < ShopItem[i - 1].Price)
                                {
                                    Console.Clear();
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.WriteLine("==============================================");
                                    input = inputText();
                                }
                                else
                                {
                                    ShopItem[i - 1].isBuy = true;
                                    Chad.Gold -= ShopItem[i - 1].Price;
                                    Array.Resize(ref myItem, myItem.Length + 1);
                                    myItem[myItem.Length - 1] = ShopItem[i - 1];

                                    Console.Clear();
                                    Console.WriteLine("구매에 성공하셨습니다.");
                                    Console.WriteLine("==============================================");
                                    input = inputText();
                                }
                            }
                        }
                    }
                }
                else if (input == "2")
                {
                    showShopSM(myItem, Chad);
                    input = inputText();
                    if (input != "0")
                    {
                        for (int i = 0; i < myItem.Length + 1; i++)
                        {
                            if (input == i.ToString())
                            {
                                if (myItem[i - 1].isEquip == true)
                                {
                                    myItem[i - 1].isEquip = false;
                                    Chad.EquipExitItem(myItem[i - 1]);
                                }
                                ShopItem[myItem[i - 1].Id].isBuy = false;
                                Chad.Gold += (int)((float)ShopItem[myItem[i - 1].Id].Price*0.85);
                                Console.Clear();

                                Console.WriteLine((int)((float)ShopItem[myItem[i - 1].Id].Price * 0.85) + "G를 획득 했습니다.");
                                Console.WriteLine("==============================================");

                                for (int j = i-1; j < myItem.Length - 1; j++) 
                                {
                                    myItem[j] = myItem[j+1];
                                }
                                Array.Resize(ref myItem, myItem.Length - 1);

                                input = inputText();

                            }
                        }
                    }
                }
                else if (input != "0")
                { input = exit(); }
            }
            else
            { input = exit(); }
        }
        while (true);
    }
}
