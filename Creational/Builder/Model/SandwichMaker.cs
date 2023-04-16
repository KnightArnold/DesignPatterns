﻿namespace Builder.Model
{
  public class SandwichMaker
  {
    private readonly SandwichBuilder builder;
    public SandwichMaker(SandwichBuilder builder)
    {
      this.builder = builder;
    }

    public void BuildSandwich()
    {
      builder.CreateNewSandwich();
      builder.PrepareBread();
      builder.ApplyMeatAndCheese();
      builder.ApplyVegetables();
      builder.AddCondiments();
    }

    public Sandwich GetSandwhich()
    {
      return builder.GetSandwich();
    }
  }
}