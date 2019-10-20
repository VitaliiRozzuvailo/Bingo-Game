namespace BingoGame.Core.Models
{
    public class Cell
    {
        public int Value { get; private set; }
        public bool IsSelected { get; private set; }

        public Cell(int value)
        {
            Value = value;
        }

        public void SetSelected(bool selected)
        {
            IsSelected = selected;
        }
    }
}
