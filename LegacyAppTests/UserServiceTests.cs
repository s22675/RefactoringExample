using LegacyApp;

namespace TestProject1;

public class UserServiceTests
{
    
    [Fact]
    public void AddUser_Should_Return_False_Witout_Name()
    {
        string firstName = "";
        string lastName = "Malewski";
        string email = "malewski@gmail.pl";
        DateTime dateOfBirth = new DateTime(1999, 7, 8);
        int clientId = 2;

        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(false, result);
    }
    
        
    [Fact]
    public void AddUser_Should_Return_False_Have_CreditLimit()
    {
        string firstName = "Kamil";
        string lastName = "Kowalski";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(1979, 8, 15);
        int clientId = 1;

        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_Wrong_Email()
    {
        string firstName = "Ola";
        string lastName = "Doe";
        string email = "doegmail.pl";
        DateTime dateOfBirth = new DateTime(1979, 8, 15);
        int clientId = 4;

        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Is_Not_Adult()
    {
        string firstName = "Michał";
        string lastName = "Kwiatkowski";
        string email = "kwiatkowski@wp.pl";
        DateTime dateOfBirth = new DateTime(2018, 1, 6);
        int clientId = 5;

        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True()
    {
        string firstName = "Michał";
        string lastName = "Kwiatkowski";
        string email = "kwiatkowski@wp.pl";
        DateTime dateOfBirth = new DateTime(2000, 10, 6);
        int clientId = 5;

        var service = new UserService();

        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(true, result);
    }
}