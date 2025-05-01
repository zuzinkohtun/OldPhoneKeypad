using OldPhoneKeyPad;
namespace OldPhoneKeypad.Test;

public class OldPhoneKeypadTests
{
    [Fact]
    public void ShouldReturnE()
    {
        var result = OldPhonePadExtension.OldPhonePad("33#");
        Assert.Equal("E", result);
    }

    [Fact]
    public void ShouldReturnB()
    {
        var result = OldPhonePadExtension.OldPhonePad("227*#");
        Assert.Equal("B", result);
    }

    [Fact]
    public void ShouldReturnHello()
    {
        var result = OldPhonePadExtension.OldPhonePad("4433555 555666#");
        Assert.Equal("HELLO", result);
    }

    [Fact]
    public void ShouldReturnTuring()
    {
        var result = OldPhonePadExtension.OldPhonePad("8 88777444666*664#");
        Assert.Equal("TURING", result);
    }

    [Fact]
    public void ShouldReturnStars()
    {
        var result = OldPhonePadExtension.OldPhonePad("777782777 7777#");
        Assert.Equal("STARS", result);
    }

    [Fact]
    public void ShouldHandleEndingWithBackspace()
    {
        var result = OldPhonePadExtension.OldPhonePad("44*#");
        Assert.Equal("", result);
    }

    [Fact]
    public void ShouldReturnEmptyOnEmptyInput()
    {
        var result = OldPhonePadExtension.OldPhonePad("#");
        Assert.Equal("", result);
    }

    [Fact]
    public void ShouldCycleKeys()
    {
        var result = OldPhonePadExtension.OldPhonePad("2 22 222 2222#"); // A, B, C, A
        Assert.Equal("ABCA", result);
    }

    [Fact]
    public void ShouldReturnThankYou()
    {
        var result = OldPhonePadExtension.OldPhonePad("84426655099966688#");
        Assert.Equal("THANK YOU", result);
    }

}
