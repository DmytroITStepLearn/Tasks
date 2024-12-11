using AbstractionHomework.Models;

namespace AbstractionHomework.Tests;

public class UnitTests
{
    private const string CurrentAssembly = "AbstractionHomework";

    [Fact]
    public void Classes_ShouldInheritFromBaseClass()
    {
        var student = new Student();
        var manager = new Manager();
        var worker = new Worker();

        Assert.True(student is Employee, "class Student should inherit classEmployee");
        Assert.True(manager is Employee, "class Manager should inherit classEmployee");
        Assert.True(worker is Employee, "class Worker should inherit classEmployee");
    }

    [Fact]
    public void Employee_ShouldBeAbstract()
    {
        var isAbstract = typeof(Employee).IsAbstract;

        Assert.True(isAbstract);
    }

    [Fact]
    public void Employee_ShouldHaveToPayMethod_ReturningInt()
    {
        var toPayMethod = typeof(Employee).GetMethod("ToPay");

        Assert.NotNull(toPayMethod);
        Assert.True(toPayMethod.IsAbstract, "ToPay should be an abstract method.");
        Assert.Equal(typeof(int), toPayMethod.ReturnType);
    }

    [Fact]
    public void IHasSalary_Interface_ShouldExistInModelsFolder() => CheckInterfaceExist();

    [Fact]
    public void IHasSalary_Interface_ShouldHaveSalaryProperty()
    {
        var interfaceType = CheckInterfaceExist();

        var salaryProperty = interfaceType.GetProperty("Salary");

        Assert.NotNull(salaryProperty);
        Assert.Equal(typeof(int), salaryProperty.PropertyType);
    }

    [Fact]
    public void IHasSalary_Interface_ShouldHaveSetBonusMethod()
    {
        var interfaceType = CheckInterfaceExist();

        var setBonusMethod = interfaceType.GetMethod("SetBonus");

        Assert.NotNull(setBonusMethod);
        Assert.Equal(typeof(void), setBonusMethod.ReturnType);
    }

    [Fact]
    public void Manager_ShouldImplementIHasSalary()
    {
        var managerType = typeof(Manager);

        var implementsInterface = managerType.GetInterfaces().Any(i => i.Name == "IHasSalary");

        Assert.True(implementsInterface, "Manager should implement IHasSalary interface.");
    }

    [Fact]
    public void Worker_ShouldImplementIHasSalary()
    {
        var workerType = typeof(Worker);

        var implementsInterface = workerType.GetInterfaces().Any(i => i.Name == "IHasSalary");

        Assert.True(implementsInterface, "Worker should implement IHasSalary interface.");
    }

    [Fact]
    public void Manager_ShouldHaveEmployeeCountProperty()
    {
        var property = typeof(Manager).GetProperty("EmployeeCount");

        Assert.NotNull(property);
        Assert.Equal(typeof(int), property.PropertyType);
        Assert.True(property.CanRead, "EmployeeCount property should be readable.");
        Assert.True(property.CanWrite, "EmployeeCount property should be writable.");
    }

    [Fact]
    public void Student_ShouldHaveAvarageGradeProperty()
    {
        var property = typeof(Student).GetProperty("AvarageGrade");

        Assert.NotNull(property);
        Assert.Equal(typeof(double), property.PropertyType);
        Assert.True(property.CanRead, "AvarageGrade property should be readable.");
        Assert.True(property.CanWrite, "AvarageGrade property should be writable.");
    }

    [Fact]
    public void Worker_ShouldHaveWorkedHoursProperty()
    {
        var property = typeof(Worker).GetProperty("WorkedHours");

        Assert.NotNull(property);
        Assert.Equal(typeof(int), property.PropertyType);
        Assert.True(property.CanRead, "WorkedHours property should be readable.");
        Assert.True(property.CanWrite, "WorkedHours property should be writable.");
    }

    [Fact]
    public void Student_ToPay_ShouldReturn2000_WhenAverageGradeIs35OrMore()
    {
        var student = Activator.CreateInstance(typeof(Student));
        var averageGradeProperty = student.GetType().GetProperty("AvarageGrade");
        Assert.NotNull(averageGradeProperty);

        averageGradeProperty.SetValue(student, 3.5);

        var toPayMethod = student.GetType().GetMethod("ToPay");
        Assert.NotNull(toPayMethod);

        var result = toPayMethod.Invoke(student, null);

        Assert.Equal(2000, result);
    }

    [Fact]
    public void Worker_ToPay_ShouldReturnSalaryTimesWorkedHours_WhenWorkedHoursIs40OrLess()
    {
        var worker = Activator.CreateInstance(typeof(Worker));
        var salaryProperty = worker.GetType().GetProperty("Salary");
        var workedHoursProperty = worker.GetType().GetProperty("WorkedHours");

        Assert.NotNull(salaryProperty);
        Assert.NotNull(workedHoursProperty);

        salaryProperty.SetValue(worker, 20); // Example Salary: 20
        workedHoursProperty.SetValue(worker, 40); // Worked Hours: 40

        var toPayMethod = worker.GetType().GetMethod("ToPay");
        Assert.NotNull(toPayMethod);

        var result = toPayMethod.Invoke(worker, null);

        Assert.Equal(20 * 40, result);
    }

    [Fact]
    public void Worker_ToPay_ShouldReturnAdjustedPay_WhenWorkedHoursIsGreaterThan40()
    {
        var worker = Activator.CreateInstance(typeof(Worker));
        var salaryProperty = worker.GetType().GetProperty("Salary");
        var workedHoursProperty = worker.GetType().GetProperty("WorkedHours");

        Assert.NotNull(salaryProperty);
        Assert.NotNull(workedHoursProperty);

        salaryProperty.SetValue(worker, 20); // Example Salary: 20
        workedHoursProperty.SetValue(worker, 45); // Worked Hours: 45

        var toPayMethod = worker.GetType().GetMethod("ToPay");
        Assert.NotNull(toPayMethod);

        var result = toPayMethod.Invoke(worker, null);

        Assert.Equal((20 + 50) * 45, result);
    }

    [Theory]
    [InlineData(4, 5000, 5000)] // Less than 5 employees
    [InlineData(7, 5000, 5700)] // Between 6 and 10 employees
    [InlineData(11, 5000, 10000)] // Greater than 10 employees
    public void Manager_ToPay_ShouldReturnCorrectValue_BasedOnEmployeeCount(int employeeCount, int salary, int expectedPay)
    {
        var manager = Activator.CreateInstance(typeof(Manager));
        var salaryProperty = manager.GetType().GetProperty("Salary");
        var employeeCountProperty = manager.GetType().GetProperty("EmployeeCount");

        Assert.NotNull(salaryProperty);
        Assert.NotNull(employeeCountProperty);

        salaryProperty.SetValue(manager, salary);
        employeeCountProperty.SetValue(manager, employeeCount);

        var toPayMethod = manager.GetType().GetMethod("ToPay");
        Assert.NotNull(toPayMethod);

        var result = toPayMethod.Invoke(manager, null);

        Assert.Equal(expectedPay, result);
    }

    [Fact]
    public void Worker_SetBonus_ShouldAddBonusToSalary()
    {
        var worker = Activator.CreateInstance(typeof(Worker));
        var salaryProperty = worker.GetType().GetProperty("Salary");
        var setBonusMethod = worker.GetType().GetMethod("SetBonus");

        Assert.NotNull(salaryProperty);
        Assert.NotNull(setBonusMethod);

        salaryProperty.SetValue(worker, 1000); // Example Salary: 1000
        var bonus = 200;

        setBonusMethod.Invoke(worker, new object[] { bonus });

        var updatedSalary = (int)salaryProperty.GetValue(worker);
        Assert.Equal(1200, updatedSalary); // 1000 + 200
    }

    [Fact]
    public void Manager_SetBonus_ShouldAddBonusToSalaryPlusEmployeeCountTimesTen()
    {
        var manager = Activator.CreateInstance(typeof(Manager));
        var salaryProperty = manager.GetType().GetProperty("Salary");
        var employeeCountProperty = manager.GetType().GetProperty("EmployeeCount");
        var setBonusMethod = manager.GetType().GetMethod("SetBonus");

        Assert.NotNull(salaryProperty);
        Assert.NotNull(employeeCountProperty);
        Assert.NotNull(setBonusMethod);

        salaryProperty.SetValue(manager, 5000); // Example Salary: 5000
        employeeCountProperty.SetValue(manager, 5); // EmployeeCount: 5
        var bonus = 300;

        setBonusMethod.Invoke(manager, new object[] { bonus });

        var updatedSalary = (int)salaryProperty.GetValue(manager);
        Assert.Equal(5350, updatedSalary); // 5000 + 300 + (5 * 10)
    }

    private Type CheckInterfaceExist()
    {
        var interfaceType = Type.GetType($"{CurrentAssembly}.Models.IHasSalary, {CurrentAssembly}");

        Assert.NotNull(interfaceType);

        return interfaceType;
    }
}

