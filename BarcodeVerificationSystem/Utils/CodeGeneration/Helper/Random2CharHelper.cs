using System;

public static class Random2CharHelper
{
    private static readonly string[] AllowedChars = new string[]
    {
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
        "B", "C", "D", "F", "G", "H", "J", "K", "L", "M",
        "N", "P", "Q", "R", "S", "T", "V", "X", "Y", "Z"
    };

    private static readonly Random Rand = new Random();

    /// <summary>
    /// Trả về mảng gồm 2 ký tự random từ bảng cho phép.
    /// </summary>
    /// <param name="allowDuplicate">Cho phép trùng ký tự hay không</param>
    /// <returns>string[] gồm 2 ký tự</returns>
    public static string[] GetTwoRandomChars(bool allowDuplicate = true)
    {
        int index1 = Rand.Next(AllowedChars.Length);
        int index2;

        if (allowDuplicate)
        {
            index2 = Rand.Next(AllowedChars.Length);
        }
        else
        {
            do
            {
                index2 = Rand.Next(AllowedChars.Length);
            } while (index2 == index1);
        }

        return new string[] { AllowedChars[index1], AllowedChars[index2] };
    }
}
