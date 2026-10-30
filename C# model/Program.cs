using System;

namespace ThemeParkTicketing
{
    internal class Program
    {
        // =========================================================
        // 1. WELCOME MESSAGE SUBROUTINE
        // =========================================================
        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Copington Adventure Theme Park!");
            Console.WriteLine("Let's get your tickets ready.");
            Console.WriteLine("");
            Console.WriteLine("===================================================");
        }

        // =========================================================
        // 2. ADULT TICKETS SUBROUTINE
        // =========================================================
        static int AdultTotal()
        {
            while (true)
            {
                try
                {
                    Console.Write("1 adult ticket is £20. How many adult tickets would you like to get? ");
                    int adultCount = int.Parse(Console.ReadLine());
                    int adultCost = adultCount * 20;

                    if (adultCount >= 0)
                    {
                        Console.WriteLine("Adult ticket cost is £" + adultCost + ".");
                        Console.WriteLine("-------------------------------------------------");
                        return adultCost;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number of tickets (0 or more).");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        // =========================================================
        // 3. CHILD TICKETS SUBROUTINE
        // =========================================================
        static int ChildTotal()
        {
            while (true)
            {
                try
                {
                    Console.Write("1 child ticket is £12, how many child tickets would you like to get? ");
                    int childCount = int.Parse(Console.ReadLine());
                    int childCost = childCount * 12;

                    if (childCount >= 0)
                    {
                        Console.WriteLine("Child ticket cost is £" + childCost + ".");
                        Console.WriteLine("-------------------------------------------------");
                        return childCost;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number of tickets (0 or more).");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        // =========================================================
        // 4. SENIOR TICKETS SUBROUTINE
        // =========================================================
        static int SeniorTotal()
        {
            while (true)
            {
                try
                {
                    Console.Write("1 senior ticket is £11, how many senior tickets would you like to get? ");
                    int seniorCount = int.Parse(Console.ReadLine());
                    int seniorCost = seniorCount * 11;

                    if (seniorCount >= 0)
                    {
                        Console.WriteLine("Senior citizen ticket cost is £" + seniorCost + ".");
                        Console.WriteLine("-------------------------------------------------");
                        return seniorCost;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number of tickets (0 or more).");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        // =========================================================
        // 5. ENTRANCE SUBROUTINE (Combines all ticket totals)
        // =========================================================
        static int Entrance()
        {
            int totalAdultCost = AdultTotal();
            int totalChildCost = ChildTotal();
            int totalSeniorCost = SeniorTotal();

            int totalCost = totalAdultCost + totalChildCost + totalSeniorCost;
            Console.WriteLine("Total ticket cost is £" + totalCost + ".");
            return totalCost;
        }

        // =========================================================
        // 6. WRISTBAND SUBROUTINE
        // =========================================================
        static int Wristband()
        {
            while (true)
            {
                try
                {
                    Console.Write("How many visitors would like a wristband for the rides? Each wristband is £20: ");
                    int wristTotal = int.Parse(Console.ReadLine());

                    if (wristTotal >= 0)
                    {
                        int wristbandCost = wristTotal * 20;
                        Console.WriteLine("Total wristband cost is £" + wristbandCost + ".");
                        Console.WriteLine("-------------------------------------------------");
                        return wristbandCost;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number of wristbands (0 or more).");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // =========================================================
        // 7. LEAD SURNAME VALIDATION SUBROUTINE
        // =========================================================
        static string LeadSurname()
        {
            while (true)
            {
                Console.Write("What is the surname of the lead booker? ");
                string surname = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------");

                if (!string.IsNullOrWhiteSpace(surname) && !surname.Contains(" "))
                {
                    // Proper casing: Capitalize first letter, make the rest lowercase
                    return char.ToUpper(surname[0]) + surname.Substring(1).ToLower();
                }
                else
                {
                    Console.WriteLine("Please provide a valid Surname! It should not contain any spaces or be blank.");
                }
            }
        }

        // =========================================================
        // 8. PARKING SUBROUTINE
        // =========================================================
        static bool Parking()
        {
            while (true)
            {
                Console.Write("Would you like to add parking for free? (yes/no): ");
                string required = Console.ReadLine().Trim().ToLower();
                Console.WriteLine("-------------------------------------------------");

                if (required == "yes" || required == "no")
                {
                    return required == "yes";
                }
                else
                {
                    Console.WriteLine("Please answer with 'yes' or 'no'.");
                }
            }
        }

        // =========================================================
        // 9. PAYMENT MACHINE SUBROUTINE
        // =========================================================
        static int NoteInput(int totalCost)
        {
            Console.WriteLine("Your total cost is £" + totalCost + ". The machine only accepts £10 and £20 notes.");
            int totalPaid = 0;

            while (totalPaid < totalCost)
            {
                try
                {
                    Console.Write("Please insert a £10 or £20 note: ");
                    int note = int.Parse(Console.ReadLine());

                    if (note == 10 || note == 20)
                    {
                        totalPaid += note;
                        Console.WriteLine("You have inserted £" + note + ". Total paid so far: £" + totalPaid + ".");

                        if (totalPaid < totalCost)
                        {
                            Console.WriteLine("You need to pay £" + (totalCost - totalPaid) + " more.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid note. Please insert either £10 or £20 notes.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please insert either £10 or £20 notes.");
                }
            }

            int change = totalPaid - totalCost;
            if (change > 0)
            {
                Console.WriteLine("Payment complete! Your change is £" + change + ".");
            }
            else
            {
                Console.WriteLine("Payment complete! No change required.");
            }

            return totalPaid;
        }

        // =========================================================
        // 10. SINGLE BOOKING TRANSACTION PIPELINE
        // =========================================================
        static void RunBookingSystem()
        {
            WelcomeMessage();

            int ticketCost = Entrance();
            int wristbandCost = Wristband();
            string surname = LeadSurname();
            bool parkingRequired = Parking();
            int parkingCost = 0; // Free parking as per spec

            int totalCost = ticketCost + wristbandCost + parkingCost;
            Console.WriteLine("Your final total is £" + totalCost);

            int totalPaid = NoteInput(totalCost);

            // Print Receipt Summary
            Console.WriteLine("");
            Console.WriteLine("==================================================");
            Console.WriteLine(" Copington Adventure Theme Park - Ticket for " + surname);
            Console.WriteLine(" Total Ticket Cost: £" + ticketCost);
            Console.WriteLine(" Total Wristband Cost: £" + wristbandCost);

            if (parkingRequired)
            {
                Console.WriteLine(" Parking: £0 (Free)");
            }
            else
            {
                Console.WriteLine(" Parking: Not required");
            }

            Console.WriteLine(" Total Paid: £" + totalPaid);
            Console.WriteLine("");
            Console.WriteLine("Thank you for your purchase! Enjoy your visit to Copington Adventure Theme Park!");
            Console.WriteLine("==================================================");
            Console.WriteLine("");
        }

        // =========================================================
        // 11. MAIN ENTRY POINT (Handles Multiple Customers)
        // =========================================================
        static void Main(string[] args)
        {
            int customerCount = 0;
            int maxCustomers = 500;

            while (customerCount < maxCustomers)
            {
                Console.WriteLine("");
                Console.WriteLine("===================================================");
                Console.WriteLine("");

                RunBookingSystem();

                customerCount++;

                Console.WriteLine($"Next customer please! (Customer #{customerCount} of {maxCustomers})");
                Console.WriteLine("");
                Console.WriteLine("===================================================");

                if (customerCount >= maxCustomers)
                {
                    Console.WriteLine("Machine shutdown: Daily capacity limit reached.");
                }
                else
                {
                    Console.WriteLine("System ready for next transaction.");
                }
            }
        }
    }
}
