using System;

namespace test115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 建英文字元轉換數值的字典
            Dictionary<char, int> letterMap = new Dictionary<char, int>()
            {
                {'A',10}, {'B',11}, {'C',12}, {'D',13}, {'E',14}, {'F',15}, {'G',16}, {'H',17},
                {'I',34}, {'J',18}, {'K',19}, {'L',20}, {'M',21}, {'N',22}, {'O',35}, {'P',23},
                {'Q',24}, {'R',25}, {'S',26}, {'T',27}, {'U',28}, {'V',29}, {'W',30}, {'X',41},
                {'Y',42}, {'Z',33}
            };

            //while直到n
            while (true)
            {
                Console.Write("請輸入身分證號碼：");
                string id = Console.ReadLine().ToUpper(); // 輸入，並轉為大寫

                // 第一階段檢查輸入格式是否合法（長度需為10，第一碼為字母，第二碼為數字）
                if (id.Length != 10 || !char.IsLetter(id[0]) || !char.IsDigit(id[1]))
                {
                    Console.WriteLine("身分證號碼不正確！@_@");
                }
                else
                {
                    char letter = id[0]; // 取出第一個字母
                    int[] weights = { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 }; // 權重表

                    int code = letterMap[letter]; // 查表轉換字母為對應數字
                    int d1 = code / 10; // 取十位數
                    int d2 = code % 10; // 取個位數

                    // 計算總和（前兩碼是英文字母轉數字後的拆解）
                    int sum = d1 * weights[0] + d2 * weights[1];

                    // 處理身分證剩下的 9 個數字（id[1] ~ id[9]）
                    for (int i = 1; i < 10; i++)
                    {
                        // 若有非數字，則視為錯誤輸入
                        if (!char.IsDigit(id[i]))
                        {
                            sum = -1;
                            break;
                        }

                        // 將每個數字乘上對應的權重並加總
                        sum += (id[i] - '0') * weights[i + 1];
                    }

                    // 驗證結果：若 sum % 10 == 0 則通過檢查
                    if (sum != -1 && sum % 10 == 0)
                        Console.WriteLine("身分證號碼正確！ ^_^");
                    else
                        Console.WriteLine("身分證號碼不正確！@_@");
                }

                // 是否繼續驗證
                Console.Write("是否繼續驗證？(Y/N)：");
                string again = Console.ReadLine();
                if (again.ToUpper() != "Y")
                    break; // 輸入非 Y（不論大小寫），則跳出迴圈
            }
        }
    }
}
