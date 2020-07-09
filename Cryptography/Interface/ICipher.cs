namespace Cryptography.Interface
{
    public interface ICipher
    {
        string Encode(string value);
        string Decode(string value);
    }
}