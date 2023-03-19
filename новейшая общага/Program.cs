
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace новейшая_общага
{
    class Stud
    {
        public string fio;
        public string group;
        public string[] dis;
        public int[] oze;
        public Stud(string fio, string group, string[] dis, int[] oze)
        {
            this.fio = fio;
            this.group = group;
            this.dis = dis;
            this.oze = oze;
        }
    }
    class Group
    {
        public string name;
        public string[] subj;
        public Group(string name, string[] subj) 
        {
            this.name = name;
            this.subj = subj;
        }
    }
    class SubGr
    {
        public string name;
        public string[] subj;
        public SubGr(string name, string[] subj)
        {
            this.name = name;
            this.subj = subj;
        }
    }
    class Prep
    {
        public string fio;
        public SubGr[] groups;
        public Prep(string fio, SubGr[] groups)
        {
            this.fio = fio;
            this.groups = groups;
        }
    }
    class Upr
    {
        public string fio;
        public string chin;
        public Ukaz[] ukaz;
        public Upr(string fio,string chin, Ukaz[] ukaz)
        {
            this.fio = fio;
            this.chin = chin;
            this.ukaz = ukaz;
        }
    }
    class Ukaz
    {
        public string name;
        public string type;
        public string author;
        public Ukaz(string name,string type,string author)
        {
            this.name = name;
            this.type = type;
            this.author = author;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Stud> St = new List<Stud>();
            List<Prep> Pr = new List<Prep>();
            List<Upr> Up = new List<Upr>();
            List<Ukaz> Uk = new List<Ukaz>();
            List<Group> Gr = new List<Group>();


            while (true)
            {
                Console.WriteLine(@"
1. Пополнить базу
2. Поиск по указам
3. Поиск по преподавателям
4. Поиск по студентам
5. Завершить работу программы");
                string a = Console.ReadLine();
                Console.Clear();
                if (a == "1")
                {
                    Console.WriteLine(@"
1. Добавить студента
2. Добавить преподавателя
3. Добавить управляющего + его указы
4. Вернуться в главное меню");
                    string b = Console.ReadLine();
                    Console.Clear();
                    if (b == "1")
                    {
                        int flag = 0;
                        Console.WriteLine("Введите фио студента");
                        string fio = Console.ReadLine();
                        Console.WriteLine("Введите группу студента");
                        string group = Console.ReadLine();
                        for (int i = 0; i < Gr.Count; i++)
                        {
                            if (group == Gr[i].name)
                            {
                                flag = 1;
                            }
                        }
                        if (flag == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Такой группы нет в базе. Желаете добавить?\nДа - введите '1'\n2. Нет - введите, что-либо кроме '1'");
                            string c = Console.ReadLine();
                            if (c == "1")
                            {
                                Console.WriteLine("Введите название группы");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите количество дисциплин у группы");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                string[] subj = new string[ch];
                                for (int t = 0; t < ch; t++)
                                {
                                    Console.WriteLine("Введите название {0} предмета", t + 1);
                                    subj[t] = Console.ReadLine();
                                }
                                Gr.Add(new Group(name, subj));
                                flag = 1;
                            }
                        }
                        if (flag == 1)
                        {
                            string[] dis=new string[0];
                            for (int t = 0; t < Gr.Count; t++)
                            {
                                if (Gr[t].name == group)
                                {
                                    dis = Gr[t].subj;
                                    break;
                                }
                            }
                            int[] oze = new int[dis.Length];
                            for (int t = 0; t < dis.Length; t++)
                            {
                                Console.WriteLine("Введите оценку студента по '{0}'", dis[t]);
                                oze[t] = Convert.ToInt32(Console.ReadLine());
                            }
                            St.Add(new Stud(fio, group, dis, oze));
                        }
                        Console.Clear();
                    }
                    else if (b == "2")
                    {
                        Console.WriteLine("Введите ФИО преподавателя");
                        string fio = Console.ReadLine();
                        Console.WriteLine("Введите число групп, у которых он преподаёт");
                        int cr = Convert.ToInt32(Console.ReadLine());
                        SubGr[] groups = new SubGr[cr];
                        for (int r = 0; r < cr; r++)
                        {
                            int flag = 0;
                            Console.WriteLine("Введите название {0} группы", r + 1);
                            string group = Console.ReadLine();
                            for (int i = 0; i < Gr.Count; i++)
                            {
                                if (group == Gr[i].name)
                                {
                                    flag = 1;
                                }
                            }
                            if (flag == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Такой группы нет в базе. Желаете добавить?\nДа - введите '1'\n2. Нет - введите, что-либо кроме '1'");
                                string c = Console.ReadLine();
                                if (c == "1")
                                {
                                    Console.WriteLine("Введите название группы");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Введите количество дисциплин у группы");
                                    int ch = Convert.ToInt32(Console.ReadLine());
                                    string[] subj = new string[ch];
                                    for (int t = 0; t < ch; t++)
                                    {
                                        Console.WriteLine("Введите рназвание {0} предмета", t + 1);
                                        subj[t] = Console.ReadLine();
                                    }
                                    Gr.Add(new Group(name, subj));
                                    flag = 1;
                                }
                            }
                            int tr=0;
                            for (int p = 0; p < Gr.Count; p++)
                            {
                                if (Gr[p].name == group)
                                {
                                     tr = p;
                                    break;
                                }
                            }
                            Console.WriteLine("Сколько дисциплин ведёт этот преподаватель в этой группе?");
                            int Sub2 = Convert.ToInt32(Console.ReadLine());
                            string[] subj2 = new string[Sub2]; int kl = 0;
                            for (int e=0; e < Gr[tr].subj.Length; e++)
                            {
                                Console.WriteLine("Он ведёт {0}?\nНет - введите '1'\nДа - введите что-либо кроме '1'", Gr[tr].subj[e]);
                                string g = Console.ReadLine();
                                if (g != "1")
                                {
                                    subj2[kl] = Gr[tr].subj[e];
                                    kl++;
                                }
                                if (kl == Sub2) { break; }
                            }
                            SubGr Da = new SubGr(group, subj2);
                            groups[r] = Da;
                        }
                        Pr.Add(new Prep(fio, groups));
                    }
                    else if (b == "3")
                    {
                        Console.WriteLine("Введите ФИО управляющего");
                        string fio = Console.ReadLine();
                        Console.WriteLine("Введите должность управляющего");
                        string chin = Console.ReadLine();
                        Console.WriteLine("Введите число указов по его авторством");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Ukaz[] ukaz = new Ukaz[c];
                        for (int t = 0; t < c; t++)
                        {
                            Console.WriteLine("Введите название {0} указа", t + 1);
                            string name = Console.ReadLine();
                            Console.WriteLine("Для кого предназначен указ:\nДля студентов - S\nДля преподавателей - P\nДля прочего персонала - O\n Для Всех - A");
                            string type = Console.ReadLine();
                            Ukaz Da = new Ukaz(name, type, fio);
                            Uk.Add(Da);
                            ukaz[t] = Da;
                        }
                        Up.Add(new Upr(fio, chin, ukaz));
                    }
                    else if (b=="4")
                    {
                        Console.WriteLine("Требуется подтверждение:");
                    }
                    else
                    {
                        Console.WriteLine("Такого пункта не существует");
                    }
                }
                else if (a == "2")
                {
                    Console.WriteLine(@"
1. Найти указы для студентов
2. Найти указы для преподавателей
3. Найти указы для другого персонала
4. Найти указы для всех");
                    string b = Console.ReadLine();
                   if (b == "1")
                    {
                         for (int t = 0; t < Uk.Count; t++)
                        {
                            if ((Uk[t].type == "S")||(Uk[t].type == "A"))
                            {
                                Console.WriteLine("{0,20}    {1,20}", Uk[t].name, Uk[t].author);
                            }
                        }
                    }
                    else if (b == "2")
                    {
                        for (int t = 0; t < Uk.Count; t++)
                        {
                            if ((Uk[t].type == "P") || (Uk[t].type == "A"))
                            {
                                Console.WriteLine("{0,20}    {1,20}", Uk[t].name, Uk[t].author);
                            }
                        }
                    }
                    else if (b == "3")
                    {
                        for (int t = 0; t < Uk.Count; t++)
                        {
                            if ((Uk[t].type == "O") || (Uk[t].type == "A"))
                            {
                                Console.WriteLine("{0,20}    {1,20}", Uk[t].name, Uk[t].author);
                            }
                        }
                    }
                    else if (b == "4")
                    {
                        for (int t = 0; t < Uk.Count; t++)
                        {
                            if (Uk[t].type == "A")
                            {
                                Console.WriteLine("{0,20}    {1,20}", Uk[t].name, Uk[t].author);
                            }
                        }
                    }
                }
                else if (a == "3")
                {
                    Console.WriteLine("Выберите преподавателя, введя его номер в списке");
                    for (int t = 0; t < Pr.Count; t++)
                    {
                        Console.WriteLine("{0}. {1}", t + 1, Pr[t].fio);
                    }
                    int b = Convert.ToInt32(Console.ReadLine())-1;
                    for (int t = 0; t < Pr[b].groups.Length; t++)
                    {
                        for (int w = 0; w < St.Count; w++)
                        {
                            if (St[w].group == Pr[b].groups[t].name)
                            {
                                int klop = 0;
                                for (int r = 0; r < Pr[b].groups[t].subj.Length; r++)
                                {
                                    for(int d = 0; d < St[w].dis.Length; d++)
                                    {
                                        if ((St[w].dis[d]== Pr[b].groups[t].subj[r]) &&(St[w].oze[d]<=2))
                                        {
                                            Console.WriteLine("{0,20}  {1,10}  {2,5}", St[w].fio, St[w].group, St[w].dis[d]);
                                            klop = 1;
                                            break;
                                        }
                                    }
                                    if (klop == 1) { break; }
                                }
                            }
                        }
                    }
                }
                else if (a == "4")
                {
                    Console.WriteLine("Введите группу интересуещего вас студента");
                    string b = Console.ReadLine();
                    Console.WriteLine("Выберите студента, введя его номер в списке");
                    int pop = 1;
                    for (int t = 0; t < St.Count; t++)
                    {
                        if (St[t].group == b)
                        {
                            Console.WriteLine("{0}  {1,20}", pop, St[t].fio);
                            pop++;
                        }
                    }
                    int c = Convert.ToInt32(Console.ReadLine())-1;
                    for (int t = 0; t < St[c].dis.Length; t++)
                    {
                        if (St[c].oze[t] <= 2)
                        {
                            for (int r = 0; r < Pr.Count; r++)
                            {
                                for (int p = 0; p < Pr[r].groups.Length; p++)
                                {
                                    if (Pr[r].groups[p].name == St[c].group)
                                    {
                                        for (int k = 0; k < Pr[r].groups[p].subj.Length; k++)
                                        {
                                            if (Pr[r].groups[p].subj[k] == St[c].dis[t])
                                            {
                                                Console.WriteLine("{0,10}  {0,20}", St[c].dis[t], Pr[r].fio);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (a == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Такого пункта не существует");
                }
                Console.WriteLine("Для возврата в меню нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
