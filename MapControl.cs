using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class MapControl
    {
        public int mapIndex;//맵, 지역이 바뀔 때마다 그 지역의 인덱스를 할당시켜야 함.
        public int mapProcessNum;//맵, 지역이 바뀔 때마다 0으로 초기화시켜야 함.
        
        public void Init()
        {
            this.mapIndex = 0;
            this.mapProcessNum = 0;
        }
    }
}
