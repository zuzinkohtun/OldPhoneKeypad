using OldPhoneKeyPad;

string? nextTry = "";

Console.WriteLine("***** Welcome from Phone KeyPad *****");
do{
    Console.WriteLine("Please type your input : ");
    string? input = Console.ReadLine();

    string output = OldPhonePadExtension.OldPhonePad(input);
    Console.WriteLine("Output: " + output);

    Console.WriteLine("Type (Y or Yes) for next try!");
    nextTry = Console.ReadLine();

}while(nextTry?.ToLower() == "y" || nextTry?.ToLower() == "yes");

