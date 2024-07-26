namespace ServiceProvider.Server.Modules.Interface
{
    public interface IPinCodeManager
    {
        public  Task<bool> CheckPinCode(string code);
    }
}
