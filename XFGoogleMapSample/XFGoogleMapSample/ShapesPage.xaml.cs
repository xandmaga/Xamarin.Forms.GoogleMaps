using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XFGoogleMapSample
{
    public partial class ShapesPage : ContentPage
    {
        public ShapesPage()
        {
            InitializeComponent();

            Polyline polyline = null;
            Polygon polygon = null;
            Circle circle = null;

            string mapStyle = @"[
                                {
                                'featureType': 'administrative',
                                'elementType': 'geometry',
                                'stylers': [
                                    {
                                    'visibility': 'off'
                                    }
                                ]
                                },
                                {
                                'featureType': 'poi',
                                'stylers': [
                                    {
                                    'visibility': 'off'
                                    }
                                ]
                                },
                                {
                                'featureType': 'road',
                                'elementType': 'labels.icon',
                                'stylers': [
                                    {
                                    'visibility': 'off'
                                    }
                                ]
                                },
                                {
                                'featureType': 'transit',
                                'stylers': [
                                    {
                                    'visibility': 'off'
                                    }
                                ]
                                }
                            ]";

            // Polyline
            buttonAddPolyline.Clicked += (sender, e) =>
            {
                polyline = new Polyline();
                /*polyline.Positions.Add(new Position(40.77d, -73.93d));
                polyline.Positions.Add(new Position(40.81d, -73.91d));
                polyline.Positions.Add(new Position(40.83d, -73.87d));*/

                polyline.Positions.Add(new Position(37.797534, -122.401827));
                polyline.Positions.Add(new Position(37.797510, -122.402060));
                polyline.Positions.Add(new Position(37.790269, -122.400589));
                polyline.Positions.Add(new Position(37.790265, -122.400474));
                polyline.Positions.Add(new Position(37.790228, -122.400391));
                polyline.Positions.Add(new Position(37.790126, -122.400360));
                polyline.Positions.Add(new Position(37.789250, -122.401451));
                polyline.Positions.Add(new Position(37.788440, -122.400396));
                polyline.Positions.Add(new Position(37.787999, -122.399780));
                polyline.Positions.Add(new Position(37.786736, -122.398202));
                polyline.Positions.Add(new Position(37.786345, -122.397722));
                polyline.Positions.Add(new Position(37.785983, -122.397295));
                polyline.Positions.Add(new Position(37.785559, -122.396728));
                polyline.Positions.Add(new Position(37.780624, -122.390541));
                polyline.Positions.Add(new Position(37.777113, -122.394983));
                polyline.Positions.Add(new Position(37.776831, -122.394627));

                polyline.IsClickable = true;
                polyline.StrokeColor = Color.Blue;
                polyline.StrokeWidth = 5f;
                polyline.Tag = "POLYLINE"; // Can set any object

                polyline.Clicked += Polyline_Clicked;

                map.Polylines.Add(polyline);

                ((Button)sender).IsEnabled = false;
                buttonRemovePolyline.IsEnabled = true;
            };

            buttonRemovePolyline.Clicked += (sender, e) =>
            {
                map.Polylines.Remove(polyline);
                polyline.Clicked -= Polyline_Clicked;
                polyline = null;

                ((Button)sender).IsEnabled = false;
                buttonAddPolyline.IsEnabled = true;
            };
            buttonRemovePolyline.IsEnabled = false;

            // Polygon
            buttonAddPolygon.Clicked += (sender, e) =>
            {
                polygon = new Polygon();
                polygon.Positions.Add(new Position(40d, -73d));
                polygon.Positions.Add(new Position(41d, -73d));
                polygon.Positions.Add(new Position(41d, -74d));
                polygon.Positions.Add(new Position(40d, -74d));
                polygon.Positions.Add(new Position(40d, -73d));

                var hole = new Position[]
                {
                    new Position(40.5d, -73.5d),
                    new Position(40.6d, -73.5d),
                    new Position(40.6d, -73.6d),
                    new Position(40.5d, -73.6d),
                    new Position(40.5d, -73.5d),
                };

                polygon.Holes.Add(hole);

                polygon.IsClickable = true;
                polygon.StrokeColor = Color.Green;
                polygon.StrokeWidth = 3f;
                polygon.FillColor = Color.FromRgba(255, 0, 0, 64);
                polygon.Tag = "POLYGON"; // Can set any object

                polygon.Clicked += Polygon_Clicked;;

                map.Polygons.Add(polygon);

                ((Button)sender).IsEnabled = false;
                buttonRemovePolygon.IsEnabled = true;
                buttonAddHole.IsEnabled = true;
                buttonRemoveHole.IsEnabled = true;
            };

            buttonRemovePolygon.Clicked += (sender, e) =>
            {
                map.Polygons.Remove(polygon);
                polygon.Clicked -= Polygon_Clicked;
                polygon = null;

                ((Button)sender).IsEnabled = false;
                buttonAddPolygon.IsEnabled = true;
                buttonAddHole.IsEnabled = false;
                buttonRemoveHole.IsEnabled = false;
            };
            buttonRemovePolygon.IsEnabled = false;

            buttonAddHole.Clicked += (sender, e) =>
            {
                var hole2 = new Position[]
                {
                    new Position(40.7d, -73.7d),
                    new Position(40.8d, -73.7d),
                    new Position(40.8d, -73.8d),
                    new Position(40.7d, -73.8d),
                    new Position(40.7d, -73.7d),
                };
                polygon.Holes.Add(hole2);
            };
            buttonAddHole.IsEnabled = false;

            buttonRemoveHole.Clicked += (sender, e) =>
            {
                polygon.Holes.Clear();
            };
            buttonRemoveHole.IsEnabled = false;

            // Circle
            buttonAddCircle.Clicked += (sender, e) =>
            {
                circle = new Circle();
                circle.IsClickable = true;
                circle.Center = new Position(40.72d, -73.89d);
                circle.Radius = Distance.FromMeters(3000f);

                circle.StrokeColor = Color.Purple;
                circle.StrokeWidth = 6f;
                circle.FillColor = Color.FromRgba(0, 0, 255, 32);
                circle.Tag = "CIRCLE"; // Can set any object

                circle.Clicked += Circle_Clicked;

                map.Circles.Add(circle);

                ((Button)sender).IsEnabled = false;
                buttonRemoveCircle.IsEnabled = true;
            };

            buttonRemoveCircle.Clicked += (sender, e) =>
            {
                map.Circles.Remove(circle);
                circle = null;

                ((Button)sender).IsEnabled = false;
                buttonAddCircle.IsEnabled = true;
            };
            buttonRemoveCircle.IsEnabled = false;

            map.MapStyle = MapStyle.FromJson(mapStyle);

            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(37.79752, -122.40183), 12d);
        }

        void Polyline_Clicked(object sender, EventArgs e)
        {
            var polyline = (Polyline)sender;
            DisplayAlert("Polyline", $"{(string)polyline.Tag} Clicked!", "Close");
        }

        void Polygon_Clicked(object sender, EventArgs e)
        {
            var polygon = (Polygon)sender;
            DisplayAlert("Polygon", $"{(string)polygon.Tag} Clicked!", "Close");
        }

        private void Circle_Clicked(object sender, EventArgs e)
        {
            var circle = (Circle)sender;
            DisplayAlert("Circle", $"{(string)circle.Tag} Clicked!", "Close");
        }
    }
}

