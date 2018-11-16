using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class ProgramUI
    {
        OutingRepository _outingRepository = new OutingRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Outings\n" +
                    "1. Display all outings\n" +
                    "2. Add outing\n" +
                    "3. Display total cost of all outings\n" +
                    "4. Display cost of outing by type\n" +
                    "5. Exit application");

                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        DisplayOutingList();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        DisplayTotalCost();
                        break;
                    case 4:
                        DisplayTypeCost();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry...");
                        break;
                }
            }
        }

        private void DisplayTypeCost()
        {
            Console.WriteLine("Choose type of outing:");
            Console.WriteLine("\t1. Golf\n" +
                "\t2. Bowling\n" +
                "\t3. Amusement Park\n" +
                "\t4. Concert\n" +
                "\t5. Return to menu...");
            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                    Console.WriteLine("Cost of golf outings: ");
                    _outingRepository.SortAndTotalCostByType("golf");
                    break;
                case 2:
                    Console.WriteLine("Cost of bowling outings: ");
                    _outingRepository.SortAndTotalCostByType("bowling");
                    break;
                case 3:
                    Console.WriteLine("Cost of amusement park outings: ");
                    _outingRepository.SortAndTotalCostByType("amusement park");
                    break;
                case 4:
                    Console.WriteLine("Cost of concert outings: ");
                    _outingRepository.SortAndTotalCostByType("concert");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Invalid entry...");
                    break;
            }
        }

        private void DisplayTotalCost()
        {
            Console.WriteLine($"Total cost of all outings: ${_outingRepository.TotalOutingListCost()}");
            ReturnToMenu();
        }

        private void AddOuting()
        {
            Outing outing = new Outing();
            Console.WriteLine("Enter event type:");
            outing.EventType = Console.ReadLine();
            Console.WriteLine("Enter event date(dd/MM/yyyy)):");
            outing.EventDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter attendance numbers:");
            outing.EventAttendance = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cost per person:");
            outing.EventCostPerPerson = decimal.Parse(Console.ReadLine());
            outing.EventCost = outing.EventAttendance * outing.EventCostPerPerson;
            ReturnToMenu();

            _outingRepository.AddOutingToList(outing);
            Console.Clear();
        }

        private void DisplayOutingList()
        {
            Console.WriteLine("Komodo Outings:");
            int i = 0;
            foreach (Outing outing in _outingRepository.GetOutingsList())
            {
                i++;
                switch (outing.EventType)
                {
                    case "golf":
                        Console.WriteLine($"\t{outing.EventType} -- Date: {outing.EventDate} -- Attendance: {outing.EventAttendance} -- Cost: ${outing.EventCost}");
                        break;
                    case "bowling":
                        Console.WriteLine($"\t{outing.EventType} -- Date: {outing.EventDate} -- Attendance: {outing.EventAttendance} -- Cost: ${outing.EventCost}");
                        break;
                    case "amusement park":
                        Console.WriteLine($"\t{outing.EventType} -- Date: {outing.EventDate} -- Attendance: {outing.EventAttendance} -- Cost: ${outing.EventCost}");
                        break;
                    case "concert":
                        Console.WriteLine($"\t{outing.EventType} -- Date: {outing.EventDate} -- Attendance: {outing.EventAttendance} -- Cost: ${outing.EventCost}");
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"");
            }
            ReturnToMenu();
        }

        public string PrintOutings(List<string> outings)
        {
            string printedOutings = "";
            foreach (var outing in outings)
            {
                printedOutings = outing + printedOutings;
            }
            return printedOutings;
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
