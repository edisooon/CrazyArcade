using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI
{
    public sealed class UI_Singleton
    {
        private static UI_Singleton instance = null;
        private static readonly object padlock = new object();

        UI_Singleton()
        {
        }

        public static UI_Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UI_Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}
