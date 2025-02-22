namespace Compilador
{
    using MaterialSkin;
    using MaterialSkin.Controls;

    public class MaterialUI
    {
        public static void cargarMaterial(MaterialForm actualForm)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(actualForm);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
                );
        }
    }
}
