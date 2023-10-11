namespace DefaultNamespace
{
    public class Obstacle : Collidable
    {
        protected override void OnCollide()
        {
            manager.AdjustTime(value);
            base.OnCollide();
        }
    }
}