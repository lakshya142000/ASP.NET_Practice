namespace WebApplication2.Models
{
    public class EmployeeManager
    {
        public static List<Employee> EmpList = new List<Employee>();
        public EmployeeManager()
        {
            EmpList = new List<Employee>()
            {
                new Employee(){EmpNo=101,Ename="Scott",Job="Manager",Salary=20000,DeptNo=20},
                new Employee(){EmpNo=102,Ename="Jack",Job="Developer",Salary=20000,DeptNo=25},
                new Employee(){EmpNo=103,Ename="Sam",Job="Trainee",Salary=10000,DeptNo=15},
                new Employee(){EmpNo=104,Ename="Henry",Job="Tester",Salary=17000,DeptNo=22}
            };
        }
        public List<Employee> GetData()
        {
            return EmpList;
        }
        public Employee GetByEmpNo(int Eno)
        {
            return EmpList.Find(item => item.EmpNo == Eno);
        }
        public void addEmployee(Employee obj)
        {
            EmpList.Add(obj);
        }
        public void UpdateDetails(Employee details)
        {
            Employee employee = EmpList.Find(item => item.EmpNo == details.EmpNo);
            EmpList.Remove(employee);
            EmpList.Add(details);

        }
        public void DeleteEmp(int Empno)
        {
            Employee empl = EmpList.Find(item => item.EmpNo == Empno);
            EmpList.Remove(empl);
        }

    }
}
