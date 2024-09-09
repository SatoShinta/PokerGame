using System.Collections.Generic;

public static class CardManager
{
    public static List<CardData> _selectedCards = new List<CardData>();
    public static List<CardData> _EnemyselectedCards = new List<CardData>();

    public static bool IsSelected(CardData card)
    {
        return _selectedCards.Contains(card) || _EnemyselectedCards.Contains(card);
    }

    public static void AddSelectedCard(CardData card)
    {
        _selectedCards.Add(card);
    }
    
    public static void AddEnemySelectedCard(CardData card)
    {
        _EnemyselectedCards.Add(card);
    }
}
