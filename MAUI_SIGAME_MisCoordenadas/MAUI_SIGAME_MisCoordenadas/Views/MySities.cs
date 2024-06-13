using MAUI_SIGAME_MisCoordenadas.Models; // Asegúrate de que este espacio de nombres sea correcto
using System.Collections.Generic;
using System;

namespace MAUI_SIGAME_MisCoordenadas.Views;
public partial class MySities : ContentPage
{
    public MySities()
    {
        InitializeComponent();

        var registros = new List<Registro>
        {
            new Registro { Fecha = DateTime.Now, Descripcion = "Descripción 1", Coordenada = "40.7128° N, 74.0060° W" },
            new Registro { Fecha = DateTime.Now, Descripcion = "Descripción 2", Coordenada = "34.0522° N, 118.2437° W" },
            new Registro { Fecha = DateTime.Now, Descripcion = "Descripción 3", Coordenada = "51.5074° N, 0.1278° W" },
        };

        RegistrosListView.ItemsSource = registros;
    }
}