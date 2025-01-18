using AAD.ImmoWin.Business.Classes;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IKlant: IComparable, IComparable<IKlant>
    
    {
        string Familienaam { get; set; }
        string Voornaam { get; set; }
        List<IWoning> Woningen { get; set; }

        void VoegWoningToe(IWoning woning);
    }
}