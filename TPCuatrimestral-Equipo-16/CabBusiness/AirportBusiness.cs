﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class AirportBusiness
    {
        public List<Airport> List()
        {
            List<Airport> list = new List<Airport>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT CodigoIATA, IdCiudad, NombreAeropuerto, Direccion, Estado FROM Aeropuertos");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Airport airport = new Airport();
                    airport.IdCity = (int)(long)dataManager.Lector["IdCiudad"];
                    airport.CodAirport = (string)dataManager.Lector["CodigoIATA"];
                    airport.NameAirport = (string)dataManager.Lector["NombreAeropuerto"];
                    airport.Address = (string)dataManager.Lector["Direccion"];
                    airport.State = (bool)dataManager.Lector["Estado"];

                    list.Add(airport);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dataManager.closeConection();
            }
        }
        public List<string> getNameAirportsByCity(string city)
        {
            List<string> Namelist = new List<string>();
            List<Airport> Airportlist = new List<Airport>();
            Airportlist = getAirportsByCity(city);
            foreach (Airport airport in Airportlist)
            {
                Namelist.Add(airport.NameAirport);
            }
            return Namelist;

        }

        public List<Airport> getAirportsByCity(string city)
        {
            List<Airport> list = new List<Airport>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT A.CodigoIATA, A.IdCiudad, A.NombreAeropuerto, A.Direccion, A.Estado FROM Aeropuertos A inner join Ciudades C on C.IdCiudad = A.IdCiudad and C.NombreCiudad = @NombreCiudad");
                dataManager.setParameter("@NombreCiudad", city);
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Airport airport = new Airport();
                    airport.IdCity = (int)(long)dataManager.Lector["IdCiudad"];
                    airport.CodAirport = (string)dataManager.Lector["CodigoIATA"];
                    airport.NameAirport = (string)dataManager.Lector["NombreAeropuerto"];
                    airport.Address = (string)dataManager.Lector["Direccion"];
                    airport.State = (bool)dataManager.Lector["Estado"];

                    list.Add(airport);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dataManager.closeConection();
            }
        }
    }
}
