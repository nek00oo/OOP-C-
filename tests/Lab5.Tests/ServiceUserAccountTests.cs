using Abstractions.Repositories;
using Application.Users;
using Contracts.Users;
using Models.Accounts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ServiceUserAccountTests
{
    [Fact]
    public void TestedMethodMakeWithdrawal_ExpectedResultSuccess_WhenEnoughMoney()
    {
        var currentUserManager = new CurrentUserManager();
        currentUserManager.UserAccount = new UserAccount(1, UserRole.User, 1000);
        IUserRepository? repositoryMock = Substitute.For<IUserRepository>();
        IHistoryOperationRepository? historyOperationRepositoryMock = Substitute.For<IHistoryOperationRepository>();

        var userService = new UserService(repositoryMock, currentUserManager, historyOperationRepositoryMock);

        // Act
        userService.MakeWithdrawal(500);

        // Assert
        repositoryMock.Received(1).MakeWithdrawalAsync(1, 500);
    }

    [Fact]
    public void TestedMethodMakeWithdrawal_ExpectedResultSuccess_WhenNotEnoughMoney()
    {
        var currentUserManager = new CurrentUserManager();
        currentUserManager.UserAccount = new UserAccount(1, UserRole.User, 1000);
        IUserRepository? repositoryMock = Substitute.For<IUserRepository>();
        IHistoryOperationRepository? historyOperationRepositoryMock = Substitute.For<IHistoryOperationRepository>();

        var userService = new UserService(repositoryMock, currentUserManager, historyOperationRepositoryMock);

        // Act
        userService.MakeWithdrawal(1200);

        // Assert
        repositoryMock.DidNotReceive().MakeWithdrawalAsync(1, 500);
    }

    [Fact]
    public void TestedMethodToUpMoney_ExpectedResultSuccess_WhenNotEnoughMoney()
    {
        var currentUserManager = new CurrentUserManager();
        currentUserManager.UserAccount = new UserAccount(1, UserRole.User, 1000);
        IUserRepository? repositoryMock = Substitute.For<IUserRepository>();
        IHistoryOperationRepository? historyOperationRepositoryMock = Substitute.For<IHistoryOperationRepository>();

        var userService = new UserService(repositoryMock, currentUserManager, historyOperationRepositoryMock);

        // Act
        ToUpBalanceResult result = userService.ToUpAccountBalance(30);

        // Assert
        Assert.Equal(result, new ToUpBalanceResult.Success(0));
    }
}