using AAD.ImmoWin.Business.Classes;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IWoning: IComparable, IComparable<IWoning>
    {
        IAdres Adres { get; set; }
        DateOnly Bouwdatum { get; set; }
        decimal Waarde { get; set; }
    }
}