using OldPhoneKeyPad;

string? nextTry = "";

Console.WriteLine("***** Welcome from Phone KeyPad *****");

Console.WriteLine("33# =>" + " Output: " + OldPhonePadExtension.OldPhonePad("33#"));
Console.WriteLine("227*# =>" + " Output: " + OldPhonePadExtension.OldPhonePad("227*#"));
Console.WriteLine("4433555 555666# =>" + " Output: " + OldPhonePadExtension.OldPhonePad("4433555 555666#"));
Console.WriteLine("8 88777444666*664# =>" + " Output: " + OldPhonePadExtension.OldPhonePad("8 88777444666*664#"));

Console.WriteLine("Do you want to try by yourself? If yes, please type 'Y' or 'Yes'");
nextTry = Console.ReadLine();

while(nextTry?.ToLower() == "y" || nextTry?.ToLower() == "yes")
{
    Console.WriteLine("Please type your input : ");
    string? input = Console.ReadLine();

    string output = OldPhonePadExtension.OldPhonePad(input);
    Console.WriteLine("Output: " + output);

    Console.WriteLine("Type (Y or Yes) for next try!");
    nextTry = Console.ReadLine();
}