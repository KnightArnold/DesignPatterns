using Builder.Model;

namespace Builder.Tests;

[TestClass]
public class Builder_SandwichMakerShould
{
  [TestMethod]
  public void RenderMySandwichBuilderGivenSandwichMaker()
  {
    var sandwichMaker = new SandwichMaker(new MySandwichBuilder());
    sandwichMaker.BuildSandwich();
    var sandwich1 = sandwichMaker.GetSandwhich();

    sandwich1.Display();

    Assert.IsFalse(sandwich1.HasMayo);
    Assert.IsTrue(sandwich1.HasMustard);
    CollectionAssert.AreEqual(new List<string> { "Tomato", "Onion" }, sandwich1.Vegetables);
    Assert.AreEqual(CheeseType.Cheddar, sandwich1.CheeseType);
    Assert.AreEqual(MeatType.Turkey, sandwich1.MeatType);
    Assert.AreEqual(BreadType.White, sandwich1.BreadType);
    Assert.IsTrue(sandwich1.IsToasted);
  }

  [TestMethod]
  public void RenderClubSandwichBuilderGivenSandwichMaker()
  {
    var sandwichMaker2 = new SandwichMaker(new ClubSandwichBuilder());
    sandwichMaker2.BuildSandwich();
    var sandwich2 = sandwichMaker2.GetSandwhich();

    sandwich2.Display();

    Assert.IsTrue(sandwich2.HasMayo);
    Assert.IsTrue(sandwich2.HasMustard);
    CollectionAssert.AreEqual(new List<string> { "Tomato", "Onion", "Lettuce" }, sandwich2.Vegetables);
    Assert.AreEqual(CheeseType.Swiss, sandwich2.CheeseType);
    Assert.AreEqual(MeatType.Turkey, sandwich2.MeatType);
    Assert.AreEqual(BreadType.White, sandwich2.BreadType);
    Assert.IsTrue(sandwich2.IsToasted);
  }
}