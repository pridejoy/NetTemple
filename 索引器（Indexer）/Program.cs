using System;

namespace 索引器_Indexer_
{
    class IndexedNames
    {

        private string[] namelist = new string[size];
        static public int size = 10;

        //构造函数，为namelist初始值
        public IndexedNames()
        {
            for (int i = 0; i < size; i++)
                namelist[i] = "N. A.";
        }


        public string this[int index]
        {
             // get 访问器
            get
            {
                // 返回 index 指定的值
                string tmp;

                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            //// set 访问器
            set
            {
                // 设置 index 指定的值

                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
        }


    }

    class Program
    {
    

         static void Main(string[] args)
         {
            IndexedNames names = new IndexedNames();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";
            for (int i = 0; i < IndexedNames.size; i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.ReadKey();
        }
    }
    
}
