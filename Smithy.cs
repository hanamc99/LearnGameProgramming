using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Smithy
    {
        DataMgr mgr = DataMgr.GetInstance();

        public Smithy()
        {
            Console.WriteLine("쇠를 두들기는 소리의 근원을 따라 마을 한 구석에 도착하자, \n" +
                "팔 근육이 터질듯한 갈색의 드워프가 운영하는 대장간이 있었다. \n무엇을 할까?");

            while (true)
            {
                Console.WriteLine("\n0 => 무기 제작\n1 => 무기 강화\n2 => 나간다.\n");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("\n어떤 무기를 제작할까?");
                    for(int i = 0; i < 8; i++)
                    {
                        Console.WriteLine("\n{0} => {1}", i, mgr.GetWeaponData(i).name);
                    }
                    string choice2 = Console.ReadLine();
                    int choice22 = Convert.ToInt32(choice2);
                    Console.WriteLine("주인장 드워프에게 {0}을 부탁한다고 하자, 그건 자기 전문 분야라며 자신감을 뽐냈다.", mgr.GetWeaponData(choice22).name);
                    Console.WriteLine("결과를 보려면 아무키나 누르세요.");
                    this.CreateWeapon(choice22);
                    Console.ReadLine();
                    Console.WriteLine("갓 탄생한 {0}에게서 왠지 모를 강인함이 느껴진다...", mgr.GetWeaponData(choice22).name);

                }
                else if (choice == "1")
                {
                    Console.WriteLine("강화할 무기를 선택해주세요.");
                    Console.WriteLine("0 -> {0} 강화\n1 -> {1} 강화", mgr.gi.startWeapon[0].name, mgr.gi.startWeapon[1].name);
                    string choice3 = Console.ReadLine();
                    int choice33;
                    int.TryParse(choice3, out choice33);
                    this.EnhanceWeapon(choice33);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("화로의 뜨거운 열기와 귀를 찌르는 금속음을 뒤로 하고 대장간을 나왔다.");
                    mgr.gi.mapInfo.mapIndex = 2;
                    break;
                }
            }
        }

        private void CreateWeapon(int id)
        {
            weapon_data info = mgr.GetWeaponData(id);
            Weapon weapon = new Weapon(info.id, info.name, info.damage, info.sellPrice, info.grade, 1, 50);
            mgr.gi.GetWeapon(weapon);
        }

        private void EnhanceWeapon(int i)
        {
            if(mgr.gi.startWeapon[i].name == "맨손" || mgr.gi.startWeapon[i].name == "없음")
            {
                Console.WriteLine("주인장 드워프 : 나더러 그걸 강화해달라는 건가?");
            } else
            {
                int beforeNum = mgr.gi.startWeapon[i].reinforcement;
                float beforeDamage = mgr.gi.startWeapon[i].damage;
                Console.WriteLine("{0}를 강화해보자!", mgr.gi.startWeapon[i].name);
                Console.WriteLine("주인장 드워프가 내 무기를 세차게 두들기고 담금질한다.");
                Console.WriteLine("결과를 보려면 아무키나 누르세요.");
                mgr.gi.startWeapon[i].reinforcement++;
                mgr.gi.startWeapon[i].damage += 1.5f;
                Console.ReadLine();
                Console.WriteLine("강화 성공!");
                Console.WriteLine("{0} {1}단계 -> {2}단계 / 무기 공격력 : {3} -> {4}",
                    mgr.gi.startWeapon[i].name, beforeNum, mgr.gi.startWeapon[i].reinforcement,
                    beforeDamage, mgr.gi.startWeapon[i].damage);
            }
        }
    }
}
