using NUnit.Framework;

namespace Tests
{
    public class BattleHandlerTests
    {
        [Test]
        public void PlayerTurnWillExecutePlayerUnitsAction_BasicAttack()
        {
            BattleHandler battleHandler = new BattleHandler();
            PlayerUnit playerUnit = new PlayerUnit();
            playerUnit.unitName = "TESTER";

            BasicAttack plannedAction_BasicAttack = new BasicAttack(playerUnit);

            battleHandler.playerActionQueue.Add(playerUnit);
            battleHandler.ExecutePlayerActionQueue();
        }
    }
}