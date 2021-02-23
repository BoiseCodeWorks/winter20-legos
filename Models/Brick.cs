namespace winter20_legos.Models
{
  public class Brick
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
  }

  public class KitBrickViewModel : Brick
  {
    public int KitBrickId { get; set; }
  }
}