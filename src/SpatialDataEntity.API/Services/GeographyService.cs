using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialDataEntity.API.Services
{
    public class GeographyService
    {
        /*
        #region Properties

        /// <summary>
        /// Gets the location text.
        /// </summary>
        /// <value>
        /// The location text.
        /// </value>
        public string LocationText { get; private set; }

        /// <summary>
        /// Gets or sets the mult polygon string helper.
        /// </summary>
        /// <value>
        /// The mult polygon string helper.
        /// </value>
        private string MultPolygonStringHelper { get; set; }

        /// <summary>
        /// The agrupamento cordenadas
        /// </summary>
        private List<List<double>> AgrupamentoCordenadas = new List<List<double>>();

        #endregion

        #region Configuration

        /// <summary>
        /// Gets the polygon tpe.
        /// </summary>
        /// <param name="locationText">The location text.</param>
        /// <returns></returns>
        public IGeometryObject ConfigureAndGetPolygonType(string locationText)
        {
            if (String.IsNullOrEmpty(locationText))
                return GetNullPolygon();


            this.LocationText = locationText;
            if (locationText.Contains("MULTIPOLYGON"))
            {
                SanatizeMultiPolygon();
                return this.GetMultiPolygon();
            }
            else
            {
                SanatizePolygon();
                return this.GetPolygon();
            }

        }

        /// <summary>
        /// Groups the coordinates.
        /// </summary>
        /// <param name="locationText">The location text.</param>
        private List<List<List<double>>> GroupCoordinates()
        {
            List<double> coordinates;
            var splitPorVirgula = LocationText.Split(',');
            List<List<List<double>>> AgrupamentoPolygon = new List<List<List<double>>>();
            AgrupamentoCordenadas.Clear();

            foreach (var item in splitPorVirgula)
            {
                coordinates = new List<double>();
                var splitPorEspaco = item.Split(' ');

                foreach (string coordenadas in splitPorEspaco)
                {
                    if (string.IsNullOrEmpty(coordenadas))
                        continue;

                    coordinates.Add(Convert.ToDouble(coordenadas, new CultureInfo("en-US", false)));
                }
                AgrupamentoCordenadas.Add(coordinates);
            }

            AgrupamentoPolygon.Add(AgrupamentoCordenadas);
            return AgrupamentoPolygon;
        }

        /// <summary>
        /// Groups the muilt coordinates.
        /// </summary>
        /// <returns></returns>
        private List<List<List<List<double>>>> GroupMultiCoordinates()
        {
            var splitCoordenadasPorVirgula = LocationText.Split(new string[] { "))," }, StringSplitOptions.None);
            List<List<List<double>>> AgrupamentoPolygon = null;
            List<List<List<List<double>>>> AgrupamentoMultiPolygon = new List<List<List<List<double>>>>();

            foreach (var item in splitCoordenadasPorVirgula)
            {
                AgrupamentoPolygon = new List<List<List<double>>>();
                AgrupamentoPolygon.Add(GroupCoordinates(GetItensByComma(item)));
                AgrupamentoMultiPolygon.Add(AgrupamentoPolygon);
            }

            return AgrupamentoMultiPolygon;
        }

        /// <summary>
        /// Gets the itens by comma.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private static string[] GetItensByComma(string item)
        {
            var tempLocationString = item.Replace("((", "");
            tempLocationString = tempLocationString.Replace("))", "");
            var splitPorVirgula = tempLocationString.Split(',');
            return splitPorVirgula;
        }

        /// <summary>
        /// Groups the coordinates.
        /// </summary>
        /// <param name="splitPorVirgula">The split por virgula.</param>
        /// <returns></returns>
        private List<List<double>> GroupCoordinates(string[] splitPorVirgula)
        {
            List<List<double>> agrupamentoCordenadas = new List<List<double>>();
            List<double> coordinates = null;
            foreach (var itens in splitPorVirgula)
            {
                coordinates = new List<double>();
                var splitPorEspaco = itens.Split(' ');

                foreach (string coordenadas in splitPorEspaco)
                {
                    if (string.IsNullOrEmpty(coordenadas))
                        continue;

                    coordinates.Add(Convert.ToDouble(CleanCoordinate(coordenadas), new CultureInfo("en-US")));
                }
                agrupamentoCordenadas.Add(coordinates);
            }

            return agrupamentoCordenadas;
        }

        /// <summary>
        /// Gets the null polygon.
        /// </summary>
        /// <returns></returns>
        private IGeometryObject GetNullPolygon()
        {
            return new Polygon(new List<List<List<double>>>());
        }

        /// <summary>
        /// Gets the polygon.
        /// </summary>
        /// <returns></returns>
        private IGeometryObject GetPolygon()
        {
            return new Polygon(GroupCoordinates());
        }

        /// <summary>
        /// Gets the polygon.
        /// </summary>
        /// <returns></returns>
        private IGeometryObject GetMultiPolygon()
        {
            var multicoordinates = GroupMultiCoordinates();

            NormalizeMulticoordinates(multicoordinates);

            return new MultiPolygon(multicoordinates);
        }

        #endregion

        #region Sanatize Methods

        private void SanatizePolygon()
        {
            LocationText = LocationText.Replace("POLYGON ((", "");
            LocationText = LocationText.Replace("))", "");
        }

        private void SanatizeMultiPolygon()
        {
            LocationText = LocationText.Replace("MULTIPOLYGON (((", "((");
            LocationText = LocationText.Replace(")))", "))");
        }

        private string CleanCoordinate(string coordinate)
        {
            return coordinate
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace(",", string.Empty);
        }

        private void NormalizeMulticoordinates(List<List<List<List<double>>>> multicoordinates)
        {
            foreach (var level1 in multicoordinates)
            {
                foreach (var level2 in level1)
                {
                    var first = level2.First();
                    var last = level2.Last();

                    if (first[0] != last[0] || first[1] != last[1])
                        level2.Add(new List<double> { first[0], first[1] });
                }
            }
        }

        #endregion
        */
    }
}
