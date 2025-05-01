# Old Phone Keypad
### About the project
This project simulates the behavior of a traditional mobile phone keypad for typing letters using multiple keypresses. The goal is to interpret a string of numeric inputs and convert it into readable text.

### Project Structure
```
OldPhoneKeypad/
│
├── src/
│   └── OldPHoneKeypad/                # Console App
│   │   └── OldPhonePadExtension.cs
│   │   └── Program.cs
├── tests/
│   └── OldPHoneKeypad.Test/                # Unit Test
│   │   └── OldPhonePadTest.cs
```
### Setup Instructions
1. Prerequisites
    - .NET 9.0 SDK
    - Visual Studio / Visual Studio Code / Rider
2. Installation
    1. Clone the repository:
    ```bash
    git clone [https://github.com/zuzinkohtun/OldPhoneKeypad.git]
    ```
    2. Navigate to project:
    ```bash
    cd src/OldPhoneKeypad
    ```
    3. Run the app
    ``` bash
    dotnet run
    ```
3. Input format
```
| Key   | Meaning                    |
|-------|----------------------------|
| 1     | &’(      |
| 2–9   | Letters (multi-press)      |
| 0     | Space                      |
| *     | Backspace (delete letter)  |
| (space) | Pause between same-key presses |
| #     | Send / end of input        |
```
#### Example
- 33# => output: E
- 227*# => output: B
- 4433555 555666# => output: HELLO
- 8 88777444666*664# => output: TRUING

### Features
- Key mapping based on traditional keypads
- Backspace and pause handling
- Modular, testable code
- Input validation with friendly error messages
- Validates that input ends with #

### Unit Tests
``` bash
    cd tests/OldPhoneKeypad.Test
```
``` bash
    dotnet test
```
### Test Cases
```
| Input                        | Expected Output | Description                                      |
|-----------------------------|-----------------|--------------------------------------------------|
| `33#`                       | `E`             | Simple input from key `3` (pressed twice)        |
| `227*#`                     | `B`             | Backspace removes the last `7`                   |
| `4433555 555666#`           | `HELLO`         | Full word with pauses (` `) between key groups   |
| `8 88777444666*664#`        | `TURING`          | Complex input with backspace and same-key pause  |
| `777782777 7777#`                | `STARS`            | Same character repeated with a pause             |
| `#`                        | ``             | Empty on empty input |
| `2 22 222 2222#`        | `ABCA`          |  Process on cycle keys |
| `84426655099966688#`        | `THANK YOU`          | Complex data  |
```
