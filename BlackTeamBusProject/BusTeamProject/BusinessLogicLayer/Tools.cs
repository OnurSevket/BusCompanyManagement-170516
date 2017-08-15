using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class Tools
    {

        #region WorkHours
        public static bool IsHours(string number)
        {
            bool result = false;
            string firstTwoCharacter = number.Substring(0, 2);
            string lastTwoCharacter = number.Substring(3, 2);
            string centerCharacter = number.Substring(2, 1);
            bool isIntfirsttwo = IsNumber(firstTwoCharacter);
            bool isIntlasttwo = IsNumber(lastTwoCharacter);
            if (isIntfirsttwo && isIntlasttwo)
            {
                if (int.Parse(firstTwoCharacter) >= 0 && int.Parse(firstTwoCharacter) <= 24 && int.Parse(lastTwoCharacter) >= 0 && int.Parse(lastTwoCharacter) <= 59 && centerCharacter == ":")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            return result;
        }


        public static bool IsNumber(string input)
        {
            int number;
            bool isInt = int.TryParse(input, out number);
            return isInt;
        }
        #endregion

        #region Travel
        public static bool isTravelNumberName(string number)
        {
            bool result = false;
            bool isNumberEightCharacter = IsNumber(number);//İlk 8 karakteri sayımı diye kontrol ediyoruz.
            if (!isNumberEightCharacter)
            {
                throw new Exception("Girilen TravelNumberName sayı değildir");
            }

            if (number.Length != 8)
            {
                throw new Exception("Girilen TravelNumberName 8 karakter değildir .");
            }

            string lastFourCharacterDivide = number.Substring(4, 2);//5. ve 6. karakter
            string lastTwoCharacter = number.Substring(6, 2);//Son iki karakter
            string isHourTravelName = lastFourCharacterDivide + ":" + lastTwoCharacter;

            bool returnHours = IsHours(isHourTravelName);//Saati yukardaki metoda gönderip sonuç geldi.

            string firstTwoCharacter = number.Substring(0, 2);//ilk iki karakteri
            string firstFourCharacterDivideby = number.Substring(2, 2);//3. ve 4. karakter değerleri alındı.

            if (isNumberEightCharacter)
            {
                if (int.Parse(lastFourCharacterDivide) >= 0 && int.Parse(lastFourCharacterDivide) <= 24 && int.Parse(lastTwoCharacter) >= 0 && int.Parse(lastTwoCharacter) <= 59 && int.Parse(firstTwoCharacter) <= 1 && int.Parse(firstTwoCharacter) >= 81 && int.Parse(firstFourCharacterDivideby) <= 1 && int.Parse(firstFourCharacterDivideby) >= 81)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            return result;
        } 
        #endregion



    }
}
