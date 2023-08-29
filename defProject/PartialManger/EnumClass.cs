using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defProject.PartialManger
{
    // <summary>
    /// 물건 종류 및 값을 가지고 있는 Enum Data
    /// </summary>
    public enum EnumItem
    {
        고기 = 10000,
        과자 = 3000,
        계란 = 5000,
        물 = 800,
        라면 = 3500,
        즉석식품 = 6500,
        냉동식품 = 8500,
    }

    /// <summary>
    /// 할인율을 가지고 있는 EnumData
    /// </summary>
    public enum EnumRate
    {
        할인_3 = 3,
        할인_5 = 5,
        할인_10 = 10,
        할인_20 = 20,
        사장할인_80 = 80,
    }
    //Enum을 class 외부에서 사용하기 때문에 .cs File의 이름은 의미가 없음
    //class EnumClass
    //     class EnumClass
    //     {
    //     }
}
