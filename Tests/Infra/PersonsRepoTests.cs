using Gym.Data;
using Gym.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.Tests.Infra;

[TestClass]
public class PersonsRepoTests
{
    private AppDbContext GetContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [TestMethod]
    public async Task CreateAsync_ShouldAddPerson()
    {
        var context = GetContext();
        var repo = new PersonsRepo(context);
        var person = new Person { FirstName = "John", LastName = "Doe", Email = "john@test.com" };

        var result = await repo.CreateAsync(person);

        Assert.AreNotEqual(Guid.Empty, result.Id);
        Assert.AreEqual(1, await context.Persons.CountAsync());
        Assert.AreEqual("John", result.FirstName);
    }

    [TestMethod]
    public async Task GetAsync_ShouldReturnPerson()
    {
        var context = GetContext();
        var repo = new PersonsRepo(context);
        var person = new Person { FirstName = "Jane", LastName = "Smith", Email = "jane@test.com" };
        await repo.CreateAsync(person);

        var result = await repo.GetAsync(person.Id);

        Assert.IsNotNull(result);
        Assert.AreEqual("Jane", result.FirstName);
    }

    [TestMethod]
    public async Task GetAsync_WithWrongId_ShouldReturnNull()
    {
        var context = GetContext();
        var repo = new PersonsRepo(context);
        var wrongId = Guid.NewGuid();

        var result = await repo.GetAsync(wrongId);

        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task UpdateAsync_ShouldUpdatePerson()
    {
        var context = GetContext();
        var repo = new PersonsRepo(context);
        var person = new Person { FirstName = "Old", LastName = "Name", Email = "old@test.com" };
        await repo.CreateAsync(person);

        person.FirstName = "New";
        await repo.UpdateAsync(person);
        var updated = await repo.GetAsync(person.Id);

        Assert.AreEqual("New", updated.FirstName);
    }

    [TestMethod]
    public async Task DeleteAsync_ShouldDeletePerson()
    {
        var context = GetContext();
        var repo = new PersonsRepo(context);
        var person = new Person { FirstName = "Delete", LastName = "Me", Email = "delete@test.com" };
        await repo.CreateAsync(person);
        Assert.AreEqual(1, await context.Persons.CountAsync());

        await repo.DeleteAsync(person.Id);
        Assert.AreEqual(0, await context.Persons.CountAsync());
    }

    [TestMethod]
    public async Task GetAllAsync_ShouldReturnAllPersons()
    {
        var context = GetContext();
        var repo = new PersonsRepo(context);
        await repo.CreateAsync(new Person { FirstName = "A", LastName = "A", Email = "a@test.com" });
        await repo.CreateAsync(new Person { FirstName = "B", LastName = "B", Email = "b@test.com" });

        var result = (await repo.GetAsync(new Query())).ToList();

        Assert.AreEqual(2, result.Count);
    }
}