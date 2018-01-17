namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using System.Text;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Stations.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Stations.DataProcessor.ImportDto;
    using Stations.Models.Enum;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using Stations.DataProcessor.ImportDto.Tickets;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            StationDto[] jsonStation = JsonConvert.DeserializeObject<StationDto[]>(jsonString);
            List<Station> stations = new List<Station>();

            foreach (var s in jsonStation)
            {
                string name = s.Name;
                string townName = s.Town;

                if (s.Town == null)
                {
                    townName = name;
                }

                StationDto dto = new StationDto()
                {
                    Name = name,
                    Town = townName,
                };

                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (stations.Any(x => x.Name == s.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Station station = Mapper.Map<Station>(dto);

                stations.Add(station);
                sb.AppendLine(string.Format(SuccessMessage, s.Name));
            }

            context.AddRange(stations);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            SeatingClassDto[] jsonSeatingClasses = JsonConvert.DeserializeObject<SeatingClassDto[]>(jsonString);
            List<SeatingClass> stations = new List<SeatingClass>();

            foreach (var s in jsonSeatingClasses)
            {
                SeatingClassDto dto = new SeatingClassDto()
                {
                    Name = s.Name,
                    Abbreviation = s.Abbreviation,
                };

                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (stations.Any(x => x.Name == s.Name || x.Abbreviation == s.Abbreviation))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                SeatingClass seatingClass = Mapper.Map<SeatingClass>(dto);

                stations.Add(seatingClass);
                sb.AppendLine(string.Format(SuccessMessage, s.Name));
            }

            context.AddRange(stations);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            TrainDto[] trainsDto = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
            });

            List<Train> trains = new List<Train>();

            foreach (var trainDto in trainsDto)
            {
                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (trains.Any(x => x.TrainNumber == trainDto.TrainNumber))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (!trainDto.Seats.All(IsValid))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TrainType? trainType = trainDto.Type;
                if (trainDto.Type == null)
                {
                    trainType = TrainType.HighSpeed;
                }


                bool dtoClasessIsValid = trainDto.Seats.All(t => context.SeatingClasses.Any(c => c.Name == t.Name && c.Abbreviation == t.Abbreviation));
                if (!dtoClasessIsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TrainSeat[] trainSeats = trainDto.Seats.Select(s => new TrainSeat
                {
                    SeatingClass = context.SeatingClasses.SingleOrDefault(x => x.Name == s.Name && x.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value,
                })
                .ToArray();

                Train train = new Train()
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = trainType,
                    TrainSeats = trainSeats,
                };

                trains.Add(train);
                sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            context.AddRange(trains);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportDto.TripDto[] tripsDto = JsonConvert.DeserializeObject<ImportDto.TripDto[]>(jsonString, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
            });

            List<Trip> trips = new List<Trip>();

            foreach (var tripDto in tripsDto)
            {
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                DateTime departureTime = DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                Train train = context.Trains.SingleOrDefault(x => x.TrainNumber == tripDto.Train);
                Station originStation = context.Stations.SingleOrDefault(x => x.Name == tripDto.OriginStation);
                Station destinationStation = context.Stations.SingleOrDefault(x => x.Name == tripDto.DestinationStation);

                if (train == null || originStation == null || destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (arrivalTime < departureTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TripStatus tripStatus = TripStatus.OnTime;
                if (tripDto.Status != null)
                {
                    tripStatus = tripDto.Status.Value;
                }

                TimeSpan? timeDifference = null;
                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                Trip trip = new Trip
                {
                    Train = train,
                    OriginStation = originStation,
                    DestinationStation = destinationStation,
                    ArrivalTime = arrivalTime,
                    DepartureTime = departureTime,
                    Status = tripStatus,
                    TimeDifference = timeDifference,

                };

                trips.Add(trip);
                sb.AppendLine(string.Format($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported."));
            }

            context.AddRange(trips);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportDto.CardDto[]), new XmlRootAttribute("Cards"));
            ImportDto.CardDto[] deserializedCards = (ImportDto.CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            StringBuilder sb = new StringBuilder();

            List<CustomerCard> cards = new List<CustomerCard>();

            foreach (var cardDto in deserializedCards)
            {
                if (!IsValid(cardDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = new CustomerCard()
                {
                    Name = cardDto.Name,
                    Age = cardDto.Age,
                    Type = cardDto.CardType,
                };

                cards.Add(card);
                sb.AppendLine(string.Format(SuccessMessage, cardDto.Name));
            }

            context.AddRange(cards);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            TicketDto[] deserializedCards = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            StringBuilder sb = new StringBuilder();

            List<Ticket> tickets = new List<Ticket>();

            foreach (var ticketDto in deserializedCards)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime date = DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                Trip trip = context.Trips.SingleOrDefault(x => x.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                x.OriginStation.Name == ticketDto.Trip.OriginStation && x.DepartureTime == date);

                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (ticketDto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(x => x.Name == ticketDto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatingClassAbbreviation = ticketDto.SeatingPlace.Substring(0, 2);
                var quantity = int.Parse(ticketDto.SeatingPlace.Substring(2));

                var seatExists = context.Trains
                    .Select(x => x.TrainSeats
                    .SingleOrDefault(s => s.SeatingClass.Abbreviation == seatingClassAbbreviation && quantity <= s.Quantity));

                if (seatExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                Ticket ticket = new Ticket()
                {
                    Price = ticketDto.Price,
                    SeatingPlace = ticketDto.SeatingPlace,
                    Trip = trip,
                    CustomerCard = card,
                };

                tickets.Add(ticket);
                sb.AppendLine($"Ticket from {ticketDto.Trip.OriginStation} to {ticketDto.Trip.DestinationStation} departing at {ticket.Trip.DepartureTime} imported.");
            }

            context.AddRange(tickets);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            System.ComponentModel.DataAnnotations.ValidationContext validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}