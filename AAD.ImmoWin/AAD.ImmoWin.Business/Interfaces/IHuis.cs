using AAD.ImmoWin.Business.Classes;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IHuis: IWoning
    {
        Soort Type { get; set; }
    }
}