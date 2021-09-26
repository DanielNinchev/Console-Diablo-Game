namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus
{
    public interface ISkillHoldingMenu : IInfoHoldingMenu
    {
        string SkillName { get; set; }

        void RenderSkillTree();
    }
}
