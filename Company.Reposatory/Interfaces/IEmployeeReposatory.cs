using Company.Data.Models;
using Company.Reposatory.Reposatory;
namespace Company.Reposatory.Interfaces
{
    public interface IEmployeeReposatory: IGenaricReopsatory<Employee>
    {


        IEnumerable< Employee?> GetEmployeeByName(string name);
        IEnumerable<Employee> GetEmployeesByAddress(string Address);





        //Employee GetById(int id);
        //IEnumerable<Employee> GetAll();

        //void Update(Employee employee);
        //void  Delete (Employee employee);

        //void Add (Employee employee);


    }
}
