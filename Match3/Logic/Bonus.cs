namespace Match3.Logic
{
    public class Bonus : BaseElement
    {
        public Bonus(ElementType type, Vector2 position) : base(type, position) { }

        public override void Destroy(IElement[,] elementList)
        {
            if (IsNull) return;

            ScoreCounter.AddScore();
            IsNull = true;
            ActivateBonus(elementList);
        }

        protected virtual void ActivateBonus(IElement[,] elementList) { }
    }
}
