using System.Collections.Generic;
using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Application.Users;
using Lab5.Application.Contracts.Facades;
using Lab5.Application.Models;
using Lab5.Application.Models.Users;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TransactionsTests
{
    private User? _user;
    private BankAccount _bankAccount = new BankAccount(5, 100);
    private UserRole _userRole;
    private Mock<IUserRepository> _userRepMock = new();
    private Mock<IBankAccountRepository> _bankRepMock = new();
    private Mock<ITransactionsRepository> _tranRepMock = new();
    [Fact]
    public async Task WithdrawingMoneyFromAnAccount()
    {
        _bankRepMock.Setup(m => m.GetAllAccounts(5)).ReturnsAsync(new List<BankAccount>() { _bankAccount });
        _bankRepMock.Setup(m => m.Update(5, 10, "Removal")).ReturnsAsync(true);
        _tranRepMock.Setup(m => m.RegisterOperation(5, "out", 10)).ReturnsAsync(true);
        _user = new User(5, "name", "qwe", "asd", UserRole.User);
        _userRole = UserRole.User;
        var state = new State();
        state.User = _user;
        state.Role = _userRole;
        state.BankAccount = _bankAccount;
        var f = new Facade(_bankRepMock.Object, _userRepMock.Object, state, _tranRepMock.Object);
        var facade = new FacadeAccessLevelProxy(f, state);

        bool fun = await facade.TakeMoneyFromBankAccount(5, 10, 5);
        IEnumerable<OperationsHistory> result = await facade.CheckOutOperationsHistory(5);

        Assert.True(fun);

        // у меня результат можно увидеть только вызывая просмотр счета который
        // берет данные из таблицы, так что лучшее что можно было сделать это
        // проверить что ключевые функции вызвались
        _bankRepMock.Verify(mock => mock.GetAllOperations(5), Times.Once);
        _tranRepMock.Verify(mock => mock.RegisterOperation(5, "out", 10), Times.Once);
        _bankRepMock.Verify(mock => mock.Update(5, 10, "Removal"), Times.Once);
    }

    [Fact]
    public async Task TestPutMoney()
    {
        _bankRepMock.Setup(m => m.GetAllAccounts(5)).ReturnsAsync(new List<BankAccount>() { _bankAccount });
        _bankRepMock.Setup(m => m.Update(5, 10, "Put")).ReturnsAsync(true);
        _tranRepMock.Setup(m => m.RegisterOperation(5, "in", 10)).ReturnsAsync(true);
        _user = new User(5, "name", "qwe", "asd", UserRole.User);
        _userRole = UserRole.User;
        var state = new State();
        state.User = _user;
        state.Role = _userRole;
        state.BankAccount = _bankAccount;
        var f = new Facade(_bankRepMock.Object, _userRepMock.Object, state, _tranRepMock.Object);
        var facade = new FacadeAccessLevelProxy(f, state);

        bool fun = await facade.PutMoneyOnBankAccount(5, 10, 5);
        IEnumerable<OperationsHistory> result = facade.CheckOutOperationsHistory(5);

        // Assert.True(fun);
        _bankRepMock.Verify(mock => mock.GetAllOperations(5), Times.Once);
        _tranRepMock.Verify(mock => mock.RegisterOperation(5, "in", 10), Times.Once);
        _bankRepMock.Verify(mock => mock.Update(5, 10, "Put"), Times.Once);
    }
}