using Abstractions.Repositories;
using Application.Users;
using Models.Accounts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ScenariosChangingMoneyTests
{
    [Fact]
    public void TestedScenarioMakeWithdrawal_ExpectedResultSuccess_WhenEnoughMoney()
    {
        var currentUserManager = new CurrentUserManager();
        currentUserManager.UserAccount = new UserAccount(1, UserRole.User, 1000);
        IUserRepository? repositoryMock = Substitute.For<IUserRepository>();
        IHistoryOperationRepository? historyOperationRepositoryMock = Substitute.For<IHistoryOperationRepository>();

        var userService = new UserService(repositoryMock, currentUserManager, historyOperationRepositoryMock);

        // Act
        userService.MakeWithdrawal(500);

        // Assert
        repositoryMock.Received(1).MakeWithdrawalAsync(Arg.Any<long>(), Arg.Any<long>());
    }
}