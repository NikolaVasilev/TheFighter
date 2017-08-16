namespace Engine.Constants
{
    public static class SoundPath
    {
        private static readonly string directory = @"../../../Engine/SoundFiles/";

        public static readonly string DirectionBtn = directory + "direction_btn.wav";
        public static readonly string UseWeapon = directory + "sword.wav";
        public static readonly string SellItem = directory + "sell-item.wav";
        public static readonly string UsePotion = directory + "potion-drink.wav";
        public static readonly string BuyItem = directory + "buy-item.wav";
        public static readonly string NotEnoughMoney = directory + "not-enough-money.wav";
        public static readonly string TradeClose = directory + "have-a-nice-day.wav";
        public static readonly string EnterTrade = directory + "enter-store.wav";
    }
}