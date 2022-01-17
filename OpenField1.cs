using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace helloworldConsoleApp1
{
    class OpenField1
    {
        DataMgr mgr = DataMgr.GetInstance();

        public OpenField1()
        {
            mgr.gi.mapInfo.mapIndex = 2;
            int mapProcess = mgr.gi.mapInfo.mapProcessNum;
            while(mapProcess < 10)
            {
                Console.WriteLine("{0}걸음 째...", (mapProcess + 1) * 300);
                Console.ReadLine();
                mgr.gi.mapInfo.mapProcessNum = mapProcess;
                if(mapProcess == 0)
                {
                    Console.WriteLine("\n사람 키만한 풀숲이 우거진 수풀지대에 도착했다.");
                }
                else if (mapProcess == 3)
                {
                    Console.WriteLine("<고블린 출몰 지역>");
                } else if(mapProcess == 6)
                {
                    Console.WriteLine("고블린이 모습을 드러냈다.");
                    Enemy goblin = new Enemy(1);
                    goblin.Init();
                    goblin.DisplayEnemyStatus();
                    Console.WriteLine("[전투 시작]");
                    Console.WriteLine("뭘 할까?\n0 -> 공격\n1 -> 도망\n2 -> 저장");
                    string choice = Console.ReadLine();
                    int choice2;
                    bool b = Int32.TryParse(choice, out choice2);
                    switch (choice2)
                    {
                        case 0:
                            mgr.gi.me.hp = 1;
                            int count = 0;
                            while (true)
                            {
                                if (mgr.gi.me.hp > 0)
                                {
                                    goblin.hp -= mgr.gi.startWeapon[0].damage;
                                    mgr.gi.startWeapon[0].durability--;
                                    count++;
                                    Console.WriteLine("{0}가 {5}{1} {2}의 피해를 입혔습니다.\n{3}의 남은 체력 {4}", mgr.gi.me.name,
                                        mgr.GetCharacterData(mgr.gi.me.id).default_attack_action_text, mgr.gi.startWeapon[0].damage,
                                        goblin.name, goblin.hp, mgr.gi.startWeapon[0].name);
                                    Console.WriteLine("{0} 남은 내구도 : {1}", mgr.gi.startWeapon[0].name, mgr.gi.startWeapon[0].durability);
                                    if(mgr.gi.startWeapon[0].durability <= 0)
                                    {
                                        Console.WriteLine("{0}이(가) 파괴되었습니다.", mgr.gi.startWeapon[0].name);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n혀에서 묽고 비린 피맛이 느껴진다. 입에서 막을 새도 없이 피가 뿜어져 나온다....\n치명상인 듯 하다.\n시야가 좁아진다..\n" +
                                        ".......................\n...............\n..........\n.\n              YOU DIED");
                                    File.Delete("game_info.json");
                                    mgr.dead = true;
                                    break;
                                }

                                if (goblin.hp > 0)
                                {
                                    Console.ReadLine();
                                    mgr.gi.me.hp -= goblin.damage;
                                    count++;
                                    Console.WriteLine("{0}이 얍삽한 몸놀림과 함께 뭉툭한 둔기로 옆구리를 가격한다.\n나의 남은 체력 {1} / {2}",
                                        goblin.name, mgr.gi.me.hp, mgr.gi.me.max_hp);
                                }
                                else
                                {
                                    Console.WriteLine("{0}이 쓰러졌다.", goblin.name);
                                }

                                if (mgr.gi.me.hp > 0 && goblin.hp <= 0)
                                {
                                    Console.WriteLine("{0}합 만에 승부가 났다...", count);
                                    mgr.gi.me.gold += goblin.reward;
                                    Console.ReadLine();
                                    Console.WriteLine("\n[전리품]\n+{0} Gold", goblin.reward);
                                    Console.ReadLine();
                                    break;
                                }
                                Console.ReadLine();
                            }
                            break;
                        case 1:
                            Console.WriteLine("무사히 도망치는 데 성공했다!");
                            Console.ReadLine();
                            break;
                        case 2:
                            mgr.SaveData();
                            Console.WriteLine("<저장 완료>");
                            Console.ReadLine();
                            mapProcess--;
                            break;
                    }
                }
                if (mgr.dead)
                {
                    break;
                }
                mapProcess++;
                mgr.SaveData();
            }
            if (!mgr.dead)
            {
                mgr.gi.mapInfo.mapProcessNum = 0;
                mgr.gi.mapInfo.mapIndex = 1;
                Console.WriteLine("살아서 수풀지대를 빠져나왔다!");
                Console.WriteLine("\n게임을 계속하시겠습니까? y/n");
                string tof = Console.ReadLine();
                if (tof == "y")
                {
                    Console.WriteLine("게임을 진행합니다.");
                    mgr.TurnOn = true;
                }
                else if (tof == "n")
                {
                    Console.WriteLine("게임을 중단합니다.");
                    mgr.TurnOn = false;
                }
            }
        }
    }
}
