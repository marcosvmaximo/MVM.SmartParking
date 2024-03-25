namespace MVM.SmartParking.Company.API.Data.Interfaces;

public interface IUnityOfWork
{
    Task<bool> Commit();
}