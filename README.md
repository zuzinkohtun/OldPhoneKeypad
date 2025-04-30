# OldPhoneKeypad
### 1. About the project
This project simulates text for an old mobile phone keypad, where multiple button presses represent different characters. It interprets input strings composed of digits, spaces, backspace (*), and a send key (#), then outputs the corresponding text message. It’s useful for demonstrating input parsing, control flow, and state management in C#.

### 2. How to install and run
1. Clone the repository:
   ```bash
   git clone [https://github.com/zuzinkohtun/OldPhoneKeypad.git]
2. Build the Project
Build the project to ensure that everything is set up correctly:

   ```bash
   dotnet build
   ```
3. Run the Application
Run the application using the following command:
   ```bash
   dotnet run
   ```
4. Run the Test
Run the application using the following command:
   ```bash
   dotnet test
   ```
 ### 3. Usage
- Run the program
- Enter the keypad sequence ending with #
- Get the decoded message!
- Valid characters:
  - 1: &’(
  - 2–9: Letters
  - 0: Space
  - *: Backspace
  - (space): Pause between letters on the same key
  - #: End and decode input
