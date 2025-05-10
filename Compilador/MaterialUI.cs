// <copyright file="MaterialUI.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using MaterialSkin;
    using MaterialSkin.Controls;

    /// <summary>
    /// Clase material para agregar estilos al form.
    /// </summary>
    public class MaterialUI
    {
        /// <summary>
        /// Cargar material en el load.
        /// </summary>
        /// <param name="actualForm">Form.</param>
        public static void CargarMaterial(MaterialForm actualForm)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(actualForm);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400,
                Primary.Blue500,
                lightPrimary: Primary.Blue500,
                accent: Accent.LightBlue200,
                textShade: TextShade.WHITE);
        }
    }
}
