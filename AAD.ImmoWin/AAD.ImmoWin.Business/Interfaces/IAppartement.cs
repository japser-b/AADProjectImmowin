namespace AAD.ImmoWin.Business.Interfaces
{
    public interface IAppartement: IWoning, IComparable, IComparable<IAppartement>
    {
        int Verdieping { get; set; }
    }
}