namespace _115test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] suits = { "黑桃", "紅心", "方塊", "梅花" };
            Random rand = new Random();

            Console.Write("請問你想比 (1)大 , (2)小 ? ");
            string input = Console.ReadLine();

            if (input != "1" && input != "2")
            {
                Console.WriteLine("輸入錯誤，請輸入 1 或 2");
                return;
            }

            Console.WriteLine("發牌中 ..");

            
            int userNumber = rand.Next(1, 14);
            string userSuit = suits[rand.Next(suits.Length)];

            int cpuNumber = rand.Next(1, 14);
            string cpuSuit = suits[rand.Next(suits.Length)];

            Console.WriteLine($"你拿到的牌是 {userSuit} {userNumber}");
            Console.WriteLine($"電腦拿到的牌是 {cpuSuit} {cpuNumber}");

            bool userWins = false;
            bool draw = false;

            if (userNumber == cpuNumber)
            {
                draw = true;
            }
            else if (input == "1")
            {
                userWins = userNumber > cpuNumber;
            }
            else if (input == "2")
            {
                userWins = userNumber < cpuNumber;
            }

            if (draw)
            {
                Console.WriteLine("平手！");
            }
            else if (userWins)
            {
                Console.WriteLine("你贏了 !");
            }
            else
            {
                Console.WriteLine("你輸了 !");
            }
        }
    }
}
