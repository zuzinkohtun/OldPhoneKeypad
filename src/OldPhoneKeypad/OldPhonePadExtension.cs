using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace OldPhoneKeyPad;
public class OldPhonePadExtension
{
    private static readonly List<KeyStore>? keys = new();
    private static readonly Dictionary<char, int> keyRange = new();

    static OldPhonePadExtension()
    {
        string filePath = "KeyStore.json";

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            keys = JsonSerializer.Deserialize<List<KeyStore>>(jsonData);

            //Calculate key ranges to avoid the over range
            foreach (var key in keys)
            {
                char keyCharacter = (string.IsNullOrEmpty(key.value)) ? '\0' : char.ToUpper(key.key[0]);
                if (keyRange.ContainsKey(keyCharacter)) keyRange[keyCharacter]++;
                else keyRange.Add(keyCharacter, 1);
            }
        }
        else
        {
            Console.WriteLine("JSON file not found.");
        }
    }

    public static string OldPhonePad(string? input)
    {
        // Early return for null data
        if (string.IsNullOrEmpty(input)) return ""; 

        // Check to end with '#'
        if (input[^1] != '#')
            return "Input value must end with '#'. Please try again. Thanks";

        // Transform to listed string value
        var listedValue = SplitDataAsList(input);

        // Decode to string from listed string as digits and characters
        return DecodeString(listedValue);
    }

    private static string DecodeString(List<string> requestValue)
    {
        string result = string.Empty;
        foreach (var each in requestValue)
        {
            if (each == "#") return result;
            else if (each == "*")
                result = (string.IsNullOrEmpty(result)) ? result : result.Substring(0, result.Length - 1);

            else
                result += keys?.Where(k => k.key == each).Select(k => k.value).FirstOrDefault();
        }
        return result;
    }

    private static List<string> SplitDataAsList(string input)
    {
        var result = new List<string>();
        var splitValue = input.Split(' ');

        foreach (var eachValue in splitValue)
        {
            var multiTimeData = String.Empty;
            for (int i = 0; i < eachValue.Length; i++)
            {
                // If have same value in next index
                if (i < eachValue.Length - 1 && eachValue[i] == eachValue[i + 1] && eachValue[i] != '*')
                {
                    multiTimeData += eachValue[i];
                    continue;
                }
                // For one time character or digit
                else if (string.IsNullOrEmpty(multiTimeData)) 
                    result.Add(eachValue[i].ToString());   
                // For multi-time input characters or digits          
                else
                {
                    multiTimeData += eachValue[i];
                    // Checking the range and then calculate if over
                    if (keyRange.ContainsKey(eachValue[i]))
                    {
                        int acceptableRange = keyRange[eachValue[i]];
                        // Recalculate the value if over the range
                        if ((multiTimeData.Length > acceptableRange))
                        {
                            multiTimeData = multiTimeData.Substring(0, multiTimeData.Length % acceptableRange);
                        }
                    }
                    result.Add(multiTimeData);
                    multiTimeData = String.Empty; // Reset data as null
                }
            }
        }
        return result;
    }
}