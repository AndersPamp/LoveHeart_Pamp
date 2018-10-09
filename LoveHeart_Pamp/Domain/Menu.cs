using System;
using System.Collections.Generic;
using System.Threading;


namespace LoveHeart.Domain
{
    class Menu
    {
        string userName;
        string passWord;
        Dictionary<string, User> users = new Dictionary<string, User>();
        Dictionary<long, Owner> owners = new Dictionary<long, Owner>();
        Dictionary<int, Animal> animals = new Dictionary<int, Animal>();
        Dictionary<Animal, Journal> journals = new Dictionary<Animal, Journal>();
        Dictionary<DateTime, Schedule> appointments = new Dictionary<DateTime, Schedule>();

        public void Menu1()
        {
            users.Add("admin", new User("admin", "admin", 'A', "admin", "admin", 1234567890));
            users.Add("jane", new User("Jane", "Andersson", 'R', "jane", "incorrect", 7001010480));
            users.Add("janne", new User("Janne", "Andersson", 'V', "janne", "password", 7001010490));
            owners.Add(7101015222, new Owner("Maria", "Nilsson", 7101015222));
            owners.Add(7201015225, new Owner("Lisa", "Nilsson", 7201015225));
            animals.Add(1, new Animal("Dog", "Boz", new DateTime(2010, 10, 02), 1, owners[7101015222]));
            animals.Add(2, new Animal("Cat", "Helmut", new DateTime(2011, 10, 02), 2, owners[7201015225]));
            journals.Add(animals[1], new Journal(owners[7101015222], animals[1], "Leg fell off, stuck in rectum"));
            journals.Add(animals[2], new Journal(owners[7201015225], animals[2], "Eaten its own head"));
            appointments.Add(new DateTime(2018, 10, 10, 10, 30, 0), new Schedule(new DateTime(2018, 10, 10, 10, 30, 0), owners[7101015222], animals[1], "Leg fell off, stuck in rectum"));
            appointments.Add(new DateTime(2018, 10, 11, 11, 0, 0), new Schedule(new DateTime(2018, 10, 11, 11, 0, 0), owners[7201015225], animals[2], "Eaten its own head"));

            Console.Clear();
            Console.WriteLine("=== LOVEHEART JOURNAL SYSTEM ===\n");
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.SelectVoice("Microsoft Hazel Desktop");
            //synth.Speak("Sooo you managed to get your lazy arse to work today!");

            Console.WriteLine("#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#=#\n");
            Console.WriteLine("--------------LOGIN--------------\n");
            Console.Write("Username: ");
            userName = Console.ReadLine();
            Console.Write("Password: ");
            Console.ForegroundColor = ConsoleColor.Black;  //Dodgy way of hiding pwd-input
            passWord = Console.ReadLine();
            Console.ResetColor();

            if (users.ContainsKey(userName) == true)
            {
                if (users[userName].Position == 'V')
                {
                    if (userName == users[userName].UserName && passWord == users[userName].PassWord)
                    {
                        Menu2_VetMain(); //Vet. menu
                    }
                    else
                    {
                        Console.WriteLine("Username or password incorrect.");
                        Console.WriteLine("Press any key to go to start.");
                        Console.ReadKey();
                        Menu1();
                    }
                }
                else if (users[userName].Position == 'R')
                {
                    if (userName == users[userName].UserName && passWord == users[userName].PassWord)
                    {
                        Menu3_RecMain(); //Rec. menu
                    }
                    else
                    {
                        Console.WriteLine("Username or password incorrect.");
                        Console.WriteLine("Press any key to go to start.");
                        Console.ReadKey();
                        Menu1();
                    }
                }
                else if (users[userName].Position == 'A')
                {
                    if (userName == users[userName].UserName && passWord == users[userName].PassWord)
                    {
                        Menu4_AdminMain(); //Admin menu
                    }
                    else
                    {
                        Console.WriteLine("Username or password incorrect.");
                        Console.WriteLine("Press any key to go to start.");
                        Console.ReadKey();
                        Menu1();
                    }
                }
            }
            else
            {
                Console.WriteLine("If you haven't acquired a user's account yet" +
                    "\nGo see the it-guy (the pimple-faced guy in glasses...)");
                Thread.Sleep(2500);
                Menu1();
            }
        }
        public void Menu2_VetMain()  //Vet.main menu
        {
            Console.Clear();
            Console.WriteLine("1. Search appointment");
            Console.WriteLine("2. Search journal");
            Console.WriteLine("3. Create new journal");
            Console.WriteLine("4. Log out");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Menu10_SearchAppt();
                    break;
                case 2:
                    Menu8_SearchJournal();
                    break;
                case 3:
                    Menu7_CreateJournal();
                    break;
                case 4:
                    Menu1();
                    break;
                default:
                    Console.WriteLine("Something went wrong, try again");
                    Thread.Sleep(2000);
                    Menu2_VetMain();
                    break;
            }
        }
        public void Menu3_RecMain()  //Receptionist main menu
        {
            Console.Clear();
            Console.WriteLine("1. Register new customer");
            Console.WriteLine("2. Search customer");
            Console.WriteLine("3. Create new appointment");
            Console.WriteLine("4. Search appointment");
            Console.WriteLine("5. Register new animal");
            Console.WriteLine("6. Log out");
            Console.WriteLine("\n<Menu option>");
            int choice = int.Parse(Console.ReadLine());

            {
                switch (choice)
                {
                    case 1:
                        Menu5_RegCustomer();
                        break;
                    case 2:
                        Menu6_SearchCustomer();
                        break;
                    case 3:
                        Menu11_CreateAppt();
                        break;
                    case 4:
                        Menu10_SearchAppt();
                        break;
                    case 5:
                        Menu12_RegAnimal();
                        break;
                    case 6:
                        Menu1();
                        break;
                    default:
                        break;
                }
            }
        }
        public void Menu4_AdminMain() //Admin main menu
        {
            Console.Clear();
            Console.WriteLine("1. Create user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Log out");
            var admChoice = Console.ReadKey();
            if (admChoice.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("# New user");
                Console.Write("\nFirst name: ");
                string fName = Console.ReadLine();
                Console.Write("Last name:");
                string lName = Console.ReadLine();
                Console.Write("Position (A/V/R)");
                char pos = char.Parse(Console.ReadLine());
                Console.Write("Username (unique): ");
                string userName = Console.ReadLine();
                Console.Write("Password: ");
                string pwd = Console.ReadLine();
                Console.WriteLine("SSN: ");
                long ssn = long.Parse(Console.ReadLine());
                Console.WriteLine("Is above info correct? (Y)es (N)o");
                ConsoleKeyInfo correct = Console.ReadKey();
                if (correct.Key == ConsoleKey.Y)
                {
                    users.Add(userName, new User(fName, lName, pos, userName, pwd, ssn));
                    Menu4_AdminMain();
                }
                else
                {
                    Menu4_AdminMain();
                }
            }
            else if (admChoice.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("# Delete user");
                Console.Write("\nType the username of the user you want to delete");
                string delChoice = Console.ReadLine();
                if (users.ContainsKey(delChoice))
                {
                    Console.WriteLine($"{users[delChoice].FirstName} {users[delChoice].LastName}");
                    Console.WriteLine("Are you sure you want to delete this user? (Y)es (N)o");
                    ConsoleKeyInfo delConfirm = Console.ReadKey();
                    if (delConfirm.Key == ConsoleKey.Y)
                    {
                        users.Remove(delChoice);
                        Console.WriteLine("\n\nUser successfully deleted");
                        Thread.Sleep(2000);
                        Menu4_AdminMain();
                    }
                    else
                    {
                        Menu4_AdminMain();
                    }
                }
            }
            else if (admChoice.Key == ConsoleKey.D3)
            {
                Menu1();
            }
            else
            {
                Menu4_AdminMain();
            }
        }
        public void Menu5_RegCustomer()  //Register customer menu
        {
            Console.Clear();
            Console.WriteLine("#  Register new customer");
            Console.Write("\nFirst Name: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lName = Console.ReadLine();
            Console.Write("Social Security Number: ");
            long ssn = long.Parse(Console.ReadLine());
            owners.Add(ssn, new Owner(fName, lName, ssn));
            Console.WriteLine("Customer registered successfully.");
            Thread.Sleep(2000);
            Menu3_RecMain();
        }
        public void Menu6_SearchCustomer()  //Search customer menu
        {
            Console.Clear();
            Console.WriteLine("#  Search for customer");
            Console.Write("Type the SSN of the customer: ");
            long search = long.Parse(Console.ReadLine());

            if (owners.ContainsKey(search))
            {
                Console.WriteLine($"First name: {owners[search].FirstName}");
                Console.WriteLine($"Last name: {owners[search].LastName}");
                Console.WriteLine($"Social Security Number: {owners[search].SocSecNr}");
            }
            else
            {
                Console.WriteLine("Customer not in our files.");
                Console.WriteLine("Register this customer (Y/N) ");
                string regChoice = Console.ReadLine();
                if (regChoice.ToUpper() == "Y")
                {
                    Menu5_RegCustomer();
                }
                else
                {
                    Console.WriteLine("Press any key to go back to menu");
                    Console.ReadKey();
                    Menu3_RecMain();
                }

            }
        }
        public void Menu7_CreateJournal()
        {
            Console.Clear();
            Console.WriteLine("# Create new journal");
            Console.Write("\nOwners SSN: ");
            long owner = long.Parse(Console.ReadLine());
            Console.Write("Animal's Id nr. ");
            int animal = int.Parse(Console.ReadLine());
            Console.Write("Conclusion from examination: ");
            string ailment = Console.ReadLine();
            journals.Add(animals[animal], new Journal(owners[owner], animals[animal], ailment));
            Menu2_VetMain();
        }
        public void Menu8_SearchJournal()
        {
            Console.Clear();
            Console.WriteLine("# Search journal");
            Console.WriteLine("\nWhich animals journal are you looking for?");
            int search = int.Parse(Console.ReadLine());
            if (journals.ContainsKey(animals[search]))
            {
                Console.Clear();
                Console.WriteLine($"{journals[animals[search]].Animal.IdNr}");
                Console.WriteLine($"{journals[animals[search]].Animal.Name}");
                Console.WriteLine($"{journals[animals[search]].Ailment}");
                Console.WriteLine("Do you wish to edit this journal? (Y)es (N)o ");
                var editChoice = Console.ReadKey();
                if (editChoice.Key == ConsoleKey.Y)
                {
                    Menu9_EditJournal(search, animals[search].Owner.SocSecNr);
                }
                else
                {
                    Menu2_VetMain();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There's no journal for this animal");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                Menu2_VetMain();
            }
        }
        public void Menu9_EditJournal(int animal, long owner)
        {
            Console.Clear();
            Console.WriteLine($"Owner: {owners[owner]}");
            Console.WriteLine($"Animals name: {animals[animal].Name}");
            Console.WriteLine($"Medical history: {journals[animals[animal]].Ailment}");
            Console.WriteLine("\nAdd to medical history: ");
            string addition = Console.ReadLine();
            Console.WriteLine("Press any key to save and return to menu");
            Console.ReadKey();
            journals[animals[animal]].Ailment = journals[animals[animal]].Ailment + addition;
            Menu2_VetMain();

        }
        public void Menu10_SearchAppt()
        {
            Console.Clear();
            Console.WriteLine("# Search appointment");
            Console.Write("\nInput date and time for appointment: ");
            DateTime search = DateTime.Parse(Console.ReadLine());
            if (appointments.ContainsKey(search))
            {
                Console.Clear();
                Console.WriteLine($"When: {appointments[search].AppointmentDate}");
                Console.WriteLine($"Who: {appointments[search].Animal}");
                Console.WriteLine($"Why: {appointments[search].Problem}");
                Console.WriteLine($"Owner: {appointments[search].Owner.FirstName} {appointments[search].Owner.LastName}");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                Menu2_VetMain();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There's no appointment for this date/time");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                Menu2_VetMain();
            }
        }
        public void Menu11_CreateAppt()
        {
            Console.Clear();
            Console.WriteLine("# Create appointment");
            Console.Write("\nDate & Time: ");
            DateTime apptDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Owner's SSN: ");
            long owner = long.Parse(Console.ReadLine());
            Console.Write("Animal's Id nr. ");
            int idNr = int.Parse(Console.ReadLine());
            Console.Write("What is wrong with the animal?");
            string problem = Console.ReadLine();
            appointments.Add(apptDate, new Schedule(apptDate, owners[owner], animals[idNr], problem));
        }
        public void Menu12_RegAnimal()
        {
            Console.Clear();
            Console.WriteLine("# Register new animal");
            Console.WriteLine("\nOwners SSN: ");
            long owner = long.Parse(Console.ReadLine());
            Console.Write("Animal name: ");
            string name = Console.ReadLine();
            Console.Write("DoB: ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Type of animal: ");
            string type = Console.ReadLine();
            Console.Write("Id nr: ");
            int idNr = int.Parse(Console.ReadLine());
            animals.Add(idNr, new Animal(type, name, dob, idNr, owners[owner]));
        }
    }
}
