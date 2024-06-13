using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using System;

namespace MAUI_SIGAME_MisCoordenadas;

public partial class MainPage : ContentPage
{
    private string lblCoordenada = "No se registran coordenadas";

    public MainPage()
    {
        InitializeComponent();
        LabelCoordenadas.Text = lblCoordenada;
        StartLocationUpdates();
    }

    private async void StartLocationUpdates()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(1));
            var location = await Geolocation.Default.GetLastKnownLocationAsync();
            if (location != null)
            {
                UpdateLocationData(location);
            }

            Geolocation.Default.LocationChanged += OnLocationChanged;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener ubicación: {ex.Message}");
        }
    }

    private void OnLocationChanged(object sender, GeolocationLocationChangedEventArgs e)
    {
        UpdateLocationData(e.Location);
    }

    private void UpdateLocationData(Location location)
    {
        if (location != null)
        {
            this.Dispatcher.Dispatch(() =>
            {
                lblCoordenada = $"Latitud: {location.Latitude}, Longitude: {location.Longitude}, Precisión: {location.Accuracy}";
                LabelCoordenadas.Text = lblCoordenada;
            });
        }
    }

    private async void UpdatedCoordinatesClicked(object sender, EventArgs e)
    {
        var location = await Geolocation.Default.GetLastKnownLocationAsync();
        if (location != null)
        {
            UpdateLocationData(location);
        }
    }

    private void OnGetCoordinatesClicked(object sender, EventArgs e)
    {
        DisplayAlert("Coordenadas", lblCoordenada, "OK");
    }
}