namespace OldPhoneKeyPad;
public class OldPhonePadExtension{
    private static readonly Dictionary<char, string> keypad = new Dictionary<char, string>
    {
        { '1', "&'(" },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " }
    };

    public static string OldPhonePad(string? input){
        if(string.IsNullOrEmpty(input)) return "";
        
        if (input[^1] != '#')
            return "Input value must end with '#'. Please try again. Thanks";

        string currentValue = string.Empty;
        char lastChar = '\0';   
        string result = string.Empty;

        for(int i=0;i<input.Length;i++){
            char currentData = input[i];
            char nextChar = '\0';

            switch(currentData){
                case '#': // For end case
                    return result;
                case ' ': // For encoding the character
                    result += MapCharacter(currentValue);
                    // Reset the current values
                    currentValue = string.Empty;
                    lastChar = '\0';
                    break;
                case '*': // For delete case
                    result = (string.IsNullOrEmpty(result)? result : result.Substring(0,result.Length-1));
                    break;
                default: // Actual processing
                    if(currentData == lastChar || currentValue == "") {
                        currentValue += currentData;
                        nextChar = input[i + 1];
                        if(currentData != nextChar) {
                            result += MapCharacter(currentValue);
                            currentValue = ""; 
                        }
                    }
                    else{
                        result += MapCharacter(currentValue);
                        currentValue = currentData.ToString(); 
                    }
                    lastChar = currentData;
                    break;
            }
        }  
        return result;  
    }

    private static string MapCharacter(string currentValue){
        if(string.IsNullOrWhiteSpace(currentValue)) return currentValue;

        char keyChar = currentValue[0];
        if(!keypad.ContainsKey(keyChar)) return "";

        string currentLetters = keypad[keyChar];

        int index = (currentValue.Length - 1) % currentLetters.Length; // To avoid over value
        return currentLetters[index].ToString();
    }
}