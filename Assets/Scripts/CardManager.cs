using System.Collections.Generic;

public static class CardManager
{
    public static List<CardData> _selectedCards = new List<CardData>();

    public static bool IsSelected(CardData card)
    {
        return _selectedCards.Contains(card);
    }

    public static void AddSelectedCard(CardData card)
    {
        _selectedCards.Add(card);
    }
    //a
}
