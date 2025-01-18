using AAD.ImmoWin.Business.Classes;

namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IAdres: IComparable, IComparable<IAdres>

    {
        string Gemeente { get; set; }
        string Nummer { get; set; }
        int Postnummer { get; set; }
        string Straat { get; set; }
    }
}