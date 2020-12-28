using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public  class EnvenStudent
    {
        public  string Name { get; set; }

        public  int age { get; set; }

        public int Age
        {
            get => age;
            set
            {
                if (value<=18)
                {
                    if (YongEnvet!= null) YongEnvet();

                }
                else if(value>19)
                {
                    if (OldEnvet!= null) OldEnvet();

                }
                else
                {
                    
                }
            }
        }

        //声明事件
        public event Action YongEnvet;

        public event Action OldEnvet;
    }
}
