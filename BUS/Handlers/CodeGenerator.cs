namespace BUS.Handlers
{
    public class CodeGenerator
    {
        public static string Generate()
        {
            string code = string.Empty;
            int a = new int();
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                a = random.Next(0, 9);
                code += a.ToString();
            }
            return code;
        }
    }
}